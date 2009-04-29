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
using Arc.Infrastructure.Utilities.Expressions;

namespace Arc.Infrastructure.Data.NHibernate.Specifications
{
    internal class FieldAliasProcessor : IAliasProcessor
    {
        private readonly MemberExpression _expression;

        public FieldAliasProcessor(MemberExpression expression)
        {
            _expression = expression;
        }

        public object Process()
        {
            var info = _expression.Member as FieldInfo;
            
            if (info == null) return null;
            
            var target = ValueFinder.FindFromExpression(_expression.Expression);
            return info.GetValue(target);
        }
    }
}