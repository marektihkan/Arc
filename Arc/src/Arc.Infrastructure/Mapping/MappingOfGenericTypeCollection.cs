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
using System.Collections;
using System.Collections.Generic;

namespace Arc.Infrastructure.Mapping
{
    public class MappingOfGenericTypeCollection<TSource> : MappingOf<IEnumerable<TSource>>, IMapCollectionToSyntax
    {
        public MappingOfGenericTypeCollection(IEnumerable<TSource> source, Func<IMapper> resolveMapper) : base(source, resolveMapper)
        {
        }

        public IEnumerable<TDestination> To<TDestination>()
        {
            return Mapper.Map<TSource, TDestination>(Source);
        }

        public IEnumerable To(Type type)
        {
            return Mapper.Map(Source, typeof(TSource), type);
        }
    }
}