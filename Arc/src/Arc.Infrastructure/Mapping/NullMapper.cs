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
    public class NullMapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return destination;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return default(TDestination);
        }

        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources)
        {
            return new List<TDestination>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Activator.CreateInstance(destinationType);
        }

        public object Map(object source, Type sourceType, object destination, Type destinationType)
        {
            return destination;
        }

        public IEnumerable Map(IEnumerable sources, Type sourceType, Type destinationType)
        {
            return new ArrayList();
        }
    }
}