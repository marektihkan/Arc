using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Logging;
using Arc.Infrastructure.Registry;
using Arc.Infrastructure.Validation;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Arc.Integration.Tests.Fakes.Model.Services;
using Arc.Integration.Tests.Fakes.Validation;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using ValidationConfiguration=Arc.Infrastructure.Validation.EnterpriseLibrary.ValidationConfiguration;

namespace Arc.Integration.Tests.Configuration
{
    public abstract class BaseConfigurationTests
    {
        public abstract IServiceLocator CreateServiceLocator();


        [Test]
        public void Should_configure_service_locator_provider()
        {
            Configure.ServiceLocator.ProviderTo(CreateServiceLocator());

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
        }

        [Test]
        public void Should_configure_logging_provider()
        {
            Configure.ServiceLocator.ProviderTo(CreateServiceLocator())
                .With<Arc.Infrastructure.Logging.Log4Net.LoggingConfiguration>();

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ILogger>(), Is.Not.Null);
        }

        [Test]
        public void Should_configure_validation_provider()
        {
            Configure.ServiceLocator.ProviderTo(CreateServiceLocator())
                .With<ValidationConfiguration>();

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IValidationService>(), Is.Not.Null);
        }

        [Test]
        public void Should_load_convention_to_service_provider()
        {
            Configure.ServiceLocator.ProviderTo(CreateServiceLocator())
                .With(new RegisterServicesConvention());

            Assert.That(ServiceLocator.Resolve<IService>(), Is.Not.Null);
        }

        [Test]
        public void Should_configure_data_access()
        {
            Configure.ServiceLocator.ProviderTo(CreateServiceLocator())
                .With(DataConfiguration.Default(BuildNHibernateConfiguration()))
                .With<LoggingIsNotUsedConfiguration>()
                .With<ValidationIsNotUsedConfiguration>();

            Assert.That(ServiceLocator.Resolve<INHibernateConfiguration>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IUnitOfWorkFactory>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ISessionFactory>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IUnitOfWork>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<INHibernateRepository<DomainEntity>>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IRepository<DomainEntity>>(), Is.Not.Null);
        }

        private FluentConfiguration BuildNHibernateConfiguration()
        {
            return Fluently.Configure().Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(c => 
                        c.Server("local").Database("").TrustedConnection())
                );
        }

        [Test]
        public void Should_configure_registries()
        {
            Configure.ServiceLocator.ProviderTo(CreateServiceLocator())
                .With<RegistryConfiguration>();

            Assert.That(ServiceLocator.Resolve<IHybridRegistry>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IThreadRegistry>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ILocalRegistry>(), Is.Not.Null);
        }
    }
}