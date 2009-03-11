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

using System.Linq.Expressions;
using NHibernate.Criterion;
using Expression=System.Linq.Expressions.Expression;

namespace Arc.Infrastructure.Data.NHibernate.Specifications
{
    internal class BinaryActionProcessor : IActionProcessor
    {
        private readonly BinaryExpression _expression;
        private readonly ExpressionType _operand;

        public BinaryActionProcessor(BinaryExpression expression)
        {
            _expression = expression;
            _operand = expression.NodeType;

            Criterions = new Pair<ICriterion>();
            Properties = new Pair<string>();
            Values = new Pair<object>();
        }

        public ICriterion Process()
        {
            ProcessSide(_expression.Left);
            ProcessSide(_expression.Right);

            return BuildCriterion();
        }

        private ICriterion BuildCriterion()
        {
            if (Criterions.HasValues)
                return RestrictionsFactory.Create(_operand, Criterions.First, Criterions.Second);
 
            if (Properties.HasBothValues)
                return PropertyRestrictionsFactory.Create(_operand, Properties.First, Properties.Second);

            if (Properties.HasValues)
                return RestrictionsFactory.Create(_operand, Properties.First, Values.First);

            return null;
        }

        private void ProcessSide(Expression expression)
        {
            if (ActionProcessor.IsActionExpression(expression))
                Criterions.Add(new ActionProcessor().Process(expression));
            else if (MemberFinder.IsPropertyExpression(expression))
                Properties.Add(MemberFinder.FindFromExpression(expression));
            else if (ValueFinder.IsValueExpression(expression))
                Values.Add(ValueFinder.FindFromExpression(expression));
        }


        public Pair<ICriterion> Criterions { get; set; }
        public Pair<string> Properties { get; set; }
        public Pair<object> Values { get; set; }
    }
}