using Arc.Testing.Styles;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using Arc.Testing.Utilities;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class When_person_should_do_something : ContextSpecification<Person>
    {
        public override void Context()
        {
            SUT = new Person { DomainService = Mockery.Get<IDomainService>() };
        }

        [Description("")]
        public override void Because()
        {
            SUT.DoSomething();
            SUT.SetValueTo("_id", 6);
            SUT.SetValueTo("Name", "mihkel");
        }

        [Test]
        public void Domain_service_should_do_something()
        {
            Assert.That(SUT.GetValueOf<int>("_id"), Is.EqualTo(6));
            Assert.That(SUT.GetValueOf<string>("Name"), Is.EqualTo("mihkel"));
            Mockery.Get<IDomainService>().AssertWasCalled(x => x.DoSomething());
        }

    }
    
    
    
    public class ValidPerson : GivenWhenThen<Person>
    {
        public override void Given()
        {
            SUT = new Person { FirstName = "Tiit", LastName = "Tamiil" };
        }
    }

    public class Then_it_should_be_invalid_person : GivenWhenThen<Person>
    {
        public override void Given()
        {
            SUT = new Person { FirstName = "Tiit", LastName = "Tamiil" };
        }

        [Test]
        public void It_should_be_invalid()
        {
            Assert.That(SUT.IsValid, Is.False);
        }
    }

    [TestFixture]
    public class When_person_is_valid : ValidPerson
    {
        [Test]
        public void First_name_should_be_filled()
        {
            Assert.That(SUT.IsValid, Is.True);
            Assert.That(SUT.FirstName, Is.Not.Null);
        }

        [Test]
        public void Last_name_should_be_filled()
        {
            Assert.That(SUT.IsValid, Is.True);
            Assert.That(SUT.LastName, Is.Not.Null);
        }
    }

    [TestFixture]
    public class When_persons_first_name_is_empty : Then_it_should_be_invalid_person
    {
        public override void When()
        {
            SUT.FirstName = string.Empty;
        }
    }

    [TestFixture]
    public class When_persons_last_name_is_empty : Then_it_should_be_invalid_person
    {
        public override void When()
        {
            SUT.LastName = string.Empty;
        }
    }


    [TestFixture]
    public class Person_is_invalid : ValidPerson
    {
        [Test]
        public void When_first_name_is_empty()
        {
            SUT.FirstName = string.Empty;

            Assert.That(SUT.IsValid, Is.False);
            Assert.That(SUT.FirstName, Is.Empty);
        }

        [Test]
        public void When_last_name_is_empty()
        {
            SUT.LastName = string.Empty;

            Assert.That(SUT.IsValid, Is.False);
            Assert.That(SUT.LastName, Is.Empty);
        }

        [Test]
        public void When_first_name_is_longer_than_allowed()
        {
            SUT.FirstName = new string('a', 50);

            Assert.That(SUT.IsValid, Is.False);
            Assert.That(SUT.FirstName, Is.Not.Empty);
            Assert.That(SUT.FirstName.Length, Is.GreaterThan(20));
        }

        [Test]
        public void When_last_name_is_longer_than_allowed()
        {
            SUT.LastName = new string('a', 50);

            Assert.That(SUT.IsValid, Is.False);
            Assert.That(SUT.LastName, Is.Not.Empty);
            Assert.That(SUT.LastName.Length, Is.GreaterThan(20));
        }
    }


    public class Person
    {
        private int _id;

        public int Id
        {
            get { return _id; }
        }

        private string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsValid 
        {
            get
            {
                var nameRule = new NameRule();
                return !(nameRule.IsBrokenBy(FirstName) || nameRule.IsBrokenBy(LastName));
            }
        }

        public IDomainService DomainService { get; set; }

        public void DoSomething()
        {
            DomainService.DoSomething();
        }
    }

    internal abstract class Rule
    {
        public abstract bool IsBrokenBy(string value);
    }

    class NameRule : Rule
    {
        public override bool IsBrokenBy(string value)
        {
            return new RequiredRule().IsBrokenBy(value) || new LongerThanRule(20).IsBrokenBy(value);
        }
    }

    class LongerThanRule : Rule
    {
        private int _maxLength;

        public LongerThanRule(int maxLength)
        {
            _maxLength = maxLength;
        }

        public override bool IsBrokenBy(string value)
        {
            return value.Length > _maxLength;
        }
    }

    class RequiredRule : Rule
    {
        public override bool IsBrokenBy(string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }

    public interface IDomainService
    {
        void DoSomething();
    }
}