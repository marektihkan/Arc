using Arc.Unit.Tests.Fakes.Units;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class BaseRangeTests
    {
        [Test]
        public void Should_create_range_of_specified_type()
        {
            var expectedLowerBound = 0;
            var expectedUpperBound = 1;

            var target = new RangeTester<int>(expectedLowerBound, expectedUpperBound);

            Assert.That(target, Is.Not.Null);
            Assert.That(target.Lower, Is.EqualTo(expectedLowerBound));
            Assert.That(target.Upper, Is.EqualTo(expectedUpperBound));
            Assert.That(target.IsLowerInclusive, Is.True);
            Assert.That(target.IsUpperInclusive, Is.True);
        }

        [Test]
        public void Should_create_empty_range()
        {
            var target = new RangeTester<int>();

            Assert.That(target.Lower, Is.EqualTo(default(int)));
            Assert.That(target.Upper, Is.EqualTo(default(int)));
        }

        [Test]
        public void Should_be_able_to_set_upper_case_to_inclusive()
        {
            var target = new RangeTester<int>(0, 1);

            target.IsUpperInclusive = true;

            Assert.That(target.IsUpperInclusive, Is.True);
        }

        [Test]
        public void Should_be_able_to_set_lower_case_to_inclusive()
        {
            var target = new RangeTester<int>(0, 1);

            target.IsLowerInclusive = true;

            Assert.That(target.IsLowerInclusive, Is.True);
        }

    }
}