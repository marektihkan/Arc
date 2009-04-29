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

using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Object mapper extensions.
    /// </summary>
    public static class ObjectMapperExtensions
    {
        /// <summary>
        /// Maps source type to destination type.
        /// <remarks>
        /// For using it, you should configure AutoMapper.
        /// </remarks>
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static IList<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> list)
        {
            var result = new List<TDestination>();
            foreach (var source in list)
            {
                result.Add(source.MapTo<TSource, TDestination>());
            }
            return result;
        }

        /// <summary>
        /// Maps source type to destination type.
        /// <remarks>
        /// For using it, you should configure AutoMapper.
        /// </remarks>
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static IList<TDestination> As<TDestination>(this IEnumerable list)
        {
            var result = new List<TDestination>();
            foreach (var source in list)
            {
                result.Add(source.As<TDestination>());
            }
            return result;
        }

        /// <summary>
        /// Maps source type to destination type.
        /// <remarks>
        /// For using it, you should configure AutoMapper.
        /// </remarks>
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Maps source type to destination type.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }

        /// <summary>
        /// Maps source type to destination type.
        /// <remarks>
        /// For using it, you should configure AutoMapper.
        /// </remarks>
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TDestination As<TDestination>(this object source)
        {
            return (TDestination) Mapper.Map(source, source.GetType(), typeof(TDestination));
        }

        /// <summary>
        /// Maps source type to destination type.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static TDestination As<TDestination>(this object source, TDestination destination)
        {
            return (TDestination)Mapper.Map(source, destination, source.GetType(), typeof(TDestination));
        }
    }
}