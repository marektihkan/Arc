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

namespace Arc.Infrastructure.Dependencies.Registration.Auto
{
    /// <summary>
    /// Registers to first criteria match (interface).
    /// </summary>
    public class RegisterTypeToFirstMatchStrategy : BaseRegisterTypeStrategy, ITypeRegistrationStrategy
    {
        private readonly Func<Type, Type, bool> _binding;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterTypeToFirstMatchStrategy"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        public RegisterTypeToFirstMatchStrategy(Func<Type, Type, bool> binding)
        {
            _binding = binding;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterTypeToFirstMatchStrategy"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        public RegisterTypeToFirstMatchStrategy(Func<Type, bool> binding) 
            : this((foundInterface, type) => binding.Invoke(foundInterface))
        {
        }

        /// <summary>
        /// Registers the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="locator">The locator.</param>
        public void Register(Type type, IServiceLocator locator)
        {
            var interfaces = type.FindInterfaces((t, obj) => _binding.Invoke(t, type), null);
            if (interfaces.Length > 0)
                Register(interfaces[0], type, locator);
        }
    }
}