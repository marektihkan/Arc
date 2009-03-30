using Arc.Infrastructure.Dependencies;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Arc.Integration.Tests.Fakes.Model.Services;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using With=Arc.Infrastructure.Dependencies.With;

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