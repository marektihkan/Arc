namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Syntax for getting validation provider configuration.
    /// </summary>
    public interface IConfigureValidationSyntax
    {
        /// <summary>
        /// Gets the validation provider configuration.
        /// </summary>
        /// <value>The validation provider configuration.</value>
        IValidationProviderConfiguration Validation { get; }
    }
}