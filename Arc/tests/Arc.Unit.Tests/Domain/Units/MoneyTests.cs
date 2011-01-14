using System;
using Arc.Domain.Units;
using Arc.Unit.Tests.Fakes.Factories;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void Money_should_have_amount()
        {
            Assert.That(MoneyFactory.OneEUR.Amount, Is.EqualTo(1));
        }

        [Test]
        public void Money_should_have_currency()
        {
            Assert.That(MoneyFactory.OneEUR.Currency == Currency.EUR, Is.True);
        }

        [Test]
        public void Should_be_able_to_add_money()
        {
            var expectedAmount = MoneyFactory.OneEUR.Amount + MoneyFactory.TwoEUR.Amount;

            var actual = MoneyFactory.OneEUR + MoneyFactory.TwoEUR;
            
            Assert.That(actual.Amount, Is.EqualTo(expectedAmount));
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Should_not_add_money_in_different_currencies()
        {
            var money = MoneyFactory.OneUSD + MoneyFactory.TwoEUR;
        }

        [Test]
        public void Should_be_able_to_subtract_money()
        {
            var expectedAmount = MoneyFactory.TwoEUR.Amount - MoneyFactory.OneEUR.Amount;

            var actual = MoneyFactory.TwoEUR - MoneyFactory.OneEUR;

            Assert.That(actual.Amount, Is.EqualTo(expectedAmount));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_not_subtract_money_in_different_currencies()
        {
            var money = MoneyFactory.TwoUSD - MoneyFactory.OneEUR;
        }

        [Test]
        public void Should_be_able_to_multiply_money()
        {
            var money = MoneyFactory.OneUSD;
            const int multiplier = 3;
            var expecedAmount = multiplier * money.Amount;

            var actual = multiplier * money;

            Assert.That(actual.Amount, Is.EqualTo(expecedAmount));
        }

        [Test]
        public void Moneys_amount_should_be_compared_when_currencies_are_same()
        {
            Assert.That(MoneyFactory.ZeroEUR.CompareTo(MoneyFactory.OneEUR), Is.EqualTo(-1));
            Assert.That(MoneyFactory.OneEUR.CompareTo(MoneyFactory.OneEUR), Is.EqualTo(0));
            Assert.That(MoneyFactory.OneEUR.CompareTo(MoneyFactory.ZeroEUR), Is.EqualTo(1));
        }

        [Test]
        public void Money_should_be_greater_than_other_money_when_amount_is_greater()
        {
            Assert.That(MoneyFactory.OneEUR > MoneyFactory.ZeroEUR, Is.True);
            Assert.That(MoneyFactory.ZeroEUR > MoneyFactory.OneEUR, Is.False);
        }

        [Test]
        public void Money_should_be_greater_than_or_equal_to_other_money_when_amount_is_greater_or_equal()
        {
            Assert.That(MoneyFactory.OneEUR >= MoneyFactory.ZeroEUR, Is.True);
            Assert.That(MoneyFactory.OneEUR >= MoneyFactory.OneEUR, Is.True);
            Assert.That(MoneyFactory.ZeroEUR >= MoneyFactory.OneEUR, Is.False);
        }

        [Test]
        public void Money_should_be_less_than_other_money_when_amount_is_smaller()
        {
            Assert.That(MoneyFactory.ZeroEUR < MoneyFactory.OneEUR, Is.True);
            Assert.That(MoneyFactory.OneEUR < MoneyFactory.ZeroEUR, Is.False);
        }

        [Test]
        public void Money_should_be_less_than_or_equal_to_other_money_amount_is_smaller_or_equal()
        {
            Assert.That(MoneyFactory.ZeroEUR <= MoneyFactory.OneEUR, Is.True);
            Assert.That(MoneyFactory.ZeroEUR <= MoneyFactory.ZeroEUR, Is.True);
            Assert.That(MoneyFactory.OneEUR <= MoneyFactory.ZeroEUR, Is.False);
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Should_throw_exception_when_trying_to_compare_money_with_different_currencies()
        {
            MoneyFactory.ZeroEUR.CompareTo(MoneyFactory.ZeroUSD);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Should_throw_exception_when_comparing_money_with_null_money()
        {
            MoneyFactory.ZeroEUR.CompareTo(null);
        }

        [Test]
        public void Should_be_equal_to_other_money_when_amount_and_currency_are_same()
        {
            Assert.That(MoneyFactory.ZeroEUR == MoneyFactory.ZeroEUR, Is.True);
            Assert.That(MoneyFactory.ZeroEUR == MoneyFactory.ZeroUSD, Is.False);
            Assert.That(MoneyFactory.ZeroEUR == MoneyFactory.OneEUR, Is.False);
        }

        [Test]
        public void Should_not_be_equal_to_other_money_when_amount_or_currency_is_not_same()
        {
            Assert.That(MoneyFactory.ZeroEUR != MoneyFactory.ZeroEUR, Is.False);
            Assert.That(MoneyFactory.ZeroEUR != MoneyFactory.ZeroUSD, Is.True);
            Assert.That(MoneyFactory.ZeroEUR != MoneyFactory.OneEUR, Is.True);
        }

        [Test]
        public void Should_convert_money_to_string_with_currency()
        {
            Assert.That(MoneyFactory.OneEUR.ToString(), Is.EqualTo("1,00 €"));
            Assert.That(MoneyFactory.OneUSD.ToString(), Is.EqualTo("$1.00"));
            Assert.That(MoneyFactory.OneEEK.ToString(), Is.EqualTo("1.00 kr"));
        }
    }
}