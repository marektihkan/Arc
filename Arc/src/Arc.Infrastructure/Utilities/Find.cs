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

namespace Arc.Infrastructure.Utilities
{
    /// <summary>
    /// Find types.
    /// </summary>
    public static class Find
    {
        /// <summary>
        /// Gets type of the specified type name.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static Type Type(string typeName)
        {
            var type = System.Type.GetType(typeName);

            if (type == null)
                throw new ArgumentException("Named type (" + typeName + ") is not found.", "typeName");
            
            return type;
        }

        /// <summary>
        /// Gets type of the specified type name which implements specified interface.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static Type TypeWithInterface<TInterface>(string typeName)
        {
            var type = Type(typeName);

            var typeInterface = typeof(TInterface).FullName;

            if (type.GetInterface(typeInterface) == null)
                throw new ArgumentException("Named type ( " + typeName + ") is not implementing " + typeInterface + " interface.", "typeName");

            return type;
        }
    }
}