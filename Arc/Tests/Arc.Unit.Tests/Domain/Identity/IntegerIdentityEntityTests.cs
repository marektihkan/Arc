using Arc.Domain.Identity;
using Arc.Unit.Tests.Fakes.Identity;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

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

    }
}