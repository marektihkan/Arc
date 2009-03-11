#region License

// Copyright (c) 2008-2009 Marek Tihkan (marektihkan@gmail.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Marek Tihkan nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

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