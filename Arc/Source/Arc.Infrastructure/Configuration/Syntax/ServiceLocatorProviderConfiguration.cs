using System;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Utilities;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Configuration for service locator provider.
    /// </summary>
    public class ServiceLocatorProviderConfiguration : IServiceLocatorProviderConfiguration, IServiceLocatorConfigurationAware, IServiceLocatorConfiguration
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
            ServiceLocator.InnerServiceLocator = _locator;
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
                ServiceLocator.Configuration.Load(moduleName);
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
                ServiceLocator.Configuration.Load(module);
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

        /// <summary>
        /// Unites to configurations.
        /// </summary>
        /// <value>Next configuration.</value>
        public IConfigureLoggingSyntax And
        {
            get { return new Configure(); }
        }

        /// <summary>
        /// Gets the service locator configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public Infrastructure.Dependencies.IServiceLocatorConfiguration Configuration
        {
            get { return _locator.Configuration; }
        }
    }
}