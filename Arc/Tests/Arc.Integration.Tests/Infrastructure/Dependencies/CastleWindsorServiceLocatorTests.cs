using Arc.Infrastructure.Dependencies;
using Arc.Integration.Tests.Fakes.Model.Services;
using Castle.Windsor;
using NUnit.Framework;
using Rhino.Mocks;

namespace Arc.Integration.Tests.Infrastructure.Dependencies
{
    [TestFixture]
    public class CastleWindsorServiceLocatorTests : BaseServiceLocatorTests
    {
        public override IServiceLocator CreateSUT()
        {
            return new Arc.Infrastructure.Dependencies.CastleWindsor.ServiceLocator();
        }

        private IServiceLocator CreateSUT(IWindsorContainer container)
        {
            return new Arc.Infrastructure.Dependencies.CastleWindsor.ServiceLocator(container);
        }

        
        [Test]
        public void Should_release_service()
        {
            var kernel = MockRepository.GenerateMock<IWindsorContainer>();
            var service = MockRepository.GenerateStub<IService>();

            CreateSUT(kernel).Release(service);

            kernel.AssertWasCalled(x => x.Release(service));
        }

        [Test]
        public void Should_dispose_service_locator()
        {
            var kernel = MockRepository.GenerateMock<IWindsorContainer>();

            var target = CreateSUT(kernel);
            target.Dispose();

            kernel.AssertWasCalled(x => x.Dispose());
        }


    }
}