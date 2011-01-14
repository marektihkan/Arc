using Arc.Domain.Dsl;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Dsl
{
    [TestFixture]
    public class NullTests
    {

        [Test]
        public void Should_check_object_value()
        {
            const object nullTarget = null;
            var notNullTarget = new object();

            Assert.That(nullTarget.IsNull(), Is.True);
            Assert.That(notNullTarget.IsNull(), Is.False);
        }

        [Test]
        public void Should_check_string_value()
        {
            const string nullTarget = null;
            var emptyTarget = string.Empty;
            const string notNullTarget = "a";

            Assert.That(nullTarget.IsNull(), Is.True);
            Assert.That(emptyTarget.IsNull(), Is.True);
            Assert.That(notNullTarget.IsNull(), Is.False);
        }

        [Test]
        public void Should_check_nullable_value()
        {
            int? nullTarget = null;
            int? notNullTarget = 1;

            Assert.That(nullTarget.IsNull(), Is.True);
            Assert.That(notNullTarget.IsNull(), Is.False);
        }

    }
}