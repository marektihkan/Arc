using System.Collections;
using Arc.Domain.Identity;
using Arc.Unit.Tests.Fakes.Entities;
using Arc.Unit.Tests.Fakes.Identity;
using Castle.DynamicProxy;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Arc.Testing.Utilities;

namespace Arc.Unit.Tests.Domain.Identity
{
    [TestFixture]
    public class IntegerIdentityEntityTests
    {
        private IEntity<int> CreateSUT()
        {
            return new IntegerIdentityEntity();
        }

        private IEntity<int> CreateSUT(int id)
        {
            return new IntegerIdentityEntity(id);
        }


        [Test]
        public void Integer_based_entities_should_have_identity()
        {
            var expectedIdentity = 1;
            
            var target = CreateSUT(expectedIdentity);

            Assert.That(target.Id, Is.EqualTo(expectedIdentity));
        }

        [Test]
        public void Integer_based_entities_should_have_default_identity_value_zero()
        {
            Assert.That(CreateSUT().Id, Is.EqualTo(0));
        }

        [Test]
        public void New_integer_based_entity_should_be_transient()
        {
            Assert.That(CreateSUT().IsTransient, Is.True);
        }

        [Test]
        public void Integer_based_entity_with_not_default_identity_should_not_be_transient()
        {
            var target = CreateSUT(1);

            Assert.That(target.IsTransient, Is.False);
        }

        [Test]
        public void Integer_based_entity_should_have_version()
        {
            var target = CreateSUT() as IVersioned;

            Assert.That(target.Version, Is.EqualTo(0));
        }

        [Test]
        public void Integer_based_entity_subclass_may_change_identity()
        {
            var tester = new IntegerIdentityEntityTester();

            Assert.That(tester.Id, Is.Not.EqualTo(1), "It's identity should be other than one");

            tester.SetId(1);

            Assert.That(tester.Id, Is.EqualTo(1));
        }

        [Test]
        public void Integer_based_entity_subclass_may_change_version()
        {
            var tester = new IntegerIdentityEntityTester();

            Assert.That(tester.Version, Is.Not.EqualTo(1), "It's version should be other than one");

            tester.SetVersion(1);

            Assert.That(tester.Version, Is.EqualTo(1));
        }

        [Test]
        public void Transient_integer_based_entity_should_not_be_equal_with_other_transient_entity()
        {
            var first = new Person();
            var second = new Person();

            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void Transient_integer_based_entity_should_be_equal_other_transient_entity_when_they_reference_to_same_entity()
        {
            var first = new Person();
            var second = first;

            Assert.That(first, Is.EqualTo(second));
        }

        [Test]
        public void Integer_based_entities_with_same_identity_and_type_should_be_equal()
        {
            var first = new Person(1);
            var second = new Person(1);

            Assert.That(first, Is.EqualTo(second));
        }

        [Test]
        public void Integer_based_entities_with_different_identity_should_not_be_equal()
        {
            var first = new Person(1);
            var second = new Person(2);

            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void Integer_based_entity_with_identity_should_not_be_equal_to_transient_entity()
        {
            var first = new Person(1);
            var second = new Person();

            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void Integer_based_entities_with_same_identity_and_different_type_are_not_equal()
        {
            var first = new Person(1);
            var second = new Organization(1);

            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void Integer_based_entity_should_not_be_equal_to_null_entity()
        {
            var entity = new Person(1);

            Assert.That(entity, Is.Not.EqualTo(null));
        }

        [Test]
        public void Different_types_of_integer_based_entities_should_not_have_same_hashcode_in_hashtable()
        {
            var person = new Person(1);
            var organization = new Organization(1);

            var hashtable = new Hashtable();

            hashtable.Add(person, "Person");
            hashtable.Add(organization, "Organization");

            Assert.That(hashtable[person], Is.EqualTo("Person"));
            Assert.That(hashtable[organization], Is.EqualTo("Organization"));
        }

        [Test]
        public void Two_integer_based_proxies_should_be_equal()
        {
            var generator = new ProxyGenerator();
            var first = (Person)generator.CreateClassProxy(typeof(Person), new ProxyGenerationOptions());
            first.SetValueTo("Id", 1);

            var second = (Person) generator.CreateClassProxy(typeof(Person), new ProxyGenerationOptions());
            second.SetValueTo("Id", 1);

            Assert.That(first, Is.EqualTo(second));
        }
    }
}