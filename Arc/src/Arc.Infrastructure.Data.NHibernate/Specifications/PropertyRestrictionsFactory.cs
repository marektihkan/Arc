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
using System.Collections.Generic;
using System.Linq.Expressions;
using NHibernate.Criterion;

namespace Arc.Infrastructure.Data.NHibernate.Specifications
{
    internal static class PropertyRestrictionsFactory
    {
        public static Dictionary<ExpressionType, Func<string, string, ICriterion>> BasicBinaryOperations { get; set; }
        
        static PropertyRestrictionsFactory()
        {
            BuildBasicBinaryOperations();
        }

        public static void BuildBasicBinaryOperations()
        {
            var result = new Dictionary<ExpressionType, Func<string, string, ICriterion>>
                         {
                             {ExpressionType.Equal, Restrictions.EqProperty},
                             {
                                 ExpressionType.NotEqual,
                                 (property1, property2) => Restrictions.Not(Restrictions.EqProperty(property1, property2))
                             },
                             {ExpressionType.GreaterThan, Restrictions.GtProperty},
                             {ExpressionType.GreaterThanOrEqual, Restrictions.GeProperty},
                             {ExpressionType.LessThan, Restrictions.LtProperty},
                             {ExpressionType.LessThanOrEqual, Restrictions.LeProperty}
                         };

            BasicBinaryOperations = result;
        }

        public static ICriterion Create(ExpressionType operand, string property1, string property2)
        {
            return BasicBinaryOperations.ContainsKey(operand)
                ? BasicBinaryOperations[operand].Invoke(property1, property2)
                : null;
        }

    }
}