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