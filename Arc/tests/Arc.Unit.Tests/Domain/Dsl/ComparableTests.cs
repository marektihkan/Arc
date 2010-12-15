using NUnit.Framework;
using Arc.Domain.Dsl;

namespace Arc.Unit.Tests.Domain.Dsl
{
    [TestFixture]
    public class ComparableTests
    {

        [Test]
        public void Zero_should_be_less_than_one()
        {
            Assert.That(0.LessThan(1), Is.True);
        }

        [Test]
        public void One_should_not_be_less_than_zero()
        {
            Assert.That(1.LessThan(0), Is.False);
        }

        [Test]
        public void Zero_should_be_less_than_or_equal_to_one()
        {
            Assert.That(0.LessThanOrEqual(1), Is.True);
        }

        [Test]
        public void One_should_not_be_less_than_or_equal_to_zero()
        {
            Assert.That(1.LessThanOrEqual(0), Is.False);
        }

        [Test]
        public void Zero_should_be_less_than_or_equal_to_zero()
        {
            Assert.That(0.LessThanOrEqual(0), Is.True);
        }

        [Test]
        public void One_should_be_greater_than_zero()
        {
            Assert.That(1.GreaterThan(0), Is.True);
        }

        [Test]
        public void Zero_should_not_be_greater_than_one()
        {
            Assert.That(0.GreaterThan(1), Is.False);
        }

        [Test]
        public void One_should_be_greater_than_or_equal_to_zero()
        {
            Assert.That(1.GreaterThanOrEqual(0), Is.True);
        }

        [Test]
        public void Zero_should_not_be_greater_than_or_equal_to_one()
        {
            Assert.That(0.GreaterThanOrEqual(1), Is.False);
        }

        [Test]
        public void Zero_should_be_greater_than_or_equal_to_zero()
        {
            Assert.That(0.GreaterThanOrEqual(0), Is.True);
        }
    }
}