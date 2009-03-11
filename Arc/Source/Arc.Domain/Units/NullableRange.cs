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