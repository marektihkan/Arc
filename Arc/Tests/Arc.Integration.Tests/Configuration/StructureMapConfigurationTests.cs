using Arc.Infrastructure.Dependencies;
using NUnit.Framework;

namespace Arc.Integration.Tests.Configuration
{
    [TestFixture]
    public class StructureMapConfigurationTests : BaseConfigurationTests
    {
        public override IServiceLocator CreateServiceLocator()
        {
            return new Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator();
        }
    }
}