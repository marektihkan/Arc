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
            Configurations.Each(configuration => handler.Load(configuration)); 
        }

        /// <summary>
        /// Defines the rules of convention.
        /// </summary>
        protected abstract void DefineRules();
    }
}