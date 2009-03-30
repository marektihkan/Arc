using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Service locator configuration.
    /// </summary>
    public interface IServiceLocatorConfiguration : IToLoggingConfigurationSyntax
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
        /// Imports convention to service locator.
        /// </summary>
        /// <param name="convention">The convention.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration With(IConvention<IServiceLocator> convention);
    }
}