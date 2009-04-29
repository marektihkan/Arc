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
using Arc.Infrastructure.Utilities.Expressions;
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