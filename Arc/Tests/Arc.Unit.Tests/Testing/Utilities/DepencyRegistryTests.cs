using Arc.Testing.Utilities;
using Arc.Unit.Tests.Fakes.Entities;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Testing.Utilities
{
    [TestFixture]
    public class DepencyRegistryTests
    {

        private IDependencyRegistry CreateSUT()
        {
            return new DependencyRegistry();
        }

        [Test]
        public void Should_register_value_to_registry()
        {
            var target = CreateSUT();
            var expected = new ServiceImpl();

            target.Register<IService>(expected);
            var actual = target.Get<IService>();

            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void Should_get_default_value_when_its_not_in_registry()
        {
            var target = CreateSUT();

            var actual = target.Get<IService>();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Should_overwrite_value_when_its_already_in_registry()
        {
            var target = CreateSUT();

            var expected = new ServiceImpl();

            target.Register<IService>(new ServiceImpl());
            target.Register<IService>(expected);
            var actual = target.Get<IService>();

            Assert.That(actual, Is.SameAs(expected));
        }
    }
}