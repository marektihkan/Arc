namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Syntax for navigating validation provider configuration.
    /// </summary>
    public interface IToValidationConfigurationSyntax
    {
        /// <summary>
        /// Unites configurations.
        /// </summary>
        /// <value>Next configuration.</value>
        IConfigureValidationSyntax And { get; }
    }
}