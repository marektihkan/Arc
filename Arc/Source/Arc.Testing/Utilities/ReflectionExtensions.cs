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