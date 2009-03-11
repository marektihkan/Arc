using System;
using Arc.Domain.Identity;
using Arc.Unit.Tests.Fakes.Factories;
using Arc.Unit.Tests.Fakes.Identity;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Domain.Identity
{
    [TestFixture]
    public class GuidIdentityEntityTests
    {

        private IEntity<Guid> CreateSUT()
        {
            return new GuidIdentityEntity();
        }

        private IEntity<Guid> CreateSUT(Guid id)
        {
            return new GuidIdentityEntity(id);
        }


        [Test]
        public void Guid_based_entities_should_have_identity()
        {
            var target = CreateSUT(GuidFactory.One);

            Assert.That(target.Id, Is.EqualTo(GuidFactory.One));
        }

        [Test]
        public void Guid_based_entities_should_have_default_identity_value_empty_guid()
        {
            Assert.That(CreateSUT().Id, Is.EqualTo(GuidFactory.Empty));
        }

        [Test]
        public void New_guid_based_entity_should_be_transient()
        {
            Assert.That(CreateSUT().IsTransient, Is.True);
        }

        [Test]
        public void Guid_based_entity_with_not_default_identity_should_not_be_transient()
        {
            var target = CreateSUT(GuidFactory.One);

            Assert.That(target.IsTransient, Is.False);
        }

        [Test]
        public void Guid_based_entities_should_be_equal_when_guids_are_equal()
        {
            var entity = CreateSUT(GuidFactory.One);
            
            var target = CreateSUT(GuidFactory.One);

            Assert.That(target.Equals(entity), Is.True);
        }

        [Test]
        public void Guid_based_entities_should_not_be_equal_when_guids_arent_equal()
        {
            var entity = CreateSUT(GuidFactory.Two);

            var target = CreateSUT(GuidFactory.One);

            Assert.That(target.Equals(entity), Is.False);
        }

        [Test]
        public void Guid_based_entities_may_be_equal_only_to_other_guid_based_entities()
        {
            var target = CreateSUT(GuidFactory.One);

            Assert.That(target.Equals(new object()), Is.False);
            Assert.That(target.Equals(new IntegerIdentityEntity(1)), Is.False);
        }

        [Test]
        public void Guid_based_entities_should_have_same_hash_code_as_guid()
        {
            var actual = CreateSUT(GuidFactory.One);

            Assert.That(actual.GetHashCode(), Is.EqualTo(GuidFactory.One.GetHashCode()));
        }

        [Test]
        public void Guid_based_entity_subclass_may_change_identity()
        {
            var tester = new GuidIdentityEntityTester();

            Assert.That(tester.Id, Is.Not.EqualTo(GuidFactory.One), "It's identity should be other than one");

            tester.SetId(GuidFactory.One);

            Assert.That(tester.Id, Is.EqualTo(GuidFactory.One));
        }

        [Test]
        public void Guid_based_entity_subclass_may_change_version()
        {
            var tester = new GuidIdentityEntityTester();

            Assert.That(tester.Version, Is.Not.EqualTo(1), "It's version should be other than one");

            tester.SetVersion(1);

            Assert.That(tester.Version, Is.EqualTo(1));
        }

        [Test]
        public void Guid_based_entity_should_have_version()
        {
            var target = CreateSUT() as IVersioned;

            Assert.That(target.Version, Is.EqualTo(0));
        }
    }
}