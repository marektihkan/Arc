using System;
using Arc.Infrastructure.Logging;
using Arc.Infrastructure.Utilities;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Logging provider configuration.
    /// </summary>
    public class LoggingProviderConfiguration : ILoggingProviderConfiguration, IToValidationConfigurationSyntax, ILoggingConfiguration
    {
        private readonly IServiceLocatorConfigurationAware _serviceLocator;


        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingProviderConfiguration"/> class.
        /// </summary>
        /// <param name="serviceLocatorConfigurationAware">The service locator configuration aware.</param>
        public LoggingProviderConfiguration(IServiceLocatorConfigurationAware serviceLocatorConfigurationAware)
        {
            _serviceLocator = serviceLocatorConfigurationAware;
        }


        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        /// <returns></returns>
        public ILoggingConfiguration ProviderTo(string providerFullName)
        {
            var provider = Find.TypeWithInterface<ILogger>(providerFullName);
            return ProviderTo(provider);
        }

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <typeparam name="TProvider">The type of the provider.</typeparam>
        /// <returns></returns>
        public ILoggingConfiguration ProviderTo<TProvider>() where TProvider : ILogger
        {
            return ProviderTo(typeof(TProvider));
        }

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <returns></returns>
        public ILoggingConfiguration ProviderTo(Type provider)
        {
            _serviceLocator.Configuration.Register(typeof(ILogger), provider);
            return this;
        }

        /// <summary>
        /// Sets provider to null type.
        /// </summary>
        /// <returns></returns>
        public IToValidationConfigurationSyntax IsNotUsed()
        {
            ProviderTo<NullLogger>();
            return this;
        }

        /// <summary>
        /// Unites configurations.
        /// </summary>
        /// <value>Next configuration.</value>
        public IConfigureValidationSyntax And
        {
            get { return new Configure(); }
        }

        /// <summary>
        /// Configures log name.
        /// </summary>
        /// <param name="logName">Name of the log.</param>
        /// <returns></returns>
        public IToValidationConfigurationSyntax WithLogNamed(string logName)
        {

            return this;
        }
    }
}