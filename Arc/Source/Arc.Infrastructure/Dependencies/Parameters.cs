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
using System.Collections.Generic;

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Parameters for service locator.
    /// </summary>
    public class Parameters : IParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        public Parameters()
        {
            Arguments = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the arguments as <c>IDictionary&lt;string, object&gt;</c>.
        /// </summary>
        /// <value>The arguments.</value>
        public IDictionary<string, object> Arguments { get; private set; }

        /// <summary>
        /// Gets the arguments as IDictionary.
        /// </summary>
        /// <returns></returns>
        public IDictionary GetArguments()
        {
            var arguments = new Hashtable();
            foreach (var argument in Arguments)
            {
                arguments.Add(argument.Key, argument.Value);
            }
            return arguments;
        }

        /// <summary>
        /// Adds constructor argument.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>Parameters collecteion.</returns>
        public IParameters ConstructorArgument(string name, object value)
        {
            Arguments.Add(name, value);
            return this;
        }
    }
}