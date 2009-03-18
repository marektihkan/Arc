using System;
using System.Linq.Expressions;
using Arc.Domain.Specifications;

namespace Arc.Unit.Tests.Fakes.Specifications
{
    public class TestSpecification<T> : BaseSpecification<T>
    {
        public TestSpecification(Expression<Func<T, bool>> expression)
        {
            BuildPredicateFrom(expression);
            AddedExpression = expression;
        }

        public Expression<Func<T, bool>> AddedExpression { get; set; }
    }
}