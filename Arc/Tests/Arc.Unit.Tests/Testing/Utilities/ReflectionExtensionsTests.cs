using System;
using Arc.Testing.Utilities;
using Arc.Unit.Tests.Fakes;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Testing.Utilities
{
    [TestFixture]
    public class ReflectionExtensionsTests
    {
        private const int ExpectedValue = 1;

        [Test]
        public void Should_set_field_value()
        {
            var target = new DummyReflection();

            target.SetValueTo("_field", ExpectedValue);

            Assert.That(target.FieldValue, Is.EqualTo(ExpectedValue));
        }

        [Test]
        public void Should_set_property_value()
        {
            var target = new DummyReflection();

            target.SetValueTo("Property", ExpectedValue);

            Assert.That(target.PropertyValue, Is.EqualTo(ExpectedValue));
        }

        [Test]
        public void Should_get_field_value()
        {
            var target = new DummyReflection();

            target.SetValueTo("_field", ExpectedValue);
            var actual = target.GetValueOf<int>("_field");

            Assert.That(actual, Is.EqualTo(ExpectedValue));
        }

        [Test]
        public void Should_get_property_value()
        {
            var target = new DummyReflection();

            target.SetValueTo("Property", ExpectedValue);
            var actual = target.GetValueOf<int>("Property");

            Assert.That(actual, Is.EqualTo(ExpectedValue));
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Should_throw_exception_when_name_is_empty()
        {
            var target = new DummyReflection();

            target.SetValueTo(string.Empty, ExpectedValue);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Should_throw_exception_when_property_or_field_is_not_found()
        {
            var target = new DummyReflection();

            target.SetValueTo("1", ExpectedValue);
        }

    }
}