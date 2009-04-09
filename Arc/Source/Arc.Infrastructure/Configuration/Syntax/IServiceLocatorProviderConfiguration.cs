using System;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// ServiceLocator for service locator provider.
    /// </summary>
    public interface IServiceLocatorProviderConfiguration
    {
        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration ProviderTo(string providerFullName);

        /// <summary>
        /// Sets provider to specified value.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration ProviderTo(IServiceLocator provider);

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <typeparam name="TServiceLocator">The type of the service locator.</typeparam>
        /// <returns></returns>
        IServiceLocatorConfiguration ProviderTo<TServiceLocator>() where TServiceLocator : IServiceLocator;

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration ProviderTo(Type provider);
    }
}