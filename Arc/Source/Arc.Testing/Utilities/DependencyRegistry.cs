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

namespace Arc.Testing.Utilities
{
    /// <summary>
    /// Registry for dependencies.
    /// </summary>
    public class DependencyRegistry : IDependencyRegistry
    {
        private IDictionary<Type, object> Dependencies { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyRegistry"/> class.
        /// </summary>
        public DependencyRegistry()
        {
            Dependencies = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Gets dependency by type.
        /// </summary>
        /// <typeparam name="T">Type of dependency.</typeparam>
        /// <returns>Dependency instance.</returns>
        public T Get<T>()
        {
            var requestedType = typeof(T);
            return (T) ((Dependencies.ContainsKey(requestedType)) ?  Dependencies[requestedType] : default(T));
        }

        /// <summary>
        /// Registers the specified dependency.
        /// </summary>
        /// <typeparam name="T">Type of dependency.</typeparam>
        /// <param name="dependency">The dependency.</param>
        public void Register<T>(T dependency)
        {
            var dependencyType = typeof(T);
            if (Dependencies.ContainsKey(dependencyType))
            {
                Dependencies[dependencyType] = dependency;
            }
            else
            {
                Dependencies.Add(dependencyType, dependency);   
            }
        }
    }
}