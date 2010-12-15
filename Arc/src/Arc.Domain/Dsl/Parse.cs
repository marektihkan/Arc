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
using Arc.Domain.Dsl.Parsing;

namespace Arc.Domain.Dsl
{
    /// <summary>
    /// DSL for parsing values.
    /// </summary>
    public static class Parse
    {
        /// <summary>
        /// Parses integer from string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Parsing result.</returns>
        public static IParsingResult<int> Integer(string number)
        {
            int result;
            if (int.TryParse(number, out result))
            {
                return new ParsingResult<int>(result);
            }
            return new EmptyParsingResult<int>();
        }

        /// <summary>
        /// Parses decimal from string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Parsing result.</returns>
        public static IParsingResult<decimal> Decimal(string number)
        {
            decimal result;
            if (decimal.TryParse(number, out result))
            {
                return new ParsingResult<decimal>(result);
            }
            return new EmptyParsingResult<decimal>();
        }

        /// <summary>
        /// Parses date and time from string.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>Parsing result.</returns>
        public static IParsingResult<DateTime> DateTime(string time)
        {
            DateTime result;
            if (System.DateTime.TryParse(time, out result))
            {
                return new ParsingResult<DateTime>(result);
            }
            return new EmptyParsingResult<DateTime>();
        }
    }
}