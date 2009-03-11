using Arc.Domain.Units;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class QuantityTests
    {

        private Quantity CreateSUT()
        {
            return new Quantity();
        }

        [Test]
        public void Should_be_able_to_create_new_quantity_with_amount_and_unit()
        {
            var expectedAmount = 1m;
            var expectedUnit = string.Empty;
            
            var target = new Quantity(expectedAmount, expectedUnit);
            
            Assert.That(target.Amount, Is.EqualTo(expectedAmount));
            Assert.That(target.Unit, Is.EqualTo(expectedUnit));
        }

        [Test]
        public void Quantity_should_have_amount()
        {
            var expected = 1m;
            var target = CreateSUT();
            target.Amount = expected;
            Assert.That(target.Amount, Is.EqualTo(expected));
        }

        [Test]
        public void Quantity_should_have_unit()
        {
            var expected = string.Empty;
            var target = CreateSUT();
            target.Unit = expected;
            Assert.That(target.Unit, Is.EqualTo(expected));
        }
    }
}