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

namespace Arc.Domain.Units
{
    /// <summary>
    /// Range for comparable objects.
    /// </summary>
    /// <typeparam name="T">Type of range element.</typeparam>
    public class Range<T> : BaseRange<T> where T : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/> class.
        /// </summary>
        public Range()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/> class.
        /// </summary>
        /// <param name="lower">The lower bound.</param>
        /// <param name="upper">The upper bound.</param>
        public Range(T lower, T upper) : base(lower, upper)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/> class.
        /// </summary>
        /// <param name="lower">The lower bound.</param>
        /// <param name="isLowerInclusive">if set to <c>true</c> lower bound is inclusive.</param>
        /// <param name="upper">The upper bound.</param>
        /// <param name="isUpperInclusive">if set to <c>true</c> upper bound is inclusive.</param>
        public Range(T lower, bool isLowerInclusive, T upper, bool isUpperInclusive) : 
            base(lower, isLowerInclusive, upper, isUpperInclusive)
        {
        }


        /// <summary>
        /// Determines whether the specified element contains in range.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// 	<c>true</c> if the specified element contains in range; otherwise, <c>false</c>.
        /// </returns>
        public override bool Contains(T element)
        {
            //NOTE: when element is null it is considered that it includes in range.
            if (element == null) return true;

            var lowerBoundCompare = (IsLowerInclusive) ? 0 : 1;
            var upperBoundCompare = (IsUpperInclusive) ? 0 : -1;

            return (Lower == null || element.CompareTo(Lower) >= lowerBoundCompare)
                && (Upper == null || element.CompareTo(Upper) <= upperBoundCompare);
        }

        /// <summary>
        /// Determines whether the specified range contains in this range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <returns>
        /// 	<c>true</c> if the specified range contains in this range; otherwise, <c>false</c>.
        /// </returns>
        public override bool Contains(BaseRange<T> range)
        {
            //NOTE: When range is null (empty range) it should contain in any other range.
            if (range == null) return true;

            if (IsInfinityAtOppositeSides(range))
                return false;

            return Contains(range.Lower) && Contains(range.Upper);
        }

        private bool IsInfinityAtOppositeSides(IRange<T> range)
        {
            return (range.Lower == null && Lower != null) || (range.Upper == null && Upper != null);
        }
    }
}