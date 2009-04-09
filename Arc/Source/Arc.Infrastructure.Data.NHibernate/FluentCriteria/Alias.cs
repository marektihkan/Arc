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
using Arc.Infrastructure.Utilities.Expressions;
using Castle.DynamicProxy;
using MemberFinder=Arc.Infrastructure.Data.NHibernate.Specifications.MemberFinder;

namespace Arc.Infrastructure.Data.NHibernate.FluentCriteria
{
    /// <summary>
    /// Alias factory.
    /// </summary>
    public class Alias
    {
        /// <summary>
        /// Creates alias for specified entity type.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <returns>Alias.</returns>
        public static T For<T>()
        {
            var options = new ProxyGenerationOptions();
            options.AddMixinInstance(new AliasImpl());

            var generator = new ProxyGenerator();
            var result = generator.CreateClassProxy(typeof(T), options);

            return (T)result;
        }

        /// <summary>
        /// Creates alias from specified property of entity.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static AliasSyntax From<T>(Expression<Func<T, object>> path)
        {
            var aliasPath = MemberFinder.FindFromExpression(path.Body);

            var result = new AliasSyntax(aliasPath);
            return result;
        }

        internal static IAlias Convert(Expression<Func<object>> alias)
        {
            var aliasContainer = (IAlias)ValueFinder.FindFromExpression(alias.Body);
            aliasContainer.AliasName = MemberFinder.FindFromExpression(alias.Body);
            return aliasContainer;
        }
    }
}