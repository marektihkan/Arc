using Arc.Domain.Identity;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Arc.Integration.Tests.Fakes.Validation
{
    public class DomainEntity : IEntity
    {
        public int Id { get; set; }

        [NotNullValidator]
        public string Name { get; set; }
    }
}