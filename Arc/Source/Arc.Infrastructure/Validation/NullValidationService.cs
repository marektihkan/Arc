using System;

namespace Arc.Infrastructure.Validation
{
    public class NullValidationService : IValidationService
    {
        public IValidationResults Validate(object validatable)
        {
            return new EmptyValidationResults();
        }

        public IValidationResults Validate<T>(object validatable)
        {
            return new EmptyValidationResults();
        }

        public IValidationResults Validate(object validatable, Type validationType)
        {
            return new EmptyValidationResults();
        }
    }
}