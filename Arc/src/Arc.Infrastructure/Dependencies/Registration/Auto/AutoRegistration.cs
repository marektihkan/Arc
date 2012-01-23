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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Arc.Infrastructure.Configuration;
using Arc.Domain.Dsl;

namespace Arc.Infrastructure.Dependencies.Registration.Auto
{
    /// <summary>
    /// Auto registration.
    /// </summary>
    public class AutoRegistration : IConfiguration<IServiceLocator>, IBindingSyntax, IPickingSyntax
    {
        private ITypeRegistrationStrategy _strategy;
        private readonly Assembly[] _assemblies;
        private Func<Type, bool> _criteria;

        private AutoRegistration(Assembly[] assemblies)
        {
            _assemblies = assemblies;
        }


        /// <summary>
        /// ServiceLocator for the specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns></returns>
        public static IPickingSyntax For(params Assembly[] assemblies)
        {
            return new AutoRegistration(assemblies);
        }

        /// <summary>
        /// ServiceLocator for the specified assembly names.
        /// </summary>
        /// <param name="assemblyNames">The assembly names.</param>
        /// <returns></returns>
        public static IPickingSyntax For(params string[] assemblyNames)
        {
            var assemblies = new List<Assembly>();
            assemblyNames.Each(name => assemblies.Add(Assembly.Load(name)));
            return new AutoRegistration(assemblies.ToArray());
        }


        /// <summary>
        /// Picks types by the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Binding syntax.</returns>
        public IBindingSyntax Pick(Func<Type, bool> criteria)
        {
            _criteria = criteria;
            return this;
        }

        /// <summary>
        /// Picks all concrete types.
        /// </summary>
        /// <value>Binding syntax.</value>
        public IBindingSyntax AllConcreteTypes
        {
            get { return Pick(x => !x.IsInterface && !x.IsAbstract); }
        }


        /// <summary>
        /// Binds to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria. (interface)</param>
        /// <returns>ServiceLocator.</returns>
        public AutoRegistration BindToInterface(Func<Type, bool> criteria)
        {
            _strategy = new RegisterTypeToFirstMatchStrategy(criteria);
            return this;
        }

        /// <summary>
        /// Binds to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria. (interface, realType)</param>
        /// <returns></returns>
        public AutoRegistration BindToInterface(Func<Type, Type, bool> criteria)
        {
            _strategy = new RegisterTypeToFirstMatchStrategy(criteria);
            return this;
        }

		/// <summary>
		/// Binds all to the specified criteria.
		/// </summary>
		/// <param name="criteria">The criteria. (interface)</param>
		/// <returns></returns>
		public AutoRegistration BindToInterfaces(Func<Type, bool> criteria)
		{
			_strategy = new RegisterTypeToAllMatchStrategy(criteria);
			return this;
		}

        /// <summary>
        /// Binds to self.
        /// </summary>
        /// <returns>ServiceLocator.</returns>
        public AutoRegistration BindToSelf()
        {
            _strategy = new RegisterTypeToSelfStrategy();
            return this;
        }

        /// <summary>
        /// Binds to first interface.
        /// </summary>
        /// <returns>ServiceLocator.</returns>
        public AutoRegistration BindToFirstInterface()
        {
            return BindToInterface(x => x.IsInterface);
        }

        /// <summary>
        /// Registers with the specified life style.
        /// </summary>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        public AutoRegistration Using(ServiceLifeStyle lifeStyle)
        {
            _strategy.Scope = lifeStyle;
            return this;
        }


        /// <summary>
        /// Loads configuration to service locator.
        /// </summary>
        /// <param name="handler">The service locator.</param>
        public void Load(IServiceLocator handler)
        {
            foreach (var assembly in _assemblies)
            {
                RegisterTypes(assembly, handler);
            }
        }

        private void RegisterTypes(Assembly assembly, IServiceLocator locator)
        {
            assembly.GetTypes()
                .Where(type => !IsConcreteTypeAndMatchForCriteria(type))
                .Each(type => _strategy.Register(type, locator));
        }

        private bool IsConcreteTypeAndMatchForCriteria(Type type)
        {
            return !_criteria.Invoke(type) || type.IsInterface || type.IsAbstract;
        }
    }
}