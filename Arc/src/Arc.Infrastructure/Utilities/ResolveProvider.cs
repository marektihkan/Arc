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
    /// Provider resolver.
    /// </summary>
    /// <typeparam name="T">Type of provider interface.</typeparam>
    public static class ResolveProvider<T>
    {
        /// <summary>
        /// Creates provider of specified type name.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        /// <returns></returns>
        public static T Named(string providerFullName)
        {
            return WithRealType(Find.TypeWithInterface<T>(providerFullName));
        }

        /// <summary>
        /// Creates provider of specified type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <returns></returns>
        public static T WithRealType(Type provider)
        {
            if (provider.FindInterfaces((type, x) => type == x, typeof(T)).Length == 0)
                throw new ArgumentException("Specified type is not implementing specified interface.", "provider");

            return (T)Activator.CreateInstance(provider);
        }
    }
}