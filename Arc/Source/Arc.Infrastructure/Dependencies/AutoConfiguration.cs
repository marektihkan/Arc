#region License

// Copyright (c) 2008-2009 Marek Tihkan (marektihkan@gmail.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Marek Tihkan nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using Arc.Infrastructure.Dependencies.Bindings;
using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Auto registration.
    /// </summary>
    public class AutoConfiguration : IServiceLocatorModule<IServiceLocator>, IBindingSyntax, IPickingSyntax
    {
        private ITypeRegistrationStrategy _strategy;
        private readonly Assembly[] _assemblies;
        private Func<Type, bool> _criteria;


        private AutoConfiguration(Assembly[] assemblies)
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
            return new AutoConfiguration(assemblies);
        }

        /// <summary>
        /// ServiceLocator for the specified assembly names.
        /// </summary>
        /// <param name="assemblyNames">The assembly names.</param>
        /// <returns></returns>
        public static IPickingSyntax For(params string[] assemblyNames)
        {
            var assemblies = new List<Assembly>();
            foreach (var name in assemblyNames)
            {
                assemblies.Add(Assembly.Load(name));
            }
            return new AutoConfiguration(assemblies.ToArray());
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
        /// Binds the specified criteria.
        /// </summary>
        /// <param name="criteria">The binding.</param>
        /// <returns></returns>
        public AutoConfiguration BindToInterface(Func<Type, bool> criteria)
        {
            _strategy = new RegisterTypeToFirstMatchStrategy(criteria);
            return this;
        }

        /// <summary>
        /// Binds to self.
        /// </summary>
        /// <returns>ServiceLocator.</returns>
        public AutoConfiguration BindToSelf()
        {
            _strategy = new RegisterTypeToSelfStrategy();
            return this;
        }

        /// <summary>
        /// Binds to first interface.
        /// </summary>
        /// <returns>ServiceLocator.</returns>
        public AutoConfiguration BindToFirstInterface()
        {
            return BindToInterface(x => x.IsInterface);
        }

        /// <summary>
        /// Registers with the specified life style.
        /// </summary>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        public AutoConfiguration Using(ServiceLifeStyle lifeStyle)
        {
            _strategy.Scope = lifeStyle;
            return this;
        }


        /// <summary>
        /// Configures the specified locator.
        /// </summary>
        /// <param name="locator">The service locator.</param>
        public void Configure(IServiceLocator locator)
        {
            foreach (var assembly in _assemblies)
            {
                RegisterTypes(assembly, locator);
            }
        }

        private void RegisterTypes(Assembly assembly, IServiceLocator locator)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (IsConcreteTypeAndMatchForCriteria(type)) continue;

                _strategy.Register(type, locator);
            }
        }

        private bool IsConcreteTypeAndMatchForCriteria(Type type)
        {
            return !_criteria.Invoke(type) || type.IsInterface || type.IsAbstract;
        }
    }
}