using System;
using Arc.Domain.Specifications;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Data.NHibernate.Specifications;
using Arc.Infrastructure.Dependencies;
using Arc.Learning.Tests.Fakes.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class Bugs
    {
        [Test]
        public void Should_configure_data_access_and_session_should_be_in_repository()
        {
            Configure.ServiceLocator.ProviderTo(CreateServiceLocator())
                .With<DataConfiguration>()
                .With<LoggingIsNotUsedConfiguration>()
                .With<ValidationIsNotUsedConfiguration>();

            var actual = ServiceLocator.Resolve<INHibernateRepository<DomainEntity>>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Session, Is.Not.Null);
        }

        private IServiceLocator CreateServiceLocator()
        {
            return new Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator();
        }
    }
}