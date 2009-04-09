using System;

namespace Arc.Infrastructure.Validation
{
    /// <summary>
    /// Null validation service.
    /// </summary>
    public class NullValidationService : IValidationService
    {
        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <param name="validatable">The validatable.</param>
        /// <returns>Empty validation results.</returns>
        public IValidationResults Validate(object validatable)
        {
            return new EmptyValidationResults();
        }

        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <typeparam name="T">Validatable type.</typeparam>
        /// <param name="validatable">The validatable.</param>
        /// <returns>Empty validation results.</returns>
        public IValidationResults Validate<T>(object validatable)
        {
            return new EmptyValidationResults();
        }

        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <param name="validatable">The validatable.</param>
        /// <param name="validationType">Type of the validation.</param>
        /// <returns>Empty validation results.</returns>
        public IValidationResults Validate(object validatable, Type validationType)
        {
            return new EmptyValidationResults();
        }
    }
}