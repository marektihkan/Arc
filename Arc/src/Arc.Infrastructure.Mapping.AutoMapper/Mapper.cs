using System;
using System.Collections;
using System.Collections.Generic;
using Arc.Domain.Dsl;

namespace Arc.Infrastructure.Mapping.AutoMapper
{
    public class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return global::AutoMapper.Mapper.Map(source, destination);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return global::AutoMapper.Mapper.Map<TSource, TDestination>(source);
        }

        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources)
        {
            var result = new List<TDestination>();
            sources.Each(source => 
            {
                var destination = global::AutoMapper.Mapper.Map<TSource, TDestination>(source);
                result.Add(destination);
            });
            return result;
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return global::AutoMapper.Mapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, Type sourceType, object destination, Type destinationType)
        {
            return global::AutoMapper.Mapper.Map(source, destination, sourceType, destinationType);
        }

        public IEnumerable Map(IEnumerable sources, Type sourceType, Type destinationType)
        {
            var result = new ArrayList();
            foreach (var source in sources)
            {
                var destination = global::AutoMapper.Mapper.Map(source, sourceType, destinationType);
                result.Add(destination);
            }
            return result;
        }
    }
}