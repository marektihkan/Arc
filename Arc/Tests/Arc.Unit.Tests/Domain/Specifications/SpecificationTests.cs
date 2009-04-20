using System;
using System.Linq;
using System.Linq.Expressions;
using Arc.Domain.Specifications;
using Arc.Unit.Tests.Fakes.Specifications;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Domain.Specifications
{
    [TestFixture]
    public class SpecificationTests
    {

        [Test]
        public void Should_add_and_operator_to_specification()
        {
            var target = new Specification<string>(x => x.Contains("a")).And(new Specification<string>(y => y.Length > 3));
            var items = new[] { "a", "aa", "aaa", "aaaa" };

            var result = (from item in items
                          where target.IsSatisfiedBy(item)
                          select item).ToList();

            foreach (var value in result)
            {
                Assert.That(value, Text.Contains("a"));
                Assert.That(value.Length, Is.GreaterThan(3));
            }
        }

        [Test]
        public void Should_add_or_operator_to_specification()
        {
            var target = new Specification<string>(s => s.Contains("a")).Or(new Specification<string>(s => s.Length > 3));
            var items = new[] { "a", "bb", "bbbb", "bbbb" };

            var result = (from item in items
                          where target.IsSatisfiedBy(item)
                          select item).ToList();

            foreach (var value in result)
            {
                Assert.That(value.Length > 3 || value.Contains("a"), Is.True);
            }
        }

        [Test]
        public void Should_add_not_operator_to_specification()
        {
            var target = new Specification<string>(s => s.Contains("a")).Or(new Specification<string>(s => s.Length > 3).Not());
            var items = new[] { "a", "bb", "bbbb", "bbbb" };

            var result = (from item in items
                          where target.IsSatisfiedBy(item)
                          select item).ToList();

            foreach (var value in result)
            {
                Assert.That(!(value.Length > 3) || value.Contains("a"), Is.True);
            }
        }

        [Test]
        public void Should_return_itself_on_adding_and_operator_when_other_specification_is_null()
        {
            var expected = new Specification<string>(s => s.Contains("a"));
            var target = expected.And(null);
            Assert.That(target, Is.SameAs(expected));
        }

        [Test]
        public void Should_return_itself_on_adding_or_operator_when_other_specification_is_null()
        {
            var expected = new Specification<string>(s => s.Contains("a"));
            var target = expected.Or(null);
            Assert.That(target, Is.SameAs(expected));
        }

        [Test]
        public void Should_build_predicate_from_lambda()
        {
            var target = new TestSpecification<string>(x => string.IsNullOrEmpty(x));

            Assert.That(target.Predicate, Is.SameAs(target.AddedExpression));
        }

    }
}