using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using log4net;

namespace Arc.Infrastructure.Logging.Log4Net
{
    /// <summary>
    /// Configuration for logging services with Log4Net.
    /// </summary>
    public class LoggingConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        /// <summary>
        /// Configures the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<ILog>().IsConstructedBy(x => LogManager.GetLogger("Default")),
                Requested.Service<ILogger>().IsImplementedBy<Logger>()
            );
        }
    }
}