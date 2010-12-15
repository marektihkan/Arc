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

namespace Arc.Domain.Dsl.Parsing
{
    /// <summary>
    /// Interface for parsing result.
    /// </summary>
    /// <typeparam name="T">Parse target type.</typeparam>
    public interface IParsingResult<T>
    {
        /// <summary>
        /// Gets the parsed value.
        /// </summary>
        /// <value>The parsed value.</value>
        T Value { get; }

        /// <summary>
        /// Gets a value indicating whether parsing was successful.
        /// </summary>
        /// <value><c>true</c> if parsing was successful otherwise, <c>false</c>.</value>
        bool WasSuccessful { get; }

        /// <summary>
        /// Sets default value for unsuccessful parsing.
        /// </summary>
        /// <param name="value">The default value.</param>
        /// <returns>Parsing results.</returns>
        IParsingResult<T> Default(T value);
    }
}