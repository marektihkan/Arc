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

namespace Arc.Domain.Units
{
    /// <summary>
    /// Range.
    /// </summary>
    /// <typeparam name="T">Type of range element.</typeparam>
    public interface IRange<T>
    {
        /// <summary>
        /// Gets or sets the upper bound.
        /// </summary>
        /// <value>The upper bound.</value>
        T Upper { get; set; }

        /// <summary>
        /// Gets or sets the lower bound.
        /// </summary>
        /// <value>The lower bound.</value>
        T Lower { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is upper bound inclusive.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is upper bound inclusive; otherwise, <c>false</c>.
        /// </value>
        bool IsUpperInclusive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is lower bound inclusive.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is lower bound inclusive; otherwise, <c>false</c>.
        /// </value>
        bool IsLowerInclusive { get; set; }

        /// <summary>
        /// Determines whether the specified element contains in range.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// 	<c>true</c> if the specified element contains in range; otherwise, <c>false</c>.
        /// </returns>
        bool Contains(T element);

        /// <summary>
        /// Determines whether the specified range contains in this range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <returns>
        /// 	<c>true</c> if the specified range contains in this range; otherwise, <c>false</c>.
        /// </returns>
        bool Contains(BaseRange<T> range);
    }
}