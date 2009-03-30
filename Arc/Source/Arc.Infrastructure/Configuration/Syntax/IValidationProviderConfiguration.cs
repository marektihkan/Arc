using System;
using Arc.Infrastructure.Validation;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Configuration for validation provider.
    /// </summary>
    public interface IValidationProviderConfiguration
    {
        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        void ProviderTo(string providerFullName);

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <typeparam name="TProvider">The type of the provider.</typeparam>
        void ProviderTo<TProvider>() where TProvider : IValidationService;

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="provider">The provider.</param>
        void ProviderTo(Type provider);

        /// <summary>
        /// Sets provider to null provider.
        /// </summary>
        void IsNotUsed();
    }
}