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
    public abstract class BaseRange<T> : IRange<T>
    {
        private bool _isLowerInclusive;
        private bool _isUpperInclusive;
        private T _lower;
        private T _upper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRange{T}"/> class.
        /// </summary>
        protected BaseRange() : this(default(T), true, default(T), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRange{T}"/> class.
        /// </summary>
        /// <param name="lower">The lower bound.</param>
        /// <param name="upper">The upper bound.</param>
        protected BaseRange(T lower, T upper) : this(lower, true, upper, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRange{T}"/> class.
        /// </summary>
        /// <param name="lower">The lower bound.</param>
        /// <param name="upper">The upper bound.</param>
        /// <param name="isUpperInclusive">if set to <c>true</c> upper bound is inclusive.</param>
        /// <param name="isLowerInclusive">if set to <c>true</c> lower bound is inclusive.</param>
        protected BaseRange(T lower, bool isLowerInclusive, T upper, bool isUpperInclusive)
        {
            _upper = upper;
            _lower = lower;
            _isUpperInclusive = isUpperInclusive;
            _isLowerInclusive = isLowerInclusive;
        }


        /// <summary>
        /// Gets or sets the upper bound.
        /// </summary>
        /// <value>The upper bound.</value>
        public virtual T Upper
        {
            get { return _upper; }
            set { _upper = value; }
        }

        /// <summary>
        /// Gets or sets the lower bound.
        /// </summary>
        /// <value>The lower bound.</value>
        public virtual T Lower
        {
            get { return _lower; }
            set { _lower = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is upper bound inclusive.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is upper bound inclusive; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsUpperInclusive
        {
            get { return _isUpperInclusive; }
            set { _isUpperInclusive = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is lower bound inclusive.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is lower bound inclusive; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsLowerInclusive
        {
            get { return _isLowerInclusive; }
            set { _isLowerInclusive = value; }
        }

        /// <summary>
        /// Determines whether the specified element contains in range.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// 	<c>true</c> if the specified element contains in range; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool Contains(T element);

        /// <summary>
        /// Determines whether the specified range contains in this range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <returns>
        /// 	<c>true</c> if the specified range contains in this range; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool Contains(BaseRange<T> range);
    }
}