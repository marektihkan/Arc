using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Logging;
using Arc.Infrastructure.Registry;
using Arc.Infrastructure.Validation;
using Arc.Infrastructure.Validation.FluentValidation;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Arc.Integration.Tests.Fakes.Model;
using Arc.Integration.Tests.Fakes.Validation;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NUnit.Framework;
using IService=Arc.Integration.Tests.Fakes.Model.Services.IService;

namespace Arc.Integration.Tests.Configuration
{
    public abstract class BaseConfigurationTests
    {
        public abstract IServiceLocator CreateServiceLocator();


        [Test]
        public void Should_configure_service_locator_provider()
        {
            Application.ServiceLocatorIs(CreateServiceLocator());

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
        }

        [Test]
        public void Should_configure_logging_provider()
        {
            Application.ServiceLocatorIs(CreateServiceLocator())
                .Load(Arc.Infrastructure.Logging.Log4Net.LoggingConfiguration.Default());

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ILogger>(), Is.Not.Null);
        }

        [Test]
        public void Should_configure_validation_provider()
        {
            Application.ServiceLocatorIs(CreateServiceLocator())
                .Load(ValidationConfiguration.Default());

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IValidationService>(), Is.Not.Null);
        }

        [Test]
        public void Should_load_convention_to_service_provider()
        {
            Application.ServiceLocatorIs(CreateServiceLocator())
                .Apply(new RegisterServicesConvention());

            Assert.That(ServiceLocator.Resolve<IService>(), Is.Not.Null);
        }

        [Test]
        //[Ignore("Cannot create connection to database without mappings")]
        public void Should_configure_data_access()
        {
            Application.ServiceLocatorIs(CreateServiceLocator())
                .Load(
                    DataConfiguration.Default(BuildNHibernateConfiguration()),
                    LoggingIsNotUsedConfiguration.Default(),
                    ValidationIsNotUsedConfiguration.Default()
                );

            Assert.That(ServiceLocator.Resolve<INHibernateConfiguration>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IUnitOfWorkFactory>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ISessionFactory>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IUnitOfWork>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<INHibernateRepository<DomainEntity>>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IRepository<DomainEntity>>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IRepository>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<INHibernateRepository<DomainEntity>>(), Is.Not.Null);
        }
        
        private FluentConfiguration BuildNHibernateConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(c => 
                        c.Server("(local)").Database("").TrustedConnection())
                )
                .Mappings(
                    x => x.AutoMappings.Add(AutoMap.AssemblyOf<FakeEntity>().Where(y => y.Name == ""))
                );
        }

        [Test]
        public void Should_configure_registries()
        {
            Application.ServiceLocatorIs(CreateServiceLocator())
                .Load(RegistryConfiguration.Default());

            Assert.That(ServiceLocator.Resolve<IHybridRegistry>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IThreadRegistry>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ILocalRegistry>(), Is.Not.Null);
        }
    }
}