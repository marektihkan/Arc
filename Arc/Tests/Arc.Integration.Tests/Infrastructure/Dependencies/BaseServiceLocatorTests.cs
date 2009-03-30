using Arc.Infrastructure.Dependencies;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Arc.Integration.Tests.Fakes.Model.Services;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using With=Arc.Infrastructure.Dependencies.With;

namespace Arc.Integration.Tests.Infrastructure.Dependencies
{
    public abstract class BaseServiceLocatorTests
    {
        public abstract IServiceLocator CreateSUT();

        [Test]
        public void Should_register_generic_types_without_generic_arguments()
        {
            var target = CreateSUT();

            target.Configuration.Load(new DependencyConfiguration());

            var actual = target.Resolve<IGenericServiceHost>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Service, Is.Not.Null);
        }

        [Test]
        public void Should_register_service()
        {
            var target = CreateSUT();

            target.Configuration.Register<IParameterlessService, ParameterlessServiceImpl>();

            var actual = target.Resolve<IParameterlessService>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOfType(typeof(ParameterlessServiceImpl)));
        }

        [Test]
        public void Should_be_configured_via_dependency_configuration()
        {
            var target = CreateSUT();

            target.Configuration.Load(new DependencyConfiguration());

            var actual = target.Resolve<IParameterlessService>();

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void Should_register_service_with_scope()
        {
            var target = CreateSUT();

            target.Configuration.Register<IParameterlessService, ParameterlessServiceImpl>(target.Scopes.Singleton);

            var actual = target.Resolve<IParameterlessService>();

            Assert.That(actual, Is.SameAs(target.Resolve<IParameterlessService>()));
        }

        [Test]
        public void Should_resolve_service()
        {
            var target = CreateSUT();

            target.Configuration.Load(new DependencyConfiguration());

            Assert.That(target.Resolve<IService>(), Is.TypeOf(typeof(ServiceImpl)));
        }

        [Test]
        public void Should_resolve_service_with_parameter()
        {
            var target = CreateSUT();

            target.Configuration.Load(new DependencyConfiguration());
            var dependency = MockRepository.GenerateMock<IParameterlessService>();

            var actual = target.Resolve<IService>(With.Parameters.ConstructorArgument("dependency", dependency));

            Assert.That(actual, Is.TypeOf(typeof(ServiceImpl)));
            Assert.That(actual.Dependency, Is.SameAs(dependency));
        }
    }
}