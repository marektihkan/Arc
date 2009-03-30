using System;
using Arc.Infrastructure.Logging;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Logging provider configuration.
    /// </summary>
    public interface ILoggingProviderConfiguration
    {
        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        /// <returns></returns>
        ILoggingConfiguration ProviderTo(string providerFullName);

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <typeparam name="TProvider">The type of the provider.</typeparam>
        /// <returns></returns>
        ILoggingConfiguration ProviderTo<TProvider>() where TProvider : ILogger;

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <returns></returns>
        ILoggingConfiguration ProviderTo(Type provider);

        /// <summary>
        /// Sets provider to null type.
        /// </summary>
        /// <returns></returns>
        IToValidationConfigurationSyntax IsNotUsed();
    }
}