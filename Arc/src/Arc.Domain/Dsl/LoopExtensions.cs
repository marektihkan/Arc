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
using System.Collections.Generic;

namespace Arc.Domain.Dsl
{
    /// <summary>
    /// Extensions for loops.
    /// </summary>
    public static class LoopExtensions
    {
        /// <summary>
        /// Enumerates all items in list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The action.</param>
        public static void Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source)
                action(element);
        }

        /// <summary>
        /// Repeats action for specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="action">The action.</param>
        public static void Times(this uint count, Action<int> action)
        {
            for (int i = 0; i < count; i++)
                action.Invoke(i);
        }

        /// <summary>
        /// Repeats action for specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="action">The action.</param>
        public static void Times(this int count, Action<int> action)
        {
            if (count > 0)
                ((uint) count).Times(action);
        }
    }
}