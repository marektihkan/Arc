using System.Collections.Generic;
using System.Reflection;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Dependencies.Bindings;
using Arc.Domain.Dsl;

namespace Arc.Infrastructure.Dependencies.Conventions
{
    /// <summary>
    /// Base class for conventions.
    /// </summary>
    public abstract class BaseConvention : IConvention<IServiceLocator>
    {
        private IList<AutoConfiguration> Configurations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConvention"/> class.
        /// </summary>
        public BaseConvention()
        {
            Configurations = new List<AutoConfiguration>();
        }

        /// <summary>
        /// Applies convention for specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns></returns>
        public IPickingSyntax For(params Assembly[] assemblies)
        {
            var configuration = (AutoConfiguration)AutoConfiguration.For(assemblies);
            Configurations.Add(configuration);
            return configuration;
        }

        /// <summary>
        /// Applies convention for specified assemblies.
        /// </summary>
        /// <param name="assemblyNames">The assembly names.</param>
        /// <returns></returns>
        public IPickingSyntax For(params string[] assemblyNames)
        {
            var configuration = (AutoConfiguration) AutoConfiguration.For(assemblyNames);
            Configurations.Add(configuration);
            return configuration;
        }

        /// <summary>
        /// Applies this convention.
        /// </summary>
        /// <param name="handler"></param>
        public void Apply(IServiceLocator handler)
        {
            DefineRules();
            Configurations.ForEach(configuration => handler.Load(configuration)); 
        }

        /// <summary>
        /// Defines the rules of convention.
        /// </summary>
        protected abstract void DefineRules();
    }
}