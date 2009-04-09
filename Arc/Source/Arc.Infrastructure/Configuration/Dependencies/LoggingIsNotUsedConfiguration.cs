using System;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Logging;

namespace Arc.Infrastructure.Configuration.Dependencies
{
    public class LoggingIsNotUsedConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<ILogger>().IsImplementedBy<NullLogger>()
            );
        }
    }
}