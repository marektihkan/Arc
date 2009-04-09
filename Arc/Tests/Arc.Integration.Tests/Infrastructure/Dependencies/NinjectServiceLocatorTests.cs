using System;
using Arc.Infrastructure.Dependencies;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Arc.Integration.Tests.Fakes.Model.Services;
using Ninject.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using With=Arc.Infrastructure.Dependencies.With;

namespace Arc.Integration.Tests.Infrastructure.Dependencies
{
    [TestFixture]
    public class NinjectServiceLocatorTests : BaseServiceLocatorTests
    {
        public override IServiceLocator CreateSUT()
        {
            return new Arc.Infrastructure.Dependencies.Ninject.ServiceLocator();
        }

        private IServiceLocator CreateSUT(IKernel kernel)
        {
            return new Arc.Infrastructure.Dependencies.Ninject.ServiceLocator(kernel);
        }


        [Test]
        public void Should_load_Ninject_configuration_modules()
        {
            var target = CreateSUT();

            target.Load(ConfigurationModule.ValidModuleName);
        }

        [Test]
        public void Should_load_multiple_configuration_modules()
        {
            var target = CreateSUT();

            target.Load(ConfigurationModule.ValidModuleName, ConfigurationModule.ValidModuleName);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Should_throw_argument_exception_when_module_is_not_found_on_loading()
        {
            var target = CreateSUT();

            target.Load(ConfigurationModule.InvalidModuleName);
        }

        [Test]
        public void Should_release_service()
        {
            var kernel = MockRepository.GenerateMock<IKernel>();
            var service = MockRepository.GenerateStub<IService>();

            CreateSUT(kernel).Release(service);

            kernel.AssertWasCalled(x => x.Release(service));
        }

        [Test]
        public void Should_dispose_service_locator()
        {
            var kernel = MockRepository.GenerateMock<IKernel>();

            var target = CreateSUT(kernel);
            target.Dispose();

            kernel.AssertWasCalled(x => x.Dispose());
        }
    }
}