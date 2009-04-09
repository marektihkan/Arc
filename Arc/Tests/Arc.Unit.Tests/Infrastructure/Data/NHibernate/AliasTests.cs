using Arc.Infrastructure.Data.NHibernate.FluentCriteria;
using Arc.Unit.Tests.Fakes.Entities;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Infrastructure.Data.NHibernate
{
    [TestFixture]
    public class AliasTests
    {

        [Test]
        public void Should_create_alias_for_criteria()
        {
            var target = Alias.For<Person>();

            Assert.That(target, Is.InstanceOfType(typeof (IAlias)));
        }

        [Test]
        public void Should_create_alias_with_path()
        {
            var target = Alias.From<Person>(x => x.Contacts).For<Person>();

            Assert.That(target, Is.InstanceOfType(typeof(IAlias)));
            Assert.That(((IAlias) target).AliasPath, Is.EqualTo("Contacts"));
        }

    }
}