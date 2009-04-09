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
using MemberFinder=Arc.Infrastructure.Data.NHibernate.Specifications.MemberFinder;

namespace Arc.Infrastructure.Data.NHibernate.FluentCriteria
{
    /// <summary>
    /// Criteria ordering.
    /// </summary>
    public class Ordering
    {
        /// <summary>
        /// Creates ascending ordering with specified property.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        public static Order Ascending<T>(Expression<Func<T, object>> property)
        {
            return Convert(property, true);
        }

        /// <summary>
        /// Creates descending ordering with specified property.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        public static Order Descending<T>(Expression<Func<T, object>> property)
        {
            return Convert(property, false);
        }

        private static Order Convert<T>(Expression<Func<T, object>> expression, bool isAscending)
        {
            var member = MemberFinder.FindFromExpression(expression.Body);
            return string.IsNullOrEmpty(member) ? null : new Order(member, isAscending);
        }
    }
}