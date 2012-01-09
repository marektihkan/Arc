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
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Extensions
{
    /// <summary>
    /// Extensions for Castle Windsor factory method.
    /// </summary>
    public static class ComponentRegistrationExtensions
    {
        /// <summary>
        /// Gets or sets the kernel.
        /// </summary>
        /// <value>The kernel.</value>
        public static IKernel Kernel { private get; set; }

        /// <summary>
        /// Registers to factory method.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="registration">The regegistration.</param>
        /// <param name="factory">The factory method.</param>
        /// <returns></returns>
        public static ComponentRegistration<TService> FactoryMethod<TService, TResult>(this ComponentRegistration<TService> registration, Func<TResult> factory) 
			where TResult : TService 
			where TService : class
        {
			var factoryName = typeof(GenericFactory<>).FullName + "[" + registration.Implementation.FullName + "]";
            
            Kernel.Register(
                Component.For<GenericFactory<TResult>>()
                    .Named(factoryName)
                    .Instance(new GenericFactory<TResult>(factory)));
            
            registration.Configuration(
                Attrib.ForName("factoryId").Eq(factoryName), 
                Attrib.ForName("factoryCreate").Eq("Create"));

            return registration;
        }

        /// <summary>
        /// Registers to factory method.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="registration">The registration.</param>
        /// <param name="factory">The factory.</param>
        /// <returns></returns>
        public static ComponentRegistration<TService> FactoryMethod<TService, TResult>(this ComponentRegistration<TService> registration, Func<IKernel, TResult> factory) 
			where TResult : TService 
			where TService : class
        {
			var factoryName = typeof(GenericFactoryWithKernel<>).FullName + "[" + registration.Implementation.FullName + "]";

            Kernel.Register(
                Component.For<GenericFactoryWithKernel<TResult>>()
                    .Named(factoryName)
                    .Instance(new GenericFactoryWithKernel<TResult>(factory, Kernel)));
            
            registration.Configuration(
                Attrib.ForName("factoryId").Eq(factoryName), 
                Attrib.ForName("factoryCreate").Eq("Create"));

            return registration;
        }

        private class GenericFactoryWithKernel<TService>
        {
            private readonly Func<IKernel, TService> factoryMethod;
            private readonly IKernel kernel;

            public GenericFactoryWithKernel(Func<IKernel, TService> factoryMethod, IKernel kernel)
            {
                this.factoryMethod = factoryMethod;
                this.kernel = kernel;
            }

            public TService Create()
            {
                return factoryMethod(kernel);
            }
        }

        private class GenericFactory<TService>
        {
            private readonly Func<TService> factoryMethod;

            public GenericFactory(Func<TService> factoryMethod)
            {
                this.factoryMethod = factoryMethod;
            }

            public TService Create()
            {
                return factoryMethod();
            }
        }
    }
}