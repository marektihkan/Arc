using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Logging;

namespace Arc.Infrastructure.Configuration.Dependencies
{
    /// <summary>
    /// Configuration for logging when its not used.
    /// </summary>
    public class LoggingIsNotUsedConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        /// <summary>
        /// Configures the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<ILogger>().IsImplementedBy<NullLogger>()
            );
        }
    }
}