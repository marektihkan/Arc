using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies;
using NUnit.Framework;

namespace Arc.Integration.Tests.Infrastructure.Validation
{
    [TestFixture]
    public class EnterpriseLibraryTests : ValidationServiceTests
    {
        protected override IConfiguration<IServiceLocator> GetConfiguration()
        {
            return new Arc.Infrastructure.Validation.EnterpriseLibrary.ValidationConfiguration();
        }
    }
}