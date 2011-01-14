using Arc.Domain.Units;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class RangeTests
    {

        [Test]
        public void Element_should_be_in_range_when_its_between_lower_and_upper_bound()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 2;
            const int expectedElement = 1;

            var target = new Range<int>(expectedLowerBound, expectedUpperBound);
            var actual = target.Contains(expectedElement);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Element_should_not_be_in_range_when_its_not_between_lower_and_upper_bound()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 1;
            const int expectedElement = 2;

            var target = new Range<int>(expectedLowerBound, expectedUpperBound);
            var actual = target.Contains(expectedElement);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Element_should_be_in_range_when_its_equal_to_lower_bound_and_its_inclusive()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 1;
            const int expectedElement = 0;

            var target = new Range<int>(expectedLowerBound, expectedUpperBound);
            var actual = target.Contains(expectedElement);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Element_should_be_in_range_when_its_equal_to_upper_bound_and_its_inclusive()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 1;
            const int expectedElement = 1;

            var target = new Range<int>(expectedLowerBound, expectedUpperBound);
            var actual = target.Contains(expectedElement);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Element_should_not_be_in_range_when_its_equal_to_lower_bound_and_its_not_inclusive()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 1;
            const int expectedElement = 0;

            var target = new Range<int>(expectedLowerBound, false, expectedUpperBound, false);
            var actual = target.Contains(expectedElement);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Element_should_not_be_in_range_when_its_equal_to_upper_bound_and_its_not_inclusive()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 1;
            const int expectedElement = 1;

            var target = new Range<int>(expectedLowerBound, false, expectedUpperBound, false);
            var actual = target.Contains(expectedElement);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Inclusive_range_should_contain_same_not_inclusive_range()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 1;
            var expectedRange = new Range<int>(expectedLowerBound, false, expectedUpperBound, false);

            var target = new Range<int>(expectedLowerBound, true, expectedUpperBound, true);
            var actual = target.Contains(expectedRange);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Not_inclusive_range_should_not_contain_same_inclusive_range()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 1;
            var expectedRange = new Range<int>(expectedLowerBound, true, expectedUpperBound, true);

            var target = new Range<int>(expectedLowerBound, false, expectedUpperBound, false);
            var actual = target.Contains(expectedRange);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Range_with_not_inclusive_upper_bound_should_not_contain_same_inclusive_range()
        {
            const int expectedLowerBound = 0;
            const int expectedUpperBound = 1;
            var expectedRange = new Range<int>(expectedLowerBound, true, expectedUpperBound, true);

            var target = new Range<int>(expectedLowerBound, true, expectedUpperBound, false);
            var actual = target.Contains(expectedRange);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Range_should_not_contain_infinity()
        {
            var infinity = new NullableRange<int>(null, null);
            
            var target = new NullableRange<int>(0, null);
            var actual = target.Contains(infinity);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Range_should_not_contain_other_range_when_opposite_sides_are_infinity()
        {
            var range = new NullableRange<int>(null, 1);

            var target = new NullableRange<int>(0, null);
            var actual = target.Contains(range);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Range_should_contain_other_range_when_same_sides_are_infinite_and_other_side_is_set()
        {
            var range = new NullableRange<int>(1, null);

            var target = new NullableRange<int>(0, null);
            var actual = target.Contains(range);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Range_should_contain_other_range_when_targets_one_side_is_infinity_and_other_range_is_fixed()
        {
            var range = new NullableRange<int>(1, 2);

            var target = new NullableRange<int>(0, null);
            var actual = target.Contains(range);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Infinity_should_contain_any_range()
        {
            var infinity = new NullableRange<int>(null, null);

            var range = new NullableRange<int>(0, null);
            var actual = infinity.Contains(range);

            Assert.That(actual, Is.True);           
        }

        [Test]
        public void Range_should_contain_null_element()
        {
            var target = new NullableRange<int>(0, null);
            var actual = target.Contains((int?) null);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Range_should_contain_null_range()
        {
            var target = new NullableRange<int>(0, null);
            var actual = target.Contains((BaseRange<int?>) null);

            Assert.That(actual, Is.True);
        }
    }
}