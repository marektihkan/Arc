using Arc.Infrastructure.Configuration.Syntax;

namespace Arc.Infrastructure.Configuration
{
    /// <summary>
    /// DSL for configuring Arc application.
    /// </summary>
    public class Configure
    {
        private static readonly IServiceLocatorProviderConfiguration _serviceLocatorProviderConfiguration;

        /// <summary>
        /// Initializes the <see cref="Configure"/> class.
        /// </summary>
        static Configure()
        {
            _serviceLocatorProviderConfiguration = new ServiceLocatorProviderConfiguration();
        }


        /// <summary>
        /// Gets the service locator provider configuration.
        /// </summary>
        /// <value>The service locator provider configuration.</value>
        public static IServiceLocatorProviderConfiguration ServiceLocator
        {
            get
            {
                return _serviceLocatorProviderConfiguration;
            }
        }
    }
}