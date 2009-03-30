using Arc.Infrastructure.Configuration.Syntax;

namespace Arc.Infrastructure.Configuration
{
    /// <summary>
    /// DSL for configuring Arc application.
    /// </summary>
    public class Configure : IConfigureLoggingSyntax, IConfigureValidationSyntax
    {
        private static readonly IServiceLocatorProviderConfiguration _serviceLocatorProviderConfiguration;
        private static readonly IValidationProviderConfiguration _validationProviderConfiguration;
        private static readonly ILoggingProviderConfiguration _loggingProviderConfiguration;


        /// <summary>
        /// Initializes the <see cref="Configure"/> class.
        /// </summary>
        static Configure()
        {
            var locatorProviderConfiguration = new ServiceLocatorProviderConfiguration();

            _serviceLocatorProviderConfiguration = locatorProviderConfiguration;
            
            _loggingProviderConfiguration = new LoggingProviderConfiguration(locatorProviderConfiguration);
            _validationProviderConfiguration = new ValidationProviderConfiguration(locatorProviderConfiguration);
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

        /// <summary>
        /// Gets the validation provider configuration.
        /// </summary>
        /// <value>The validation provider configuration.</value>
        public IValidationProviderConfiguration Validation
        {
            get
            {
                return _validationProviderConfiguration;
            }
        }

        /// <summary>
        /// Gets the logging provider configuration.
        /// </summary>
        /// <value>The logging provider configuration.</value>
        public ILoggingProviderConfiguration Logging
        {
            get
            {
                return _loggingProviderConfiguration;
            }
        }
    }
}