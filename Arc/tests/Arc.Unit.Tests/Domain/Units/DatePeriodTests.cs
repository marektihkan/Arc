using System;
using Arc.Domain.Units;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Units
{
    [TestFixture]
    public class DatePeriodTests
    {

        [Test]
        public void Date_period_should_remove_time_part()
        {
            var date = DateTime.Now;
            var expectedDate = date.Date;

            var target = new DatePeriod(date, date);

            Assert.That(target.Lower, Is.EqualTo(expectedDate));
            Assert.That(target.Upper, Is.EqualTo(expectedDate));
        }

        [Test]
        public void Date_period_should_remove_time_part_from_lower_bound()
        {
            var date = DateTime.Now;
            var expectedDate = date.Date;

            var target = new DatePeriod {Lower = date};

            Assert.That(target.Lower, Is.EqualTo(expectedDate));
        }

        [Test]
        public void Date_period_should_remove_time_part_from_upper_bound()
        {
            var date = DateTime.Now;
            var expectedDate = date.Date;

            var target = new DatePeriod(date, date) {Upper = date};

            Assert.That(target.Upper, Is.EqualTo(expectedDate));
        }
    }
}