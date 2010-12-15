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
using System.Linq.Expressions;
using System.Reflection;

namespace Arc.Infrastructure.Utilities.Expressions
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
            var memberExpression = FindMemberExpression(expression);

            if (memberExpression == null)
                throw new ArgumentException("Could not determine member from " + expression, "expression");

            return BuildMemberName(memberExpression);
        }

        /// <summary>
        /// Builds the name of the member.
        /// </summary>
        /// <param name="memberExpression">The member expression.</param>
        /// <returns></returns>
        public static string BuildMemberName(MemberExpression memberExpression)
        {
            var result = memberExpression.Member.Name;

            while (memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = (MemberExpression)memberExpression.Expression;
                result = memberExpression.Member.Name + "." + result;
            }

            return result;
        }

        /// <summary>
        /// Finds the member expression from expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MemberExpression FindMemberExpression(Expression expression)
        {
            if (expression is MemberExpression)
                return expression as MemberExpression;
            
            if (expression is UnaryExpression)
                return FindFromUnaryExpression(expression as UnaryExpression);
            
            return null;
        }

        private static MemberExpression FindFromUnaryExpression(UnaryExpression expression)
        {
            if (expression.NodeType != ExpressionType.Convert)
                throw new ArgumentException("Cannot interpret member from " + expression, "expression");

            return (MemberExpression)expression.Operand;
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
            return IsProperty(expression) || IsCapsulatedProperty(expression);
        }

        private static bool IsCapsulatedProperty(Expression expression)
        {
            if (!(expression is UnaryExpression && expression.NodeType == ExpressionType.Convert))
                return false;

            var unaryExpression = expression as UnaryExpression;
            return unaryExpression.Operand is MemberExpression;
        }

        private static bool IsProperty(Expression expression)
        {
            if (!(expression is MemberExpression))
                return false;

            var memberExpression = expression as MemberExpression;
            return (memberExpression.Expression is ParameterExpression && memberExpression.Member is PropertyInfo)
                || (IsProperty(memberExpression.Expression));
        }
    }
}