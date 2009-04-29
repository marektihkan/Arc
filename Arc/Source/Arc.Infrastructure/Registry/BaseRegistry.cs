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