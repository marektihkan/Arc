using System;
using Arc.Infrastructure.Utilities;
using Arc.Unit.Tests.Fakes.Entities;
using NUnit.Framework;

namespace Arc.Unit.Tests.Infrastructure.Utilities
{
    [TestFixture]
    public class ResolveProviderTests
    {
        private const string ValidServiceProviderTypeName = "Arc.Unit.Tests.Fakes.Entities.ServiceImpl, Arc.Unit.Tests";
        private const string InvalidServiceProviderTypeName = "Arc.Unit.Tests.Fakes.Entities.Service, Arc.Unit.Tests";
        private const string ProviderTypeWithoutInterfaceName = "Arc.Unit.Tests.Fakes.Entities.Person, Arc.Unit.Tests";

        [Test]
        public void Should_resolve_provider_by_name()
        {
            var actual = ResolveProvider<IService>.Named(ValidServiceProviderTypeName);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOfType(typeof (IService)));
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Should_throw_argument_exception_when_provider_is_not_found_by_name()
        {
            ResolveProvider<IService>.Named(InvalidServiceProviderTypeName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_argument_exception_when_provider_is_not_implementing_interface_on_resolving_by_name()
        {
            ResolveProvider<IService>.Named(ProviderTypeWithoutInterfaceName);
        }

        [Test]
        public void Should_resolve_provider_by_type()
        {
            var actual = ResolveProvider<IService>.WithRealType(typeof(ServiceImpl));

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOfType(typeof(IService)));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_argument_exception_when_provider_is_not_implementing_interface_on_resolving_by_type()
        {
            ResolveProvider<IService>.WithRealType(typeof(Person));
        }

    }
}