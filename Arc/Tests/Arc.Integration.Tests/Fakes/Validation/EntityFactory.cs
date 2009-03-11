namespace Arc.Integration.Tests.Fakes.Validation
{
    public class EntityFactory
    {
        public static DomainEntity CreateInvalidDomainEntity()
        {
            return new DomainEntity();
        }

        public static DomainEntity CreateValidDomainEntity()
        {
            return new DomainEntity { Name = "Name" };
        }
    }
}