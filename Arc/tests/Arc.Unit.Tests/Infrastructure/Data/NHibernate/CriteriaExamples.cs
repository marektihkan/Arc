using Arc.Domain.Specifications;
using Arc.Infrastructure.Data.NHibernate.FluentCriteria;
using Arc.Unit.Tests.Fakes.Entities;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NUnit.Framework;
using Alias=Arc.Infrastructure.Data.NHibernate.FluentCriteria.Alias;

namespace Arc.Unit.Tests.Infrastructure.Data.NHibernate
{
    [TestFixture]
    public class CriteriaExamples
    {

        [Test]
        public void Should_create_property_equals_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Eq("FirstName", "Name"));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName == "Name");

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_not_equals_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Not(Restrictions.Eq("FirstName", "Name")));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName != "Name");

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_equals_null_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.IsNull("FirstName"));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName == null);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_is_greater_than_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Gt("Age", 0));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.Age > 0);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_is_greater_than_or_equal_to_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Ge("Age", 0));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.Age >= 0);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_is_less_than_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Lt("Age", 1));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.Age < 1);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_is_less_than_or_equal_to_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Le("Age", 1));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.Age <= 1);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_contains_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Like("FirstName", "%Name%"));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName.Contains("Name"));

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_starts_with_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Like("FirstName", "Name%"));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName.StartsWith("Name"));

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_ends_with_value_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Like("FirstName", "%Name"));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName.EndsWith("Name"));

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_criteria_with_specification()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Like("FirstName", "%Name"));

            var specification = new Specification<Person>(x => x.FirstName.EndsWith("Name"));

            var actual = Criteria.For<Person>()
                .With(specification);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_conjunction_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.And(
                         Restrictions.Eq("FirstName", "Name"), 
                         Restrictions.Eq("LastName", "Name")));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName == "Name" && x.LastName == "Name");

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_disjunction_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Or(
                         Restrictions.Eq("FirstName", "Name"),
                         Restrictions.Eq("LastName", "Name")));

            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName == "Name" || x.LastName == "Name");

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_negation_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.Not(
                         Restrictions.And(
                             Restrictions.Eq("FirstName", "Name"),
                             Restrictions.Eq("LastName", "Name"))));

            var actual = Criteria.For<Person>()
                .With<Person>(x => !(x.FirstName == "Name" && x.LastName == "Name"));

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_add_ascending_ordering()
        {
            var expected = DetachedCriteria.For<Person>()
                .AddOrder(Order.Asc("FirstName"));

            var actual = Criteria.For<Person>()
                .AscendingOrdering<Person>(x => x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_add_descending_ordering()
        {
            var expected = DetachedCriteria.For<Person>()
                .AddOrder(Order.Desc("FirstName"));

            var actual = Criteria.For<Person>()
                .DescendingOrdering<Person>(x => x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_criteria_from_operation_of_two_properties()
        {
            var expected = DetachedCriteria.For<Person>()
                .Add(Restrictions.EqProperty("FirstName", "FirstName"));
                
            var actual = Criteria.For<Person>()
                .With<Person>(x => x.FirstName == x.FirstName);
                
            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_alias()
        {
            
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.EqProperty("contact.FirstName", "FirstName"));

            
            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.FirstName == x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_inner_join_from_alias()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.EqProperty("contact.FirstName", "FirstName"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.FirstName == x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_right_join_from_alias()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.RightOuterJoin)
                .Add(Restrictions.EqProperty("contact.FirstName", "FirstName"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .RightJoin(() => contact)
                .With<Person>(x => contact.FirstName == x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_left_join_from_alias()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.LeftOuterJoin)
                .Add(Restrictions.EqProperty("contact.FirstName", "FirstName"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .LeftJoin(() => contact)
                .With<Person>(x => contact.FirstName == x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_full_join_from_alias()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.FullJoin)
                .Add(Restrictions.EqProperty("contact.FirstName", "FirstName"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .FullJoin(() => contact)
                .With<Person>(x => contact.FirstName == x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_alias_calling_method_to_criteria()
        {

            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.Like("contact.FirstName", "%Name%"));


            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.FirstName.Contains("Name"));

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_joined_criteria()
        {
            var expected = DetachedCriteria.For<Person>("person")
                .CreateAlias("Contacts", "contact", JoinType.None)
                .Add(Restrictions.EqProperty("contact.FirstName", "person.FirstName"));
            
            
            var person = Alias.For<Person>();
            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>(() => person)
                .Join(() => contact, JoinType.None)
                .With<Person>(x => contact.FirstName == person.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_equals_property_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.EqProperty("contact.FirstName", "FirstName"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.FirstName == x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_does_not_equal_property_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.Not(Restrictions.EqProperty("contact.FirstName", "FirstName")));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.FirstName != x.FirstName);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_is_greater_than_property_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.GtProperty("contact.Age", "Age"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.Age > x.Age);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_is_greater_than_or_equal_property_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.GeProperty("contact.Age", "Age"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.Age >= x.Age);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_is_less_than_property_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.LtProperty("contact.Age", "Age"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.Age < x.Age);

            AssertCriteria.AreEqual(actual, expected);
        }

        [Test]
        public void Should_create_property_is_less_than_or_equal_to_property_criteria()
        {
            var expected = DetachedCriteria.For<Person>()
                .CreateAlias("Contacts", "contact", JoinType.InnerJoin)
                .Add(Restrictions.LeProperty("contact.Age", "Age"));

            var contact = Alias.From<Person>(x => x.Contacts).For<Person>();

            var actual = Criteria.For<Person>()
                .InnerJoin(() => contact)
                .With<Person>(x => contact.Age <= x.Age);

            AssertCriteria.AreEqual(actual, expected);
        }
    }
}