using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using log4net;

namespace Arc.Infrastructure.Logging.Log4Net
{
    public class LoggingConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<ILog>().IsConstructedBy(x => LogManager.GetLogger("Default")),
                Requested.Service<ILogger>().IsImplementedBy<Logger>()
            );
        }
    }
}