using System;
using Arc.Infrastructure.Dependencies;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Ninject.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace Arc.Integration.Tests.Infrastructure.Dependencies
{
    [TestFixture]
    public class ServiceLocatorTests
    {
        private IServiceLocator CreateSUT()
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
        public void Should_be_configured_via_dependency_configuration()
        {
            var target = CreateSUT();

            target.Load(new DependencyConfiguration());

            var actual = target.Resolve<IParameterlessService>();

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void Should_register_service()
        {
            var target = CreateSUT();

            target.Register<IParameterlessService, ParameterlessServiceImpl>();

            var actual = target.Resolve<IParameterlessService>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOfType(typeof (ParameterlessServiceImpl)));
        }

        [Test]
        public void Should_register_service_with_scope()
        {
            var target = CreateSUT();

            target.Register<IParameterlessService, ParameterlessServiceImpl>(ServiceLocator.Scopes.Singleton);

            var actual = target.Resolve<IParameterlessService>();

            Assert.That(actual, Is.SameAs(target.Resolve<IParameterlessService>()));
        }

        [Test]
        public void Should_resolve_service()
        {
            var target = CreateSUT();

            target.Load(ConfigurationModule.ValidModuleName);

            Assert.That(target.Resolve<IParameterlessService>(), Is.TypeOf(typeof(ParameterlessServiceImpl)));
        }

        [Test]
        public void Should_resolve_service_with_parameter()
        {
            var target = CreateSUT();

            target.Load(ConfigurationModule.ValidModuleName);
            var dependency = MockRepository.GenerateMock<IParameterlessService>();
            
            var actual = target.ResolveWith<IService>("dependency", dependency);

            Assert.That(actual, Is.TypeOf(typeof(ServiceImpl)));
            Assert.That(actual.Dependency, Is.SameAs(dependency));
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