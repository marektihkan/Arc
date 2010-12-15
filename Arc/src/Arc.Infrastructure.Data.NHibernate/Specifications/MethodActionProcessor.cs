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
using Arc.Infrastructure.Utilities.Expressions;
using NHibernate.Criterion;

namespace Arc.Infrastructure.Data.NHibernate.Specifications
{
    internal class MethodActionProcessor : IActionProcessor
    {
        private readonly MethodCallExpression _expression;

        public MethodActionProcessor(MethodCallExpression expression)
        {
            _expression = expression;
        }

        public ICriterion Process()
        {
            FindMethodName();
            FindMethodArgument();
            FindProperty();

            return BuildCriterion();
        }

        private ICriterion BuildCriterion()
        {
            var criterion = RestrictionsFactory.Create(Method, Property, Argument);

            if (criterion == null)
                throw new NotSupportedException(Method + " is not translatable.");

            return criterion;
        }

        private string Argument { get; set; }
        private string Property { get; set; }
        private string Method { get; set; }

        private void FindMethodName()
        {
            Method = _expression.Method.Name;
        }

        private void FindMethodArgument()
        {
            if (_expression.Arguments.Count > 0 && ValueFinder.IsValueExpression(_expression.Arguments[0]))
                Argument = ValueFinder.FindFromExpression(_expression.Arguments[0]).ToString();
        }

        private void FindProperty()
        {
            var propertyExpression = _expression.Object;
            if (MemberFinder.IsPropertyExpression(propertyExpression))
                Property = MemberFinder.FindFromExpression(propertyExpression);
        }
    }
}