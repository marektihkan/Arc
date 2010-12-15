using System;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Results;

namespace Arc.Infrastructure.Validation.FluentValidation
{
    public class Validator<TEntity> : IValidator<TEntity>
    {
        private readonly ValidatorAdapter<TEntity> _validator = new ValidatorAdapter<TEntity>();

        public void Custom(Func<TEntity, ValidationFailure> customValidator)
        {
            _validator.Custom(customValidator);
        }

        public IRuleBuilder<TEntity, TProperty> RuleFor<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            return _validator.RuleFor(expression);
        }

        public IValidationResults Validate(TEntity validatable)
        {
            return new ValidationResultsAdapter(_validator.Validate(validatable));
        }

        public IValidationResults Validate(object validatable)
        {
            if (!(validatable is TEntity))
            {
                var message = "Validatable object is not type of " + typeof (TEntity).FullName;
                throw new ArgumentException(message, "validatable");
            }

            return Validate((TEntity) validatable);
        }
    }

    internal class ValidatorAdapter<TEntity> : AbstractValidator<TEntity>
    {
    }
}