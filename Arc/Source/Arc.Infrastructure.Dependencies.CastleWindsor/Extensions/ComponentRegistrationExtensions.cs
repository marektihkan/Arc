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
        public static ComponentRegistration<TService> FactoryMethod<TService, TResult>(this ComponentRegistration<TService> registration, Func<TResult> factory) where TResult : TService
        {
            var factoryName = typeof(GenericFactory<>).FullName + "[" + registration.ServiceType.FullName + "]";
            
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
        public static ComponentRegistration<TService> FactoryMethod<TService, TResult>(this ComponentRegistration<TService> registration, Func<IKernel, TResult> factory) where TResult : TService
        {
            var factoryName = typeof(GenericFactoryWithKernel<>).FullName + "[" + registration.ServiceType.FullName + "]";

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