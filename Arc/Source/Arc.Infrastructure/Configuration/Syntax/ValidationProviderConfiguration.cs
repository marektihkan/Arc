using System;
using Arc.Infrastructure.Utilities;
using Arc.Infrastructure.Validation;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Configuration for validation provider.
    /// </summary>
    public class ValidationProviderConfiguration : IValidationProviderConfiguration
    {
        private readonly IServiceLocatorConfigurationAware _serviceLocator;


        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationProviderConfiguration"/> class.
        /// </summary>
        /// <param name="serviceLocatorConfigurationAware">The service locator configuration aware.</param>
        public ValidationProviderConfiguration(IServiceLocatorConfigurationAware serviceLocatorConfigurationAware)
        {
            _serviceLocator = serviceLocatorConfigurationAware;
        }


        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        public void ProviderTo(string providerFullName)
        {
            var provider = Find.TypeWithInterface<IValidationService>(providerFullName);
            ProviderTo(provider);
        }

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <typeparam name="TProvider">The type of the provider.</typeparam>
        public void ProviderTo<TProvider>() where TProvider : IValidationService
        {
            ProviderTo(typeof(TProvider));
        }

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public void ProviderTo(Type provider)
        {
            _serviceLocator.Configuration.Register(typeof(IValidationService), provider);
        }

        /// <summary>
        /// Sets provider to null provider.
        /// </summary>
        public void IsNotUsed()
        {
            ProviderTo<NullValidationService>();
        }
    }
}