using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Dependencies;
using Arc.Learning.Tests.Fakes.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NUnit.Framework;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class Bugs
    {
        [Test]
        [Ignore("Cannot create connection to database without mappings")]
        public void Should_configure_data_access_and_session_should_be_in_repository()
        {
            Application.ServiceLocatorIs(CreateServiceLocator())
                .Load(
                    DataConfiguration.Default(BuildNHibernateConfiguration()),
                    LoggingIsNotUsedConfiguration.Default(),
                    ValidationIsNotUsedConfiguration.Default());

            var actual = ServiceLocator.Resolve<INHibernateRepository>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Session, Is.Not.Null);
        }

        private IServiceLocator CreateServiceLocator()
        {
            return new Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator();
        }

        private FluentConfiguration BuildNHibernateConfiguration()
        {
            return Fluently.Configure()
            .Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(c =>
                        c.Server("local").Database("").TrustedConnection())
                );
        }
    }
}