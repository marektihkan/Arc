#region License
//
//   Copyright 2009 Marek Tihkan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License
//
#endregion

using System.Collections.Generic;
using System.Reflection;
using Arc.Domain.Dsl;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration.Auto;

namespace Arc.Infrastructure.Configuration.Conventions
{
    /// <summary>
    /// Base class for conventions.
    /// </summary>
    public abstract class ServiceLocatorConvention : IConvention<IServiceLocator>
    {
        private IList<AutoRegistration> Configurations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorConvention"/> class.
        /// </summary>
        public ServiceLocatorConvention()
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
            Configurations.Each(configuration => handler.Load(configuration)); 
        }

        /// <summary>
        /// Defines the rules of convention.
        /// </summary>
        protected abstract void DefineRules();
    }
}