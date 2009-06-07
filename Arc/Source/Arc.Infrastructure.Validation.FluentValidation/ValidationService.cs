using System;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Validation.FluentValidation
{
    public class ValidationService : IValidationService
    {
        public IValidationResults Validate(object validatable)
        {
            return Validate(validatable, validatable.GetType());
        }

        public IValidationResults Validate<T>(object validatable)
        {
            return Validate(validatable, typeof(T));
        }

        public IValidationResults Validate(object validatable, Type validationType)
        {
            if (validatable == null) return new EmptyValidationResults();

            var type = typeof(IValidator<>);
            var validatorType = type.MakeGenericType(validationType);

            var validator = (IValidator) ServiceLocator.Resolve(validatorType);
            
            return validator.Validate(validatable);
        }
    }
}