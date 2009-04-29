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
using Rhino.Mocks;

namespace Arc.Testing.Utilities
{
    /// <summary>
    /// Auto mocker.
    /// </summary>
    public class AutoMocker : IAutoMocker
    {
        private IDictionary<Type, object> Dependencies { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMocker"/> class.
        /// </summary>
        public AutoMocker()
        {
            Dependencies = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Gets mocked instance of specified type.
        /// </summary>
        /// <typeparam name="T">Type of mock.</typeparam>
        /// <returns>Mocked instance.</returns>
        public T Get<T>() where T : class
        {
            var requestedType = typeof(T);
            if (Dependencies.ContainsKey(requestedType)) return (T) Dependencies[requestedType];

            var mock = MockRepository.GenerateMock<T>();
            Dependencies.Add(requestedType, mock);
            return mock;
        }
    }
}