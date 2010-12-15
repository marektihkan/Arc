namespace Arc.Infrastructure.Validation.FluentValidation
{
    public class NullValidator<TEntity> : IValidator<TEntity>
    {
        public IValidationResults Validate(TEntity validatable)
        {
            return new EmptyValidationResults();
        }

        public IValidationResults Validate(object validatable)
        {
            return new EmptyValidationResults();
        }
    }
}