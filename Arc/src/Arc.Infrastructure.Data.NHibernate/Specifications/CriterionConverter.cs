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
using Arc.Domain.Specifications;
using NHibernate.Criterion;

namespace Arc.Infrastructure.Data.NHibernate.Specifications
{
    /// <summary>
    /// Converts specifications to NHibernate criterion.
    /// </summary>
    public class CriterionConverter
    {
        /// <summary>
        /// Converts the specified specification to criterion.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public static ICriterion Convert<T>(ISpecification<T> specification)
        {
            if (specification == null)
                return null;

            return Convert(specification.Predicate);
        }

        /// <summary>
        /// Converts the specified expression to criterion.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static ICriterion Convert<T>(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return null;

            return ExpressionProcessor.Process(expression.Body);
        }
    }
}