using Arc.Infrastructure.Dependencies;
using NUnit.Framework;

namespace Arc.Integration.Tests.Configuration
{
    [TestFixture]
    public class CastleWindsorConfigurationTests : BaseConfigurationTests
    {
        public override IServiceLocator CreateServiceLocator()
        {
            return new Arc.Infrastructure.Dependencies.CastleWindsor.ServiceLocator();
        }
    }
}