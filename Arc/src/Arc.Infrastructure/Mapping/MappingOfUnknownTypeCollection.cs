﻿#region License
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
using System.Collections;
using System.Collections.Generic;

namespace Arc.Infrastructure.Mapping
{
    public class MappingOfUnknownTypeCollection : MappingOf<object>, IMapCollectionToSyntax
    {
        private readonly Type _sourceType;

        public MappingOfUnknownTypeCollection(object source, Type sourceType, Func<IMapper> resolveMapper) : base(source, resolveMapper)
        {
            _sourceType = sourceType;
        }

        public IEnumerable<TDestination> To<TDestination>()
        {
            return (IEnumerable<TDestination>) Mapper.Map(Source, _sourceType, typeof(TDestination));
        }

        public IEnumerable To(Type type)
        {
            return (IEnumerable) Mapper.Map(Source, _sourceType, type);
        }
    }
}