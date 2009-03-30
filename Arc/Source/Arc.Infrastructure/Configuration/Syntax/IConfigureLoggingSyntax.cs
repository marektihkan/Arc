namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Syntax for getting logging provider configuration.
    /// </summary>
    public interface IConfigureLoggingSyntax
    {
        /// <summary>
        /// Gets the logging provider configuration.
        /// </summary>
        /// <value>The logging provider configuration.</value>
        ILoggingProviderConfiguration Logging { get; }
    }
}