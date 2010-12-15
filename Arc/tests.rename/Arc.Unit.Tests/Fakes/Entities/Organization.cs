using Arc.Domain.Identity;

namespace Arc.Unit.Tests.Fakes.Entities
{
    public class Organization : IntegerIdentityEntity
    {
        public Organization()
        {
        }

        public Organization(int identity) : base(identity)
        {
        }

        public string Name { get; set; }
    }
}