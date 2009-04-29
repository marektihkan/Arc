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
    internal static class ProcessorFactory
    {
        public static IActionProcessor Create(Expression expression)
        {
            if (expression is BinaryExpression)
                return new BinaryActionProcessor(expression as BinaryExpression);

            if (expression is UnaryExpression)
                return new UnaryActionProcessor(expression as UnaryExpression);

            if (expression is MethodCallExpression)
                return new MethodActionProcessor(expression as MethodCallExpression);

            if (expression is InvocationExpression)
                return new InvocationActionProcessor(expression as InvocationExpression);

            return new NullActionProcessor();
        }
    }

    internal class InvocationActionProcessor : IActionProcessor
    {
        private readonly InvocationExpression _expression;

        public InvocationActionProcessor(InvocationExpression expression)
        {
            _expression = expression;
        }

        public ICriterion Process()
        {
            var expression = _expression.Expression;
            if (expression is LambdaExpression)
            {
                var lambdaExpression = expression as LambdaExpression;
                return ProcessorFactory.Create(lambdaExpression.Body).Process();
            }
            return ProcessorFactory.Create(expression).Process();
        }
    }
}