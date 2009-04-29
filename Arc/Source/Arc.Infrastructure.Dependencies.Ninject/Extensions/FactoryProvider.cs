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
using Ninject.Core.Activation;
using Ninject.Core.Creation;

namespace Arc.Infrastructure.Dependencies.Ninject.Extensions
{
    internal class FactoryProvider : IProvider
    {
        public FactoryProvider(Func<object> callback, Type serviceType)
        {
            Callback = callback;
            ServiceType = serviceType;
        }

        private Func<object> Callback { get; set; }

        private Type ServiceType { get; set; }

        public bool IsCompatibleWith(IContext context)
        {
            return true;
        }

        public Type GetImplementationType(IContext context)
        {
            return ServiceType;
        }

        public object Create(IContext context)
        {
            return Callback.Invoke();
        }

        public Type Prototype
        {
            get { return ServiceType; }
        }
    }
}