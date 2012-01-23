using System;
using Arc.Domain.Identity;
using NHibernate.Validator.Constraints;

namespace Arc.Integration.Tests.Fakes.Validation
{
    public class DomainEntity : IEntity
    {
        public int Id { get; set; }

        [NotNull] //NHibernate Validator
        public string Name { get; set; }

		public Type GetUnproxiedType()
		{
			return GetType();
		}
    }
}