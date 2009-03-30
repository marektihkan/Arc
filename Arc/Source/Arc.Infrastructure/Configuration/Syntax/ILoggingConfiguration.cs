namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Logging configuration.
    /// </summary>
    public interface ILoggingConfiguration
    {
        /// <summary>
        /// Configures log name.
        /// </summary>
        /// <param name="logName">Name of the log.</param>
        /// <returns></returns>
        IToValidationConfigurationSyntax WithLogNamed(string logName);
    }
}