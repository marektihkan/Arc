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

using Arc.Infrastructure.Dependencies.Registration;
using StructureMap.Attributes;

namespace Arc.Infrastructure.Dependencies.StructureMap.Registration
{
    internal static class LifeStyleFactory
    {
        internal static InstanceScope Create(ServiceLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case ServiceLifeStyle.Transient:
                    return InstanceScope.PerRequest;
                case ServiceLifeStyle.Singleton:
                    return InstanceScope.Singleton;
                case ServiceLifeStyle.OnePerThread:
                    return InstanceScope.ThreadLocal;
                case ServiceLifeStyle.OnePerRequest:
                    return InstanceScope.HttpContext;
                case ServiceLifeStyle.OnePerRequestOrThread:
                    return InstanceScope.Hybrid;
                default:
                    return InstanceScope.PerRequest;
            }
        }
    }
}