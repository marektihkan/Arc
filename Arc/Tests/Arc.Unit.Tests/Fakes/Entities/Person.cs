using System.Collections.Generic;
using Arc.Domain.Identity;

namespace Arc.Unit.Tests.Fakes.Entities
{
    public class Person : IntegerIdentityEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public BehaviorType Behavior { get; set; }
        public bool IsActiveMember { get; set; }
        public IList<Person> Contacts { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }

    public enum BehaviorType
    {
        Agressive,
        Calm
    }
}