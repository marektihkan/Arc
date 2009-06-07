using Arc.Domain.Identity;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using NHibernate.Validator;

namespace Arc.Integration.Tests.Fakes.Validation
{
    public class DomainEntity : IEntity
    {
        public int Id { get; set; }

        [NotNullValidator] //Enterprise Library Validation Application Block
        [NotNull] //NHibernate Validator
        public string Name { get; set; }
    }
}