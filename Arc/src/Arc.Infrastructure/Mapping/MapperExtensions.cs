using System.Collections.Generic;

namespace Arc.Infrastructure.Mapping
{
	public static class MapperExtensions
	{
		public static IEnumerable<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> list)
		{
			return Map.CollectionOf(list).To<TDestination>();
		}
		
		public static TDestination MapTo<TSource, TDestination>(this TSource source)
		{
			return Map.From(source).To<TDestination>();
		}

		public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
		{
			return Map.From(source).To(destination);
		}

		public static TDestination As<TDestination>(this object source)
		{
			return Map.From(source, source.GetType()).To<TDestination>();
		}

		public static TDestination As<TDestination>(this object source, TDestination destination)
		{
			return Map.From(source, source.GetType()).To(destination);
		}
	}
}