using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Logging;
using Arc.Infrastructure.Validation;
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
        public void Should_configure_data_access()
        {
            Bootstrapper.ConfigureData();
            Bootstrapper.ConfigureValidation();
            ServiceLocator.Load(DataTestConfiguration.FullName);


            Assert.That(ServiceLocator.Resolve<NHibernate.Cfg.Configuration>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IUnitOfWorkFactory>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ISessionFactory>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IUnitOfWork>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<IRepository<DomainEntity>>(), Is.Not.Null);
        }

        [Test]
        public void Should_configure_validation()
        {
            Bootstrapper.ConfigureValidation();

            Assert.That(ServiceLocator.Resolve<IValidationService>(), Is.Not.Null);
        }

        [Test]
        public void Should_configure_logging()
        {
            Bootstrapper.ConfigureLogging();

            Assert.That(ServiceLocator.Resolve<ILog>(), Is.Not.Null);
            Assert.That(ServiceLocator.Resolve<ILogger>(), Is.Not.Null);
        }
    }
}