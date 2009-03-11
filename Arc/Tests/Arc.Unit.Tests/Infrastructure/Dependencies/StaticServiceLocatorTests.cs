using Arc.Domain.Identity;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Dependencies;
using Arc.Unit.Tests.Fakes.Data;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Infrastructure.Dependencies
{
    [TestFixture]
    public class StaticServiceLocatorTests
    {
        private IServiceLocator _locator;

        [SetUp]
        public void SetUp()
        {
            _locator = MockRepository.GenerateMock<IServiceLocator>();
            ServiceLocator.InnerServiceLocator = _locator;
        }

        [Test]
        public void Should_delegate_load_with_dependency_configuration()
        {
            var configuration = MockRepository.GenerateStub<IDependencyConfiguration>();

            ServiceLocator.Load(configuration);

            _locator.AssertWasCalled(x => x.Load(configuration));
        }

        [Test]
        public void Should_delegate_load_with_module_name()
        {
            var moduleName = string.Empty;

            ServiceLocator.Load(moduleName);

            _locator.AssertWasCalled(x => x.Load(moduleName));
        }

        [Test]
        public void Should_delegate_load_with_module_names()
        {
            var moduleNames = new [] { string.Empty, string.Empty };

            ServiceLocator.Load(moduleNames);

            _locator.AssertWasCalled(x => x.Load(moduleNames));
        }

        [Test]
        public void Should_delegate_register_with_generics()
        {
            ServiceLocator.Register<IRepository<IEntity>, Repository<IEntity>>();

            _locator.AssertWasCalled(x => x.Register<IRepository<IEntity>, Repository<IEntity>>());
        }

        [Test]
        public void Should_delegate_register_with_generics_and_scope()
        {
            var scope = MockRepository.GenerateStub<IScope>();
            ServiceLocator.Register<IRepository<IEntity>, Repository<IEntity>>(scope);

            _locator.AssertWasCalled(x => x.Register<IRepository<IEntity>, Repository<IEntity>>(scope));
        }

        [Test]
        public void Should_delegate_register()
        {
            ServiceLocator.Register(typeof(IRepository<IEntity>), typeof(Repository<IEntity>));

            _locator.AssertWasCalled(x => x.Register(typeof(IRepository<IEntity>), typeof(Repository<IEntity>)));
        }

        [Test]
        public void Should_delegate_register_with_scope()
        {
            var scope = MockRepository.GenerateStub<IScope>();
            ServiceLocator.Register(typeof(IRepository<IEntity>), typeof(Repository<IEntity>), scope);

            _locator.AssertWasCalled(x => x.Register(typeof(IRepository<IEntity>), typeof(Repository<IEntity>), scope));
        }

        [Test]
        public void Should_delegate_resolve_with_generics()
        {
            ServiceLocator.Resolve<IRepository<IEntity>>();

            _locator.AssertWasCalled(x => x.Resolve<IRepository<IEntity>>());
        }

        [Test]
        public void Should_delegate_resolve()
        {
            ServiceLocator.Resolve(typeof(IRepository<IEntity>));

            _locator.AssertWasCalled(x => x.Resolve(typeof(IRepository<IEntity>)));
        }

        [Test]
        public void Should_delegate_resolve_with_parameters_with_generics()
        {
            var dependencyName = "name";
            var dependencyValue = new object();

            ServiceLocator.ResolveWith<IRepository>(dependencyName, dependencyValue);

            _locator.AssertWasCalled(x => x.ResolveWith<IRepository>(dependencyName, dependencyValue));
        }

        [Test]
        public void Should_delegate_resolve_with_parameters()
        {
            var dependencyName = "name";
            var dependencyValue = new object();

            ServiceLocator.ResolveWith(typeof(IRepository), dependencyName, dependencyValue);

            _locator.AssertWasCalled(x => x.ResolveWith(typeof(IRepository), dependencyName, dependencyValue));
        }

        [Test]
        public void Should_delegate_release()
        {
            var releasable = new object();

            ServiceLocator.Release(releasable);

            _locator.AssertWasCalled(x => x.Release(releasable));
        }

        [Test]
        public void Should_delegate_scope_factory()
        {
            var scopeFactory = MockRepository.GenerateStub<IScopeFactory>();
            
            _locator.Stub(x => x.Scopes).Return(scopeFactory);

            var actual = ServiceLocator.Scopes;

            Assert.That(actual, Is.SameAs(scopeFactory));
        }
    }
}