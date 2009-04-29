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

using Castle.DynamicProxy;

namespace Arc.Infrastructure.Data.NHibernate.FluentCriteria
{
    /// <summary>
    /// Syntax for creating alias with path.
    /// </summary>
    public class AliasSyntax
    {
        private readonly string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="AliasSyntax"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public AliasSyntax(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Creates alias for specified entity type.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <returns>Alias.</returns>
        public T For<T>()
        {
            var options = new ProxyGenerationOptions();
            options.AddMixinInstance(new AliasImpl());

            var generator = new ProxyGenerator();
            var result = generator.CreateClassProxy(typeof(T), options);

            var alias = (IAlias)result;
            alias.AliasPath = _path;

            return (T)result;
        }
    }
}