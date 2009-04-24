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

namespace Arc.Domain.Units
{
    /// <summary>
    /// Range for nullable structures.
    /// </summary>
    /// <typeparam name="T">Type of range element structure.</typeparam>
    public class NullableRange<T> : BaseRange<T?> where T : struct, IComparable  
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableRange&lt;T&gt;"/> class.
        /// </summary>
        public NullableRange()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableRange&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="lower">The lower bound.</param>
        /// <param name="upper">The upper bound.</param>
        public NullableRange(T? lower, T? upper) : base(lower, upper)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableRange&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="lower">The lower bound.</param>
        /// <param name="isLowerInclusive">if set to <c>true</c> lower bound is inclusive.</param>
        /// <param name="upper">The upper bound.</param>
        /// <param name="isUpperInclusive">if set to <c>true</c> upper bound is inclusive.</param>
        public NullableRange(T? lower, bool isLowerInclusive, T? upper, bool isUpperInclusive) : base(lower, isLowerInclusive, upper, isUpperInclusive)
        {
        }


        /// <summary>
        /// Determines whether the specified element contains in range.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// 	<c>true</c> if the specified element contains in range; otherwise, <c>false</c>.
        /// </returns>
        public override bool Contains(T? element)
        {
            return BuildRangeFrom(this).Contains(ConvertToComparableElement(element));
        }

        /// <summary>
        /// Determines whether the specified range contains in this range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <returns>
        /// 	<c>true</c> if the specified range contains in this range; otherwise, <c>false</c>.
        /// </returns>
        public override bool Contains(BaseRange<T?> range)
        {
            var comparableRange = BuildRangeFrom(range);
            return BuildRangeFrom(this).Contains(comparableRange);
        }

        private static IComparable ConvertToComparableElement(T? element)
        {
            return (element.HasValue) ? element.Value : default(IComparable);
        }

        private static BaseRange<IComparable> BuildRangeFrom(IRange<T?> range)
        {
            if (range == null)
                return null;

            var lowerBound = ConvertToComparableElement(range.Lower);
            var upperBound = ConvertToComparableElement(range.Upper);
            var isLowerInclusive = range.IsLowerInclusive;
            var isUpperInclusive = range.IsUpperInclusive;

            return new Range<IComparable>(lowerBound, isLowerInclusive, upperBound, isUpperInclusive);
        }
    }
}