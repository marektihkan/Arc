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

namespace Arc.Infrastructure.Registry
{
    /// <summary>
    /// Registry.
    /// </summary>
    public interface IRegistry
    {
        /// <summary>
        /// Registers item to the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        void Register(string key, object item);

        /// <summary>
        /// Gets item with the specified key.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Item with specified key.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Gets item with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Item with specified key.</returns>
        object Get(string key);

        /// <summary>
        /// Unregisters item from the specified key.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Unregistered item.</returns>
        T Unregister<T>(string key);

        /// <summary>
        /// Unregisters item from the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Unregistered item.</returns>
        object Unregister(string key);
    }
}