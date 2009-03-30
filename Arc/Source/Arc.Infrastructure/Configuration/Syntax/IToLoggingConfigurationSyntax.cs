namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Syntax for navigating to logging provider configuration.
    /// </summary>
    public interface IToLoggingConfigurationSyntax
    {
        /// <summary>
        /// Unites to configurations.
        /// </summary>
        /// <value></value>
        IConfigureLoggingSyntax And { get; }
    }
}