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
    public class MappingOfUnknownType : MappingOf<object>, IMapToSyntax
    {
        private readonly Type _type;
        

        public MappingOfUnknownType(object source, Type type, Func<IMapper> resolveMapper) : base(source, resolveMapper)
        {
            _type = type;
        }


        public TDestination To<TDestination>()
        {
            return (TDestination) Mapper.Map(Source, _type, typeof(TDestination));
        }

        public TDestination To<TDestination>(TDestination destination)
        {
            return (TDestination) Mapper.Map(Source, _type, typeof(TDestination));
        }

        public object To(Type type)
        {
            return Mapper.Map(Source, _type, type);
        }

        public object To(object destination, Type type)
        {
            return Mapper.Map(Source, _type, destination, type);
        }
    }
}