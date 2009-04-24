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

namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// Registration options for service locator.
    /// </summary>
    public class RegistrationImpl : IRegistration, IServiceBindingSyntax, IServiceLifeStyleSyntax
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationImpl"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        public RegistrationImpl(Type serviceType)
        {
            ServiceType = serviceType;
        }

        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>The type of the service.</value>
        public Type ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the type of the implementation.
        /// </summary>
        /// <value>The type of the implementation.</value>
        public Type ImplementationType { get; set; }

        /// <summary>
        /// Gets or sets the life style scope.
        /// </summary>
        /// <value>The life style scope.</value>
        public ServiceLifeStyle Scope { get; set; }

        /// <summary>
        /// Gets or sets the factory method.
        /// </summary>
        /// <value>The factory method.</value>
        public Func<IServiceLocator, object> Factory { get; set; }

        /// <summary>
        /// Gets the life style builder.
        /// </summary>
        /// <value>The life style builder.</value>
        public IServiceLifeStyleSyntax LifeStyle
        {
            get { return this; }
        }

        /// <summary>
        /// Service is implemented by specified type.
        /// </summary>
        /// <typeparam name="TImplementation">Type of implementation.</typeparam>
        /// <returns></returns>
        public IRegistration IsImplementedBy<TImplementation>()
        {
            return IsImplementedBy(typeof(TImplementation));
        }

        /// <summary>
        /// Service is implemented by specified type.
        /// </summary>
        /// <param name="type">The type of implementation.</param>
        /// <returns></returns>
        public IRegistration IsImplementedBy(Type type)
        {
            ImplementationType = type;
            return this;
        }

        /// <summary>
        /// Service is constructed by specified factory method.
        /// </summary>
        /// <param name="factoryMethod">The factory method.</param>
        /// <returns></returns>
        public IRegistration IsConstructedBy(Func<IServiceLocator, object> factoryMethod)
        {
            Factory = factoryMethod;
            return this;
        }

        /// <summary>
        /// Life style is transient.
        /// </summary>
        /// <returns></returns>
        public IRegistration IsTransient()
        {
            Scope = ServiceLifeStyle.Transient;
            return this;
        }

        /// <summary>
        /// Life style is one per web request.
        /// </summary>
        /// <returns></returns>
        public IRegistration IsOnePerRequest()
        {
            Scope = ServiceLifeStyle.OnePerRequest;
            return this;
        }

        /// <summary>
        /// Life style is one per thread.
        /// </summary>
        /// <returns></returns>
        public IRegistration IsOnePerThread()
        {
            Scope = ServiceLifeStyle.OnePerThread;
            return this;
        }

        /// <summary>
        /// Life style is singleton.
        /// </summary>
        /// <returns></returns>
        public IRegistration IsSingelton()
        {
            Scope = ServiceLifeStyle.Singleton;
            return this;
        }

        /// <summary>
        /// Life style is one per web request (if web context exists) or thread.
        /// </summary>
        /// <returns></returns>
        public IRegistration IsOnePerRequestOrThread()
        {
            Scope = ServiceLifeStyle.OnePerRequestOrThread;
            return this;
        }

        /// <summary>
        /// Life style is spesified style.
        /// </summary>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        public IRegistration Is(ServiceLifeStyle lifeStyle)
        {
            Scope = lifeStyle;
            return this;
        }
    }
}