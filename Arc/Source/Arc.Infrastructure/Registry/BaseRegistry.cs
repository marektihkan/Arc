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

using System.Collections;

namespace Arc.Infrastructure.Registry
{
    /// <summary>
    /// Base class for registry.
    /// </summary>
    public abstract class BaseRegistry : IRegistry
    {
        /// <summary>
        /// Registers item to the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        public void Register(string key, object item)
        {
            Map[key] = item;    
        }

        /// <summary>
        /// Gets item with the specified key.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Item with specified key.</returns>
        public T Get<T>(string key)
        {
            var result = Get(key);
            return (T) (result ?? default(T));
        }

        /// <summary>
        /// Gets item with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Item with specified key.</returns>
        public object Get(string key)
        {
            return (Map.Contains(key)) ? Map[key] : null;
        }

        /// <summary>
        /// Unregisters item from the specified key.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Unregistered item.</returns>
        public T Unregister<T>(string key)
        {
            return (T)Unregister(key);
        }

        /// <summary>
        /// Unregisters item from the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Unregistered item.</returns>
        public object Unregister(string key)
        {
            var result = Get(key);
            Register(key, null);
            return result;
        }

        /// <summary>
        /// Gets the map where items are stored.
        /// </summary>
        /// <value>The map.</value>
        protected abstract IDictionary Map { get; }
    }
}