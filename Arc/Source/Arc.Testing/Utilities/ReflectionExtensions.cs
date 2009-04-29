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
using System.Reflection;

namespace Arc.Testing.Utilities
{
    /// <summary>
    /// Extensions for testing using reflection.
    /// </summary>
    public static class ReflectionExtensions
    {
        private const BindingFlags DefaultBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;


        /// <summary>
        /// Sets the value to field or property.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="name">The field or property name.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">Name is empty.</exception>
        /// <exception cref="ArgumentException">No property or field found.</exception>
        public static void SetValueTo(this object obj, string name, object value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name", "Name should not be null.");

            var type = obj.GetType();

            var propertyInfo = type.GetProperty(name, DefaultBindingFlags);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(obj, value, null);
                return;
            }

            var fieldInfo = type.GetField(name, DefaultBindingFlags);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(obj, value);
                return;
            }

            throw new ArgumentException("No property or field found.", "name");
        }

        /// <summary>
        /// Gets the value of field or property.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="obj">The target object.</param>
        /// <param name="name">The field or property name.</param>
        /// <returns>Property or field value.</returns>
        /// <exception cref="ArgumentNullException">Name is empty.</exception>
        /// <exception cref="ArgumentException">No property or field found.</exception>
        public static T GetValueOf<T>(this object obj, string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name", "Name should not be null.");

            var type = obj.GetType();

            var propertyInfo = type.GetProperty(name, DefaultBindingFlags);
            if (propertyInfo != null)
            {
                return (T) propertyInfo.GetValue(obj, null);
            }

            var fieldInfo = type.GetField(name, DefaultBindingFlags);
            if (fieldInfo != null)
            {
                return (T) fieldInfo.GetValue(obj);
            }

            throw new ArgumentException("No property or field found.", "name");
        }

    }
}