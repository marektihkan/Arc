using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Validation.NHibernateValidator;
using NUnit.Framework;

namespace Arc.Integration.Tests.Infrastructure.Validation
{
    [TestFixture]
    [Ignore("Could not load file or assembly 'Iesi.Collections, Version=1.0.0.3")]
    public class NHibernateValidatorTests : ValidationServiceTests
    {
        protected override IConfiguration<IServiceLocator> GetConfiguration()
        {
            return new ValidationConfiguration(new NHibernate.Validator.Cfg.NHVConfiguration());
        }
    }
}