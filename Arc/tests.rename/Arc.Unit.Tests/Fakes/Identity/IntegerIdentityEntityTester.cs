using Arc.Domain.Identity;

namespace Arc.Unit.Tests.Fakes.Identity
{
    public class IntegerIdentityEntityTester : IntegerIdentityEntity
    {
        public void SetId(int identity)
        {
            Id = identity;
        }

        public void SetVersion(int version)
        {
            Version = version;
        }
    }
}