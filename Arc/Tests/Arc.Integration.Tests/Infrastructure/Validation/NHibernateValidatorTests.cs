using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Validation.NHibernateValidator;
using NUnit.Framework;

namespace Arc.Integration.Tests.Infrastructure.Validation
{
    [TestFixture]
    public class NHibernateValidatorTests : ValidationServiceTests
    {
        protected override IServiceLocatorModule<IServiceLocator> GetConfiguration()
        {
            return new ValidationConfiguration(new NHibernate.Validator.Cfg.NHVConfiguration());
        }
    }
}