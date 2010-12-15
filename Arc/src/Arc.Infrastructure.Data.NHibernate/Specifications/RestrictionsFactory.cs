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
    internal static class RestrictionsFactory
    {
        public static IDictionary<ExpressionType, Func<string,object,ICriterion>> BasicBinaryOperations { get; set; }
        public static IDictionary<string, Func<string,object,ICriterion>> FunctionOperations { get; set; }
        public static IDictionary<ExpressionType, Func<ICriterion,ICriterion,ICriterion>> BinaryOperations { get; set; }
        public static IDictionary<ExpressionType, Func<ICriterion,ICriterion>> UnaryOperations { get; set; }

        static RestrictionsFactory()
        {
            BuildBasicBinaryOperations();
            BuildFunctionOperations();
            BuildBinaryOperations();
            BuildUnaryOperations();
        }

        public static void BuildBasicBinaryOperations()
        {
            var result = new Dictionary<ExpressionType, Func<string, object, ICriterion>>
                         {
                             {
                                 ExpressionType.Equal,
                                 (property, value) => (value == null)
                                     ? Restrictions.IsNull(property)
                                     : Restrictions.Eq(property, value)
                             },
                             {
                                 ExpressionType.NotEqual,
                                 (property, value) => (value == null)
                                     ? Restrictions.IsNotNull(property)
                                     : Restrictions.Not(Restrictions.Eq(property, value))
                             },
                             {ExpressionType.GreaterThan, Restrictions.Gt},
                             {ExpressionType.GreaterThanOrEqual, Restrictions.Ge},
                             {ExpressionType.LessThan, Restrictions.Lt},
                             {ExpressionType.LessThanOrEqual, Restrictions.Le}
                         };

            BasicBinaryOperations = result;
        }

        public static void BuildFunctionOperations()
        {
            var result = new Dictionary<string, Func<string, object, ICriterion>>
                         {
                             {"Contains", (property, value) => Restrictions.Like(property, "%" + value + "%") },
                             {"StartsWith", (property, value) => Restrictions.Like(property, value + "%") },
                             {"EndsWith", (property, value) => Restrictions.Like(property, "%" + value) }
                         };
            FunctionOperations = result;
        }

        public static void BuildBinaryOperations()
        {
            var result = new Dictionary<ExpressionType, Func<ICriterion, ICriterion, ICriterion>>
                         {
                             {ExpressionType.AndAlso, Restrictions.And },
                             {ExpressionType.OrElse, Restrictions.Or }
                         };
            BinaryOperations = result;
        }

        public static void BuildUnaryOperations()
        {
            var result = new Dictionary<ExpressionType, Func<ICriterion, ICriterion>>
                         {
                             {ExpressionType.Not, Restrictions.Not }
                         };
            UnaryOperations = result;
        }

        
        public static ICriterion Create(ExpressionType operand, string propertyName, object value)
        {
            return BasicBinaryOperations.ContainsKey(operand) 
                ? BasicBinaryOperations[operand].Invoke(propertyName, value) 
                : null;
        }

        public static ICriterion Create(ExpressionType operand, ICriterion left, ICriterion right)
        {
            return (BinaryOperations.ContainsKey(operand))
                ? BinaryOperations[operand].Invoke(left, right)
                : null;
        }

        public static ICriterion Create(ExpressionType operand, ICriterion criterion)
        {
            return (UnaryOperations.ContainsKey(operand))
                 ? UnaryOperations[operand].Invoke(criterion)
                 : null;
        }

        public static ICriterion Create(string methodName, string propertyName, string value)
        {
            return (FunctionOperations.ContainsKey(methodName)) 
                ? FunctionOperations[methodName].Invoke(propertyName, value)
                : null;
        }
    }
}