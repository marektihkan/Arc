using Arc.Domain.Units;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class CurrencyTests
    {

        [Test]
        public void Currency_should_have_abbreviation()
        {
            var target = Currency.EUR;

            Assert.That(target.Abbreviation, Is.EqualTo(CurrencyConstants.EUR));
        }

        [Test]
        public void Currency_should_format_money_by_culture_info()
        {
            Assert.That(Currency.EUR.Format(1), Is.EqualTo("1,00 €"));
        }

        [Test]
        public void Currency_hash_code_should_be_equal_to_abbreviation_hash_code()
        {
            Assert.That(Currency.EUR.GetHashCode(), Is.EqualTo(Currency.EUR.Abbreviation.GetHashCode()));
        }

        [Test]
        public void Currencies_are_equal_when_abbreviations_are_equal()
        {
            Assert.That(Currency.EUR == Currency.EUR, Is.True, "EUR should be equal to EUR");
            Assert.That(Currency.EUR.Equals(Currency.EUR), Is.True, "EUR should be equal to EUR");
            Assert.That(Currency.EUR != Currency.USD, Is.True, "EUR should not be equal to USD");
            Assert.That(Currency.EUR.Equals(Currency.USD), Is.False, "EUR should not be equal to USD");
            Assert.That(Currency.EUR == null, Is.False, "EUR should not be equal to null");
            Assert.That(null == Currency.EUR, Is.False, "EUR should not be equal to null");
        }

        [Test]
        public void Currency_should_contain_AUD()
        {
            Assert.That(Currency.AUD, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_BGN()
        {
            Assert.That(Currency.BGN, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_CAD()
        {
            Assert.That(Currency.CAD, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_CHF()
        {
            Assert.That(Currency.CHF, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_CZK()
        {
            Assert.That(Currency.CZK, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_DKK()
        {
            Assert.That(Currency.DKK, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_EEK()
        {
            Assert.That(Currency.EEK, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_EUR()
        {
            Assert.That(Currency.EUR, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_GBP()
        {
            Assert.That(Currency.GBP, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_HRK()
        {
            Assert.That(Currency.HRK, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_HUF()
        {
            Assert.That(Currency.HUF, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_JPY()
        {
            Assert.That(Currency.JPY, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_LTL()
        {
            Assert.That(Currency.LTL, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_LVL()
        {
            Assert.That(Currency.LVL, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_NOK()
        {
            Assert.That(Currency.NOK, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_PLN()
        {
            Assert.That(Currency.PLN, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_RON()
        {
            Assert.That(Currency.RON, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_RUB()
        {
            Assert.That(Currency.RUB, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_SEK()
        {
            Assert.That(Currency.SEK, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_TRY()
        {
            Assert.That(Currency.TRY, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_USD()
        {
            Assert.That(Currency.USD, Is.Not.Null);
        }

        [Test]
        public void Currency_should_contain_null_currency()
        {
            Assert.That(Currency.None, Is.Not.Null);
        }
    }
}