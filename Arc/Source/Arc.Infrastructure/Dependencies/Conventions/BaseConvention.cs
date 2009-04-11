using System.Collections.Generic;
using System.Reflection;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Domain.Dsl;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Dependencies.Registration.Auto;

namespace Arc.Infrastructure.Dependencies.Conventions
{
    /// <summary>
    /// Base class for conventions.
    /// </summary>
    public abstract class BaseConvention : IConvention<IServiceLocator>
    {
        private IList<AutoRegistration> Configurations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConvention"/> class.
        /// </summary>
        public BaseConvention()
        {
            Configurations = new List<AutoRegistration>();
        }

        /// <summary>
        /// Applies convention for specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns></returns>
        public IPickingSyntax For(params Assembly[] assemblies)
        {
            var configuration = (AutoRegistration)AutoRegistration.For(assemblies);
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
            var configuration = (AutoRegistration) AutoRegistration.For(assemblyNames);
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