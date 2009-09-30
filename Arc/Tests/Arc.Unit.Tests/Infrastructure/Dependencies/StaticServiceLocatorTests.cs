using Arc.Domain.Identity;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Unit.Tests.Fakes.Data;
using NUnit.Framework;
using Rhino.Mocks;
using With=Arc.Infrastructure.Dependencies.With;

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
            var configuration = MockRepository.GenerateStub<IServiceLocatorModule<IServiceLocator>>();

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
        public void Should_delegate_register()
        {
            var registrations = Requested.Service<IRepository<IEntity>>().IsImplementedBy<Repository<IEntity>>();
            ServiceLocator.Register(registrations);

            _locator.AssertWasCalled(x => x.Register(registrations));
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
        public void Should_delegate_resolve_with_generics_and_parameters()
        {
            var parameters = With.Parameters.ConstructorArgument(string.Empty, null);
            ServiceLocator.Resolve<IRepository<IEntity>>(parameters);

            _locator.AssertWasCalled(x => x.Resolve<IRepository<IEntity>>(parameters));
        }

        [Test]
        public void Should_delegate_resolve_with_parameters()
        {
            var parameters = With.Parameters.ConstructorArgument(string.Empty, null);
            ServiceLocator.Resolve(typeof(IRepository<IEntity>), parameters);

            _locator.AssertWasCalled(x => x.Resolve(typeof(IRepository<IEntity>), parameters));
        }

        [Test]
        public void Should_delegate_release()
        {
            var releasable = new object();

            ServiceLocator.Release(releasable);

            _locator.AssertWasCalled(x => x.Release(releasable));
        }
    }
}