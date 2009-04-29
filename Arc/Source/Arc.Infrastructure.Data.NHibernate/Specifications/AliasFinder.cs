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

using System.Linq.Expressions;
using System.Reflection;
using Arc.Infrastructure.Data.NHibernate.FluentCriteria;

namespace Arc.Infrastructure.Data.NHibernate.Specifications
{
    internal class AliasFinder
    {
        public static bool IsAliasExpression(Expression expression)
        {
            var memberExpression = expression as MemberExpression;
            if (memberExpression == null) return false;

            var alias = CreateProcessor(memberExpression).Process();
            
            return (alias is IAlias) 
                ? true 
                : IsAliasExpression(memberExpression.Expression);    
        }

        private static IAliasProcessor CreateProcessor(MemberExpression expression)
        {
            if (expression.Member is FieldInfo) return new FieldAliasProcessor(expression);
            return new NullAliasProcessor();
        }
    }
}