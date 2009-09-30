using Arc.Infrastructure.Dependencies;
using NUnit.Framework;

namespace Arc.Integration.Tests.Infrastructure.Dependencies
{
    [TestFixture]
    public class StructureMapServiceLocatorTests : BaseServiceLocatorTests
    {
        public override IServiceLocator CreateSUT()
        {
            return new Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator();
        }

    }
}