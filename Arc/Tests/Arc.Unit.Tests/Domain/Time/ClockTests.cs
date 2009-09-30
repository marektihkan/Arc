using System;
using Arc.Domain.Time;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Time
{
    [TestFixture]
    public class ClockTests
    {
        private IClock CreateSUT()
        {
            return new Clock();
        }

        [Test]
        public void Should_get_date_and_time_for_now()
        {
            var before = DateTime.Now;

            var actual = CreateSUT().Now;

            var after = DateTime.Now;

            Assert.That(actual, Is.GreaterThanOrEqualTo(before));
            Assert.That(actual, Is.LessThanOrEqualTo(after));
        }

        [Test]
        public void Should_get_todays_date()
        {
            var before = DateTime.Today;

            var actual = CreateSUT().Today;

            var after = DateTime.Today;

            Assert.That(actual, Is.GreaterThanOrEqualTo(before));
            Assert.That(actual, Is.LessThanOrEqualTo(after));
            Assert.That(actual.Hour, Is.EqualTo(0));
            Assert.That(actual.Minute, Is.EqualTo(0));
            Assert.That(actual.Second, Is.EqualTo(0));
        }
    }
}