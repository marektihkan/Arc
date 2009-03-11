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