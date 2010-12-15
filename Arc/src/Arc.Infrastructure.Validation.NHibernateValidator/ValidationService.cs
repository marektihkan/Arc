using System;
using NHibernate.Validator.Engine;

namespace Arc.Infrastructure.Validation.NHibernateValidator
{
    public class ValidationService : IValidationService
    {
        private readonly ValidatorEngine _engine;

        public ValidationService(ValidatorEngine engine)
        {
            _engine = engine;
        }

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

            var validator = _engine.GetClassValidator(validationType);
            return new ValidationResultsAdapter(validator.GetInvalidValues(validatable));
        }
    }
}