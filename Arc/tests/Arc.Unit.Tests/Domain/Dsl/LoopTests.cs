using System.Collections.Generic;
using Arc.Domain.Dsl;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Dsl
{
    [TestFixture]
    public class LoopTests
    {
        [Test]
        public void Should_not_invoke_action_when_n_is_negative()
        {
            var actual = 0;
            (-5).Times(x => actual++);

            Assert.That(actual, Is.EqualTo(0));
        }
        
        [Test]
        public void Should_invoke_action_n_times()
        {
            var actual = 0;
            5.Times(x => actual++);
            
            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void Should_invoke_action_n_times_when_n_is_unsigned_integer()
        {
            var actual = 0;
            const uint five = 5;
            five.Times(x => actual++);

            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void Should_invoke_action_for_each_element_in_list()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var actual = 0;
            list.ForEach(x => actual += x);

            Assert.That(actual, Is.EqualTo(15));
        }
    }
}