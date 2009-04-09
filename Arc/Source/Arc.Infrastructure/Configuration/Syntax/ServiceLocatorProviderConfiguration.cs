using System;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Utilities;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// ServiceLocator for service locator provider.
    /// </summary>
    public class ServiceLocatorProviderConfiguration : IServiceLocatorProviderConfiguration, IServiceLocatorConfiguration
    {
        private IServiceLocator _locator;


        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration ProviderTo(string providerFullName)
        {
            return ProviderTo(ResolveProvider<IServiceLocator>.Named(providerFullName));
        }

        /// <summary>
        /// Sets provider to specified value.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration ProviderTo(IServiceLocator provider)
        {
            _locator = provider;
            Infrastructure.Dependencies.ServiceLocator.InnerServiceLocator = _locator;
            return this;
        }

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <typeparam name="TServiceLocator">The type of the service locator.</typeparam>
        /// <returns></returns>
        public IServiceLocatorConfiguration ProviderTo<TServiceLocator>() where TServiceLocator : IServiceLocator
        {
            return ProviderTo(typeof(TServiceLocator));
        }

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration ProviderTo(Type provider)
        {
            return ProviderTo(ResolveProvider<IServiceLocator>.WithRealType(provider));
        }

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration With(string moduleName)
        {
            if (!string.IsNullOrEmpty(moduleName))
                Infrastructure.Dependencies.ServiceLocator.Load(moduleName);
            return this;
        }

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration With(IServiceLocatorModule<IServiceLocator> module)
        {
            if (module != null)
                Infrastructure.Dependencies.ServiceLocator.Load(module);
            return this;
        }

        /// <summary>
        /// Imports convention to service locator.
        /// </summary>
        /// <param name="convention">The convention.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration With(IConvention<IServiceLocator> convention)
        {
            if (convention != null)
                convention.Apply(_locator);
            return this;
        }

        public IServiceLocatorConfiguration With<TConfiguration>() where TConfiguration : IServiceLocatorModule<IServiceLocator>
        {
            var configuration = ResolveProvider<IServiceLocatorModule<IServiceLocator>>.WithRealType(typeof(TConfiguration));
            configuration.Configure(ServiceLocator);
            return this;
        }

        /// <summary>
        /// Gets the service locator.
        /// </summary>
        /// <value>The service locator.</value>
        public IServiceLocator ServiceLocator
        {
            get { return _locator; }
        }
    }
}