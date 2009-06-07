namespace Arc.Infrastructure.Validation
{
    /// <summary>
    /// Validator for entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IValidator<TEntity> : IValidator
    {
        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <param name="validatable">The validatable.</param>
        /// <returns>Validation results.</returns>
        IValidationResults Validate(TEntity validatable);
    }

    public interface IValidator
    {
        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <param name="validatable">The validatable.</param>
        /// <returns>Validation results.</returns>
        IValidationResults Validate(object validatable);
    }
}