using Arc.Domain.Units;
using Arc.Unit.Tests.Fakes.Factories;
using NUnit.Framework;
using System.Linq;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class MoneybagTests
    {

        private Moneybag CreateSUT()
        {
            return new Moneybag();
        }

        [Test]
        public void Should_be_able_to_add_money_to_bag()
        {
            var target = CreateSUT();

            target.Add(MoneyFactory.OneEUR);

            Assert.That(target[Currency.EUR], Is.Not.Null);
        }

        [Test]
        public void Should_not_add_null_money()
        {
            var target = CreateSUT();

            target.Add(null);

            Assert.That(target[Currency.EUR], Is.Null);
        }

        [Test]
        public void Should_add_money_together_when_the_currency_is_same()
        {
            var target = CreateSUT();

            target.Add(MoneyFactory.OneEUR);
            target.Add(MoneyFactory.OneEUR);

            Assert.That(target[Currency.EUR], Is.EqualTo(MoneyFactory.TwoEUR));
        }

        [Test]
        public void Should_get_list_of_containing_money()
        {
            var target = new Moneybag();

            target.Add(MoneyFactory.OneEUR);
            target.Add(MoneyFactory.OneUSD);

            var actual = target.Money;

            Assert.That(actual.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Should_remove_money_from_bag()
        {
            var target = CreateSUT();

            target.Add(MoneyFactory.TwoEUR);
            target.Remove(Currency.EUR);

            Assert.That(target.Contains(Currency.EUR), Is.False);
        }

        [Test]
        public void Should_be_able_to_check_if_bag_contains_specified_currency()
        {
            var target = CreateSUT();

            target.Add(MoneyFactory.TwoEUR);

            Assert.That(target.Contains(Currency.EUR), Is.True, "Should contain EUR");
            Assert.That(target.Contains(Currency.USD), Is.False, "Should not contain USD");
        }

        [Test]
        public void Should_list_containing_money_with_currencies_when_converting_to_string()
        {
            var target = CreateSUT();

            target.Add(MoneyFactory.OneEUR);
            target.Add(MoneyFactory.TwoUSD);

            var actual = target.ToString();
            Assert.That(actual, Text.Contains("1,00 €"));
            Assert.That(actual, Text.Contains("$2.00"));
        }
    }
}