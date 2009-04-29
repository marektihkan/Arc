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
using NHibernate.Criterion;
using Expression=System.Linq.Expressions.Expression;

namespace Arc.Infrastructure.Data.NHibernate.Specifications
{
    internal class ExpressionProcessor
    {
        public static ICriterion Process(Expression expression)
        {
            if (ActionProcessor.IsActionExpression(expression))
                return new ActionProcessor().Process(expression);

            if (MemberFinder.IsPropertyExpression(expression) && expression.Type == typeof(bool))
                return RestrictionsFactory.Create(ExpressionType.Equal, MemberFinder.FindFromExpression(expression), true);

            return null;
        }
    }
}