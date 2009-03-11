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