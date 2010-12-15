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

namespace Arc.Infrastructure.Mapping
{
    public class MappingOfGenericType<TSource> : MappingOf<TSource>, IMapToSyntax
    {
        public MappingOfGenericType(TSource source, Func<IMapper> resolveMapper) : base(source, resolveMapper) { }


        public TDestination To<TDestination>()
        {
            return Mapper.Map<TSource, TDestination>(Source);
        }

        public TDestination To<TDestination>(TDestination destination)
        {
            return Mapper.Map(Source, destination);
        }

        public object To(Type type)
        {
            return Mapper.Map(Source, typeof(TSource), type);
        }

        public object To(object destination, Type type)
        {
            return Mapper.Map(Source, typeof(TSource), destination, type);
        }
    }
}