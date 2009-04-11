using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Integration.Tests.Fakes.Model.Services;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using ServiceLocator=Arc.Infrastructure.Dependencies.Ninject.ServiceLocator;

namespace Arc.Integration.Tests.Infrastructure.Dependencies
{
    [TestFixture]
    public class AutoRegistrationTests
    {
        private IServiceLocator _serviceLocator;

        [Test]
        public void Picking_example()
        {
            var configuration = AutoRegistration.For("Arc.Integration.Tests")
                .Pick(x => x.Namespace.Contains("Arc.Integration.Tests.Fakes"))
                .BindToFirstInterface();

            SetupConfiguration(configuration);
            Assert.That(_serviceLocator.Resolve<IService>(), Is.Not.Null);
        }

        [Test]
        public void For_all_types_example()
        {
            var configuration = AutoRegistration.For("Arc.Integration.Tests")
                .AllConcreteTypes
                .BindToFirstInterface();

            SetupConfiguration(configuration);
            Assert.That(_serviceLocator.Resolve<IService>(), Is.Not.Null);
        }

        [Test]
        public void Picking_binding_interface_example()
        {
            var configuration = AutoRegistration.For("Arc.Integration.Tests")
                .AllConcreteTypes
                .BindToInterface(x => x.Name.Contains("Service"));

            SetupConfiguration(configuration);
            Assert.That(_serviceLocator.Resolve<IService>(), Is.Not.Null);
        }

        [Test]
        public void Binding_to_self_example()
        {
            var configuration = AutoRegistration.For("Arc.Integration.Tests")
                .AllConcreteTypes
                .BindToSelf();

            SetupConfiguration(configuration);
            Assert.That(_serviceLocator.Resolve<ParameterlessServiceImpl>(), Is.Not.Null);
        }

        [Test]
        public void Should_bind_all_types_with_singleton_scope()
        {
            var configuration = AutoRegistration.For("Arc.Integration.Tests")
                .AllConcreteTypes
                .BindToFirstInterface()
                .Using(ServiceLifeStyle.Singleton);

            SetupConfiguration(configuration);
            var first = _serviceLocator.Resolve<IService>();
            var second = _serviceLocator.Resolve<IService>();
            
            Assert.That(first, Is.Not.Null);
            Assert.That(first, Is.SameAs(second));
        }

        private void SetupConfiguration(IServiceLocatorModule<IServiceLocator> configuration)
        {
            _serviceLocator = new ServiceLocator();
            _serviceLocator.Load(configuration);
        }
    }
}