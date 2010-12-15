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
    /// Time period for dates. 
    /// Date part is only considered.
    /// </summary>
    public class DatePeriod : Range<DateTime>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatePeriod"/> class.
        /// </summary>
        public DatePeriod() : this(default(DateTime), default(DateTime))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatePeriod"/> class.
        /// </summary>
        /// <param name="lower">The lower bound. Beginning of date period.</param>
        /// <param name="upper">The upper bound. End of date period.</param>
        public DatePeriod(DateTime lower, DateTime upper) : this(lower, true, upper, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatePeriod"/> class.
        /// </summary>
        /// <param name="lower">The lower bound. Beginning of date period.</param>
        /// <param name="upper">The upper bound. End of date period.</param>
        /// <param name="isLowerInclusive">if set to <c>true</c> lower bound is inclusive.</param>
        /// <param name="isUpperInclusive">if set to <c>true</c> upper bound is inclusive.</param>
        public DatePeriod(DateTime lower, bool isLowerInclusive, DateTime upper, bool isUpperInclusive) : 
            base(lower.Date, isLowerInclusive, upper.Date, isUpperInclusive)
        {
        }


        /// <summary>
        /// Gets or sets beginning of date period. Considers only date part of time.
        /// </summary>
        /// <value>The beginning of date period.</value>
        public override DateTime Lower
        {
            get
            {
                return base.Lower;
            }
            set
            {
                base.Lower = value.Date;
            }
        }

        /// <summary>
        /// Gets or sets the end of date period. Considers only date part of time.
        /// </summary>
        /// <value>The end of date period.</value>
        public override DateTime Upper
        {
            get
            {
                return base.Upper;
            }
            set
            {
                base.Upper = value.Date;
            }
        }
    }
}