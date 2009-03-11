using System;
using Arc.Domain.Dsl;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Domain.Dsl
{
    [TestFixture]
    public class ParseTests
    {
        [Test]
        public void Should_parse_integer()
        {
            Assert.That(Parse.Integer("1").Value, Is.EqualTo(1));
        }

        [Test]
        public void Should_get_default_value_when_parsing_integer_fails()
        {
            var defaultValue = 2;
            Assert.That(Parse.Integer("x1").Default(defaultValue).Value, Is.EqualTo(defaultValue));
        }

        [Test]
        public void Should_get_default_integer_value_when_default_is_not_set_and_parsing_integer_fails()
        {
            Assert.That(Parse.Integer("x1").Value, Is.EqualTo(default(int)));
        }


        [Test]
        public void Should_parse_decimal()
        {
            Assert.That(Parse.Decimal("1").Value, Is.EqualTo(1m));
        }

        [Test]
        public void Should_get_default_value_when_parsing_decimal_fails()
        {
            var defaultValue = 2m;
            Assert.That(Parse.Decimal("x1").Default(defaultValue).Value, Is.EqualTo(defaultValue));
        }

        [Test]
        public void Should_get_default_decimal_value_when_default_is_not_set_and_parsing_decimal_fails()
        {
            Assert.That(Parse.Integer("x1").Value, Is.EqualTo(default(decimal)));
        }


        [Test]
        public void Should_parse_date_time()
        {
            var expected = DateTime.Parse("2009-02-03 12:58:23");
            Assert.That(Parse.DateTime(expected.ToString()).Value, Is.EqualTo(expected));
        }

        [Test]
        public void Should_get_default_value_when_parsing_date_time_fails()
        {
            var defaultValue = DateTime.Now.AddDays(-1);
            Assert.That(Parse.DateTime("x").Default(defaultValue).Value, Is.EqualTo(defaultValue));
        }

        [Test]
        public void Should_get_default_date_time_value_when_default_is_not_set_and_parsing_date_time_fails()
        {
            Assert.That(Parse.DateTime("x").Value, Is.EqualTo(default(DateTime)));
        }
    }
}