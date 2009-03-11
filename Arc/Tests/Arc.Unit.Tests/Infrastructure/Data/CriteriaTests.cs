using Arc.Infrastructure.Data.FluentCriteria;
using Arc.Unit.Tests.Fakes;
using NHibernate.Criterion;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Infrastructure.Data
{
    [TestFixture]
    public class CriteriaTests
    {

        [Test]
        public void Should_create_criteria_without_extensions()
        {
            var expected = "DetachableCriteria((Name = Tiit and not Id = 1) and not Name = Peeter\r\nName asc)";

            var actual = DetachedCriteria.For<DomainObject>()
                .Add(Criteria.With<DomainObject>(x => x.Name == "Tiit" && x.Id != 1))
                .Add(Criteria.With<DomainObject>(x => x.Name != "Peeter"))
                .AddOrder(Ordering.Ascending<DomainObject>(x => x.Name))
                .ToString();
                
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_create_criteria_with_extensions()
        {
            var expected = "DetachableCriteria((Name = Tiit and not Id = 1) and not Name = Peeter\r\nName asc)";

            var actual = Criteria.For<DomainObject>()
                .With<DomainObject>(x => x.Name == "Tiit" && x.Id != 1)
                .With<DomainObject>(x => x.Name != "Peeter")
                .AscendingOrdering<DomainObject>(x => x.Name)
                .ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_create_criteria_with_extensions_and_without_generics()
        {
            var expected = "DetachableCriteria((Name = Tiit and not Id = 1) and not Name = Peeter\r\nName asc and Id desc)";

            var actual = Criteria.For<DomainObject>()
                .With((DomainObject x) => x.Name == "Tiit" && x.Id != 1)
                .With((DomainObject x) => x.Name != "Peeter")
                .AscendingOrdering((DomainObject x) => x.Name)
                .DescendingOrdering((DomainObject x) => x.Id)
                .ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_create_criteria_with_descending_ordering()
        {
            var criteria = Criteria.For<DomainObject>()
                .DescendingOrdering<DomainObject>(x => x.Name);

            Assert.That(criteria.Orders, Has.Count(1));
            Assert.That(criteria.Orders[0].ToString(), Is.EqualTo("Name desc"));
        }

        [Test]
        public void Should_create_criteria_with_ascending_ordering()
        {
            var criteria = Criteria.For<DomainObject>()
                .AscendingOrdering<DomainObject>(x => x.Name);

            Assert.That(criteria.Orders, Has.Count(1));
            Assert.That(criteria.Orders[0].ToString(), Is.EqualTo("Name asc"));
        }

    }
}