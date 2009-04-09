using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Service locator configuration.
    /// </summary>
    public interface IServiceLocatorConfiguration
    {
        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration With(string moduleName);

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration With(IServiceLocatorModule<IServiceLocator> module);

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <typeparam name="TConfiguration">The type of the configuration.</typeparam>
        /// <returns></returns>
        IServiceLocatorConfiguration With<TConfiguration>() where TConfiguration : IServiceLocatorModule<IServiceLocator>;

        /// <summary>
        /// Imports convention to service locator.
        /// </summary>
        /// <param name="convention">The convention.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration With(IConvention<IServiceLocator> convention);
    }
}