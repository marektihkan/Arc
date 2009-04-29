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

namespace Arc.Domain.Dsl
{
    /// <summary>
    /// Extensions for checking nullability.
    /// </summary>
    public static class NullExtensions
    {
        /// <summary>
        /// Determines whether the specified @object is null.
        /// </summary>
        /// <param name="object">The @object.</param>
        /// <returns>
        /// 	<c>true</c> if the specified @object is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(this object @object)
        {
            return @object == null;
        }

        /// <summary>
        /// Determines whether the specified @object is null.
        /// </summary>
        /// <param name="object">The @object.</param>
        /// <returns>
        /// 	<c>true</c> if the specified @object is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(this string @object)
        {
            return string.IsNullOrEmpty(@object);
        }

        /// <summary>
        /// Determines whether the specified @object is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object">The @object.</param>
        /// <returns>
        /// 	<c>true</c> if the specified @object is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull<T>(this T? @object) where T : struct 
        {
            return !@object.HasValue;
        }
    }
}