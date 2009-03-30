using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Logging;
using Arc.Infrastructure.Logging.Log4Net;
using Arc.Infrastructure.Validation;
using Arc.Infrastructure.Validation.EnterpriseLibrary;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Arc.Integration.Tests.Fakes.Model.Services;
using Arc.Integration.Tests.Fakes.Validation;
using log4net;
using NHibernate;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Integration.Tests.Configuration
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void Should_configure_service_locator_provider()
        {
            Configure.
                ServiceLocator.ProviderTo<Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator>()
                    .With(new DependencyConfiguration());

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
        }

        [Test]
		[Ignore("Logging manager is needed")]
        public void Should_configure_logging_provider()
        {
            Configure.
                ServiceLocator.ProviderTo<Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator>()
                    .With(new DependencyConfiguration())
                .And.Logging.ProviderTo<Logger>().WithLogNamed("Test Log")
                .And.Validation.IsNotUsed();

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ILogger>(), Is.Not.Null);
        }

        [Test]
        public void Should_configure_validation_provider()
        {
            Configure.
                ServiceLocator.ProviderTo<Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator>()
                    .With(new DependencyConfiguration())
                .And.Logging.IsNotUsed()
                .And.Validation.ProviderTo<ValidationService>();

            Assert.That(ServiceLocator.InnerServiceLocator, Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IValidationService>(), Is.Not.Null);
        }

        [Test]
        public void Should_load_convention_to_service_provider()
        {
            Configure.
                ServiceLocator.ProviderTo<Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator>()
                    .With(new RegisterServicesConvention());

            Assert.That(ServiceLocator.Resolve<IService>(), Is.Not.Null);
        }

        [Test]
        [Ignore("Different module is needed.")]
        public void Should_configure_data_access()
        {
            Bootstrapper.ConfigureData();
            Bootstrapper.ConfigureValidation();

            ServiceLocator.Configuration.Load(DataTestConfiguration.FullName);


            Assert.That(ServiceLocator.Resolve<NHibernate.Cfg.Configuration>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IUnitOfWorkFactory>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ISessionFactory>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IUnitOfWork>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IRepository<DomainEntity>>(), Is.Not.Null);
        }
    }
}