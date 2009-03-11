using System;
using Arc.Domain.Identity;

namespace Arc.Unit.Tests.Fakes.Identity
{
    public class GuidIdentityEntityTester : GuidIdentityEntity
    {
        public void SetId(Guid identity)
        {
            Id = identity;
        }

        public void SetVersion(int version)
        {
            Version = version;
        }
    }
}