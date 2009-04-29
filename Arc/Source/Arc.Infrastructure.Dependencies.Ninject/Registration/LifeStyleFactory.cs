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

using System.Web;
using Arc.Infrastructure.Dependencies.Registration;
using Ninject.Core.Behavior;

namespace Arc.Infrastructure.Dependencies.Ninject.Registration
{
    internal static class LifeStyleFactory
    {
        public static IBehavior Create(ServiceLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case ServiceLifeStyle.Transient:
                    return new TransientBehavior();
                case ServiceLifeStyle.Singleton:
                    return new SingletonBehavior();
                case ServiceLifeStyle.OnePerThread:
                    return new OnePerThreadBehavior();
                case ServiceLifeStyle.OnePerRequest:
                    return new OnePerRequestBehavior();
                case ServiceLifeStyle.OnePerRequestOrThread:
                    return (HttpContext.Current != null) ? (IBehavior) new OnePerRequestBehavior() : new OnePerThreadBehavior();
                default:
                    return new TransientBehavior();
            }           
        }
    }
}