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
using System.Linq;
using System.Linq.Expressions;

namespace Arc.Domain.Specifications
{
    /// <summary>
    /// Base class for specifications.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        public Expression<Func<T, bool>> Predicate { get; protected set; }

        /// <summary>
        /// Builds the predicate from lambda expression and assigns it to Predicate.
        /// </summary>
        /// <param name="expression">The expression.</param>
        protected void BuildPredicateFrom(Expression<Func<T, bool>> expression)
        {
            Predicate = expression;
        }

        /// <summary>
        /// Adds and operator to this and other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public ISpecification<T> And(ISpecification<T> other)
        {
            return (other != null) ? new AndSpecification<T>(this, other) : this;
        }

        /// <summary>
        /// Adds or operator to this and other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public ISpecification<T> Or(ISpecification<T> other)
        {
            return (other != null) ? new OrSpecification<T>(this, other) : this;
        }

        /// <summary>
        /// Adds not operator to specification.
        /// </summary>
        /// <returns></returns>
        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        /// <summary>
        /// Determines whether specification is satisfied by item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if the specification is satisfied by the specified item; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsSatisfiedBy(T item)
        {
            return Predicate.Compile().Invoke(item);
        }

        /// <summary>
        /// And specification.
        /// </summary>
        /// <typeparam name="TSub">Specification type.</typeparam>
        private class AndSpecification<TSub> : BaseSpecification<TSub>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BaseSpecification&lt;T&gt;.AndSpecification&lt;TSub&gt;"/> class.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            public AndSpecification(ISpecification<TSub> left, ISpecification<TSub> right)
            {
                var parameters = left.Predicate.Parameters;
                var leftExpression = Expression.Invoke(left.Predicate, parameters.Cast<Expression>());
                var rightExpression = Expression.Invoke(right.Predicate, parameters.Cast<Expression>());
                var andExpression = Expression.AndAlso(leftExpression, rightExpression);
                Predicate = Expression.Lambda<Func<TSub, bool>>(andExpression, parameters);
            }
        }

        /// <summary>
        /// Or specification.
        /// </summary>
        /// <typeparam name="TSub">Specification type.</typeparam>
        private class OrSpecification<TSub> : BaseSpecification<TSub>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BaseSpecification&lt;T&gt;.OrSpecification&lt;TSub&gt;"/> class.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            public OrSpecification(ISpecification<TSub> left, ISpecification<TSub> right)
            {
                var parameters = left.Predicate.Parameters;
                var leftExpression = Expression.Invoke(left.Predicate, parameters.Cast<Expression>());
                var rightExpression = Expression.Invoke(right.Predicate, parameters.Cast<Expression>());
                var orExpression = Expression.OrElse(leftExpression, rightExpression);
                Predicate = Expression.Lambda<Func<TSub, bool>>(orExpression, parameters);
            }
        }

        /// <summary>
        /// Not specification.
        /// </summary>
        /// <typeparam name="TSub">Specification type.</typeparam>
        private class NotSpecification<TSub> : BaseSpecification<TSub>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BaseSpecification&lt;T&gt;.NotSpecification&lt;TSub&gt;"/> class.
            /// </summary>
            /// <param name="specification">The specification.</param>
            public NotSpecification(ISpecification<TSub> specification)
            {
                var parameters = specification.Predicate.Parameters;
                var expression = Expression.Invoke(specification.Predicate, parameters.Cast<Expression>());
                var notExpression = Expression.Not(expression);
                Predicate = Expression.Lambda<Func<TSub, bool>>(notExpression, parameters);
            }
        }
 
    }
}