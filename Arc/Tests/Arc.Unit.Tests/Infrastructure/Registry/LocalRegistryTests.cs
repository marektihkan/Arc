using Arc.Infrastructure.Registry;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Infrastructure.Registry
{
    [TestFixture]
    public class LocalRegistryTests
    {

        private IRegistry CreateSUT()
        {
            return new LocalRegistry();
        }


        [Test]
        public void Should_register_object()
        {
            var target = CreateSUT();

            target.Register("Integer", 1);

            Assert.That(target.Get<int>("Integer"), Is.EqualTo(1));
        }

        [Test]
        public void Should_resolve_object()
        {
            var target = CreateSUT();

            target.Register("Integer", 1);

            Assert.That(target.Get<int>("Integer"), Is.EqualTo(1));
        }

        [Test]
        public void Should_unregister_object()
        {
            var target = CreateSUT();

            target.Register("Integer", 1);
            var actual = target.Unregister<int>("Integer");

            Assert.That(actual, Is.EqualTo(1));
        }

        [Test]
        public void Should_get_null_when_object_is_not_in_registry()
        {
            var target = CreateSUT();

            Assert.That(target.Get<object>("Integer"), Is.Null);
        }

        [Test]
        public void Should_get_default_value_object_when_its_not_in_registry()
        {
            var target = CreateSUT();

            Assert.That(target.Get<int>("Integer"), Is.EqualTo(default(int)));
        }
    }
}