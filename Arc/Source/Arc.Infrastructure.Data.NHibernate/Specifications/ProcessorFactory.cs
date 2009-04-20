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