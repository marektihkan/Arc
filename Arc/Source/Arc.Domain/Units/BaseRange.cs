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