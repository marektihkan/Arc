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

using System.Linq.Expressions;

namespace Arc.Infrastructure.Data.NHibernate.Specifications
{
    /// <summary>
    /// Finds member path from expression.
    /// </summary>
    public static class MemberFinder
    {
        /// <summary>
        /// Finds member path from expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>Member path.</returns>
        public static string FindFromExpression(Expression expression)
        {
            var memberExpression = Utilities.Expressions.MemberFinder.FindMemberExpression(expression);

            if (AliasFinder.IsAliasExpression(expression))
                memberExpression = expression as MemberExpression;

            return Utilities.Expressions.MemberFinder.BuildMemberName(memberExpression);
        }

        /// <summary>
        /// Determines whether the specified expression is property expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>
        /// 	<c>true</c> if the specified expression is property expression; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPropertyExpression(Expression expression)
        {
            return Utilities.Expressions.MemberFinder.IsPropertyExpression(expression) || IsAlias(expression);
        }

        private static bool IsAlias(Expression expression)
        {
            return AliasFinder.IsAliasExpression(expression);
        }

    }
}