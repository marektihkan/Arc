using System;
using Arc.Domain.Units;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class SystemTimeTests
    {
        [TearDown]
        public void Teardown()
        {
            SystemTime.Reset();
        }

        [Test]
        public void Should_get_date_and_time_for_now()
        {
            var before = DateTime.Now;

            var actual = SystemTime.Now;

            var after = DateTime.Now;

            Assert.That(actual, Is.GreaterThanOrEqualTo(before));
            Assert.That(actual, Is.LessThanOrEqualTo(after));
        }

        [Test]
        public void Should_get_date_as_specified()
        {
            var expected = new DateTime(2000, 1, 1, 12, 0, 0);
            SystemTime.Is(() => expected);

            Assert.That(SystemTime.Now, Is.EqualTo(expected));
        }
    }
}