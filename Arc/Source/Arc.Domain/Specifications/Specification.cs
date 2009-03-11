using System;
using System.Linq.Expressions;

namespace Arc.Domain.Specifications
{
    /// <summary>
    /// Generic specification with lambda.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    public class Specification<T> : BaseSpecification<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Specification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public Specification(Expression<Func<T, bool>> expression)
        {
            Predicate = expression;
        }
    }
}