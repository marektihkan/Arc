using Arc.Infrastructure.Dependencies;
using NUnit.Framework;

namespace Arc.Integration.Tests.Infrastructure.Validation
{
    [TestFixture]
    public class EnterpriseLibraryTests : ValidationServiceTests
    {
        protected override IServiceLocatorModule<IServiceLocator> GetConfiguration()
        {
            return new Arc.Infrastructure.Validation.EnterpriseLibrary.ValidationConfiguration();
        }
    }
}