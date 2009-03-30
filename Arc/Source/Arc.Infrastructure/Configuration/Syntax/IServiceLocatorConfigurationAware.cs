namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Configurations which are aware of service locator configuration.
    /// </summary>
    public interface IServiceLocatorConfigurationAware
    {
        /// <summary>
        /// Gets the service locator configuration.
        /// </summary>
        /// <value>The configuration.</value>
        Infrastructure.Dependencies.IServiceLocatorConfiguration Configuration { get; }
    }
}