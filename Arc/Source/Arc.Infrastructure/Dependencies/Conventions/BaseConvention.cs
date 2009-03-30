using System.Collections.Generic;
using System.Reflection;
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Dependencies.Bindings;
using Arc.Domain.Dsl;

namespace Arc.Infrastructure.Dependencies.Conventions
{
    public abstract class BaseConvention : IConvention<IServiceLocator>
    {
        private IList<AutoConfiguration> Configurations { get; set; }

        public BaseConvention()
        {
            Configurations = new List<AutoConfiguration>();
        }

        public IPickingSyntax For(params Assembly[] assemblies)
        {
            var configuration = (AutoConfiguration)AutoConfiguration.For(assemblies);
            Configurations.Add(configuration);
            return configuration;
        }

        public IPickingSyntax For(params string[] assemblyNames)
        {
            var configuration = (AutoConfiguration) AutoConfiguration.For(assemblyNames);
            Configurations.Add(configuration);
            return configuration;
        }

        public void Apply(IServiceLocator handler)
        {
            DefineRules();
            Configurations.ForEach(configuration => handler.Configuration.Load(configuration)); 
        }

        protected abstract void DefineRules();
    }
}