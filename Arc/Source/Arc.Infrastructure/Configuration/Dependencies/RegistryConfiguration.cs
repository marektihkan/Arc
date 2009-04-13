using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Registry;

namespace Arc.Infrastructure.Configuration.Dependencies
{
    /// <summary>
    /// Registers registries to service locator.
    /// </summary>
    public class RegistryConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        /// <summary>
        /// Configures the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<IWebSessionRegistry>().IsImplementedBy<WebSessionRegistry>(),
            
                Requested.Service<IWebRequestRegistry>().IsImplementedBy<WebRequestRegistry>(),
                
                Requested.Service<IThreadRegistry>().IsImplementedBy<ThreadRegistry>(),
                
                Requested.Service<ILocalRegistry>().IsImplementedBy<LocalRegistry>(),
                
                Requested.Service<IHybridRegistry>().IsImplementedBy<HybridRegistry>()
            );
        }
    }
}