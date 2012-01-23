using System.Linq;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Integration.Tests.Fakes.DependencyInjection;
using Arc.Integration.Tests.Fakes.Model.Services;
using NUnit.Framework;
using Rhino.Mocks;
using IService = Arc.Integration.Tests.Fakes.Model.Services.IService;
using ServiceImpl = Arc.Integration.Tests.Fakes.Model.Services.ServiceImpl;
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

            target.Load(new DependencyConfiguration());

            var actual = target.Resolve<IGenericServiceHost>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Service, Is.Not.Null);
        }

        [Test]
        public void Should_register_service_with_generics()
        {
            var target = CreateSUT();

            target.Register(Requested.Service<IParameterlessService>().IsImplementedBy<ParameterlessServiceImpl>());

            var actual = target.Resolve<IParameterlessService>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOf<ParameterlessServiceImpl>());
        }

        [Test]
        public void Should_register_service_without_generics()
        {
            var target = CreateSUT();

            target.Register(Requested.Service(typeof(IParameterlessService)).IsImplementedBy(typeof(ParameterlessServiceImpl)));

            var actual = target.Resolve<IParameterlessService>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOf<ParameterlessServiceImpl>());
        }

        [Test]
        public void Should_register_service_with_singleton_lifestyle()
        {
            var target = CreateSUT();

            target.Register(
                Requested.Service<IParameterlessService>()
                    .IsImplementedBy<ParameterlessServiceImpl>()
                    .LifeStyle.IsSingelton()
                );

            var first = target.Resolve<IParameterlessService>();
            var second = target.Resolve<IParameterlessService>();

            Assert.That(first, Is.Not.Null);
            Assert.That(first, Is.SameAs(second));
        }

        [Test]
        public void Should_register_service_with_transient_lifestyle()
        {
            var target = CreateSUT();

            target.Register(
                Requested.Service<IParameterlessService>()
                    .IsImplementedBy<ParameterlessServiceImpl>()
                    .LifeStyle.IsTransient()
                );

            var first = target.Resolve<IParameterlessService>();
            var second = target.Resolve<IParameterlessService>();

            Assert.That(first, Is.Not.Null);
            Assert.That(first, Is.Not.SameAs(second));
        }

        [Test]
        public void Should_register_service_dependency_to_factory_method()
        {
            var target = CreateSUT();

            target.Register(
                Requested.Service<IServiceFactory>()
                    .IsImplementedBy<ServiceFactoryImpl>(),

                Requested.Service<IParameterlessService>()
                    .IsConstructedBy(x => x.Resolve<IServiceFactory>().Create())
                );

            var actual = target.Resolve<IParameterlessService>();
            
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void Should_register_service_to_factory_method()
        {
            var target = CreateSUT();

            target.Register(
                Requested.Service<IServiceFactory>()
                    .IsConstructedBy(x => new ServiceFactoryImpl { Name = "Constructed" })
                );

            var actual = target.Resolve<IServiceFactory>();

            Assert.That(actual.Name, Is.EqualTo("Constructed"));
        }

        [Test]
        public void Should_resolve_service_with_dependency_from_factory_method()
        {
            var target = CreateSUT();

            target.Register(
                Requested.Service<IServiceFactory>()
                    .IsImplementedBy<ServiceFactoryImpl>(),

                Requested.Service<IParameterlessService>()
                    .IsConstructedBy(x => x.Resolve<IServiceFactory>().Create()),

                Requested.Service<IService>()
                    .IsImplementedBy<ServiceImpl>()
                );

            var actual = target.Resolve<IService>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Dependency, Is.Not.Null);
        }

        [Test]
        public void Should_register_to_factory_method_with_singleton_scope()
        {
            var target = CreateSUT();

            target.Register(
                Requested.Service<IServiceFactory>()
                    .IsImplementedBy<ServiceFactoryImpl>(),

                Requested.Service<IParameterlessService>()
                    .IsConstructedBy(x => x.Resolve<IServiceFactory>().Create())
                    .LifeStyle.IsSingelton()
                );

            var first = target.Resolve<IParameterlessService>();
            var second = target.Resolve<IParameterlessService>();

            Assert.That(first, Is.Not.Null);
            Assert.That(second, Is.Not.Null);
            Assert.That(first, Is.SameAs(second));
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
        public void Should_resolve_service()
        {
            var target = CreateSUT();

            target.Load(new DependencyConfiguration());

            Assert.That(target.Resolve<IService>(), Is.TypeOf(typeof(ServiceImpl)));
        }

        [Test]
        public void Should_resolve_service_with_parameter()
        {
            var target = CreateSUT();

            target.Load(new DependencyConfiguration());
            var dependency = MockRepository.GenerateMock<IParameterlessService>();

            var actual = target.Resolve<IService>(With.Parameters.ConstructorArgument("dependency", dependency));

            Assert.That(actual, Is.TypeOf(typeof(ServiceImpl)));
            Assert.That(actual.Dependency, Is.SameAs(dependency));
        }

    	[Test]
    	public void It_should_resolve_all_service_implementations()
    	{
    		var target = CreateSUT();

			target.Load(new DependencyConfiguration());

    		var actual = target.ResolveAll<IHandler<string>>();

    		Assert.That(actual.First(), Is.TypeOf<PreHandler>());
    		Assert.That(actual.Last(), Is.TypeOf<PostHandler>());
    	}
    }
}