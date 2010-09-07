using NUnit.Framework;
using Arc.Domain.Units;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class UnitExtensionsTests
    {
        [Test]
        public void Should_create_money_from_decimal()
        {
            var actual = 1.5m.AsMoney();
            Assert.That(actual.Amount, Is.EqualTo(1.5m));
        }

        [Test]
        public void Should_create_money_from_decimal_with_currency()
        {
            var actual = 1.5m.InCurrency(Currency.EUR);
            Assert.That(actual.Amount, Is.EqualTo(1.5m));
            Assert.That(actual.Currency, Is.EqualTo(Currency.EUR));
        }

        [Test]
        public void Should_create_money_from_integer()
        {
            var actual = 1.AsMoney();
            Assert.That(actual.Amount, Is.EqualTo(1));
        }

        [Test]
        public void Should_create_money_from_integer_with_currency()
        {
            var actual = 1.InCurrency(Currency.EUR);
            Assert.That(actual.Amount, Is.EqualTo(1));
            Assert.That(actual.Currency, Is.EqualTo(Currency.EUR));
        }

        [Test]
        public void Should_create_quantity_from_decimal()
        {
            var actual = 1.5m.AsQuantity();
            Assert.That(actual.Amount, Is.EqualTo(1.5m));
        }

        [Test]
        public void Should_create_quantity_from_integer()
        {
            var actual = 1.AsQuantity();
            Assert.That(actual.Amount, Is.EqualTo(1));
        }

    }
}