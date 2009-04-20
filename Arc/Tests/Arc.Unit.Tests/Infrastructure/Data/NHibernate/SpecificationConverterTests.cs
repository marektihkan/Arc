using System;
using Arc.Domain.Specifications;
using Arc.Infrastructure.Data.NHibernate.Specifications;
using Arc.Unit.Tests.Fakes;
using Arc.Unit.Tests.Fakes.Data;
using Arc.Unit.Tests.Fakes.Entities;
using NHibernate.Criterion;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Infrastructure.Data.NHibernate
{
    [TestFixture]
    public class SpecificationConverterTests
    {
        private void TestParameterValue(int value)
        {
            var specification = new Specification<DomainObject>(x => x.Id == value);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Id = " + value));
        }

        [Test]
        public void Should_translate_property_equals_constant_value_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Name == "Tiit");

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name = Tiit"));
        }

        [Test]
        public void Should_translate_property_not_equals_constant_value_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Name != "Tiit");

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("not Name = Tiit"));
        }

        [Test]
        public void Should_translate_property_equals_constant_null_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Name == null);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name is null"));
        }

        [Test]
        public void Should_translate_property_not_equals_constant_null_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Name != null);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name is not null"));
        }

        [Test]
        public void Should_translate_property_is_greater_than_constant_value_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Id > 1);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Id > 1"));
        }

        [Test]
        public void Should_translate_property_is_greater_than_or_equal_to_constant_value_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Id >= 1);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Id >= 1"));
        }

        [Test]
        public void Should_translate_property_is_less_than_constant_value_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Id < 1);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Id < 1"));
        }

        [Test]
        public void Should_translate_property_is_less_than_or_equal_to_constant_value_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Id <= 1);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Id <= 1"));
        }

        [Test]
        public void Should_translate_property_equals_variable_value_to_criteria()
        {
            var identity = 1;

            var specification = new Specification<DomainObject>(x => x.Id == identity);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Id = 1"));
        }

        [Test]
        public void Should_translate_property_equals_property_value_to_criteria()
        {
            var values = new SpecificationConverterTestValues();
            values.Name = "Tiit";

            var specification = new Specification<DomainObject>(x => x.Name == values.Name);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name = Tiit"));
        }

        [Test]
        public void Should_translate_property_equals_static_property_value_to_criteria()
        {
            SpecificationConverterTestValues.StaticName = "Tiit";

            var specification = new Specification<DomainObject>(x => x.Name == SpecificationConverterTestValues.StaticName);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name = Tiit"));
        }

        [Test]
        public void Should_translate_property_equals_static_property_value_from_static_class_to_criteria()
        {
            SpecificationConverterStaticTestValues.Name = "Tiit";

            var specification = new Specification<DomainObject>(x => x.Name == SpecificationConverterStaticTestValues.Name);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name = Tiit"));
        }

        [Test]
        public void Should_translate_property_equals_property_collection_value_from_other_class_to_criteria()
        {
            var values = new SpecificationConverterTestValues();
            values.Names = new[] { "Tiit", "Peeter" };

            var specification = new Specification<DomainObject>(x => x.Name == values.Names[1]);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name = Peeter"));
        }

        [Test]
        public void Should_translate_property_equals_collection_value_to_criteria()
        {
            var names = new[] { "Tiit", "Peeter" };

            var specification = new Specification<DomainObject>(x => x.Name == names[1]);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name = Peeter"));
        }

        public string[] Names { get; set; }

        [Test]
        public void Should_translate_property_equals_property_collection_value_from_same_class_to_criteria()
        {
            Names = new[] { "Tiit", "Peeter" };

            var specification = new Specification<DomainObject>(x => x.Name == Names[1]);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name = Peeter"));
        }

        [Test]
        public void Should_translate_property_equals_enumerator_value_to_criteria()
        {
            var specification = new Specification<Person>(x => x.Behavior == BehaviorType.Agressive);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Behavior = 0"));
        }

        [Test]
        public void Should_translate_property_equals_parameter_value_to_criteria()
        {
            TestParameterValue(1);
        }

        [Test]
        public void Should_translate_conjunction_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Id == 1 && x.Name == "Tiit");

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("(Id = 1 and Name = Tiit)"));
        }

        [Test]
        public void Should_translate_disjunction_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Id == 1 || x.Name == "Tiit");

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("(Id = 1 or Name = Tiit)"));
        }

        [Test]
        public void Should_translate_negation_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => !(x.Id == 1 && x.Name == "Tiit"));

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("not (Id = 1 and Name = Tiit)"));
        }

        [Test]
        public void Should_translate_property_contains_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Name.Contains("Tiit"));

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name like %Tiit%"));
        }

        [Test]
        public void Should_translate_property_starts_with_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Name.StartsWith("Tiit"));

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name like Tiit%"));
        }

        [Test]
        public void Should_translate_property_ends_with_to_criteria()
        {
            var specification = new Specification<DomainObject>(x => x.Name.EndsWith("Tiit"));

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("Name like %Tiit"));
        }

        [Test]
        [ExpectedException(typeof (NotSupportedException))]
        public void Should_throw_exception_when_method_is_not_translatable()
        {
            var specification = new Specification<DomainObject>(x => x.Name.Trim() == "");

            CriterionConverter.Convert(specification);
        }

        [Test]
        public void Should_translate_boolean_property_to_criteria()
        {
            var specification = new Specification<Person>(x => x.IsActiveMember);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("IsActiveMember = True"));
        }

        [Test]
        public void Should_translate_negative_boolean_property_to_criteria()
        {
            var specification = new Specification<Person>(x => !x.IsActiveMember);

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("not IsActiveMember = True"));
        }

        [Test]
        public void Should_translate_value_objects_to_property_chain()
        {
            var specification = new Specification<Person>(x => x.ContactCard.Email.Address == "a");

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("ContactCard.Email.Address = a"));
        }

        [Test]
        public void Should_convert_combined_specifications_with_and_operator_to_criteria()
        {
            var specification = new Specification<Person>(x => x.FirstName == "a")
                .And(new Specification<Person>(y => y.LastName == "a"));

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("(FirstName = a and LastName = a)"));
        }

        [Test]
        public void Should_convert_combined_specifications_with_or_operator_to_criteria()
        {
            var specification = new Specification<Person>(x => x.FirstName == "a")
                .Or(new Specification<Person>(y => y.LastName == "a"));

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("(FirstName = a or LastName = a)"));
        }

        [Test]
        public void Should_convert_combined_specifications_with_not_operator_to_criteria()
        {
            var specification = new Specification<Person>(x => x.FirstName == "a").Not();

            var actual = CriterionConverter.Convert(specification);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToString(), Is.EqualTo("not FirstName = a"));
        }
    }
}