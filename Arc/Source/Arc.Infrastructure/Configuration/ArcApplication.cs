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

using System.Web;
using Arc.Infrastructure.Data;
using Ninject.Core.Behavior;

namespace Arc.Infrastructure.Configuration
{
    /// <summary>
    /// Web application configuration.
    /// </summary>
    public class ArcApplication : HttpApplication
    {
        private static readonly OnePerRequestModule _onePerRequestModule = new OnePerRequestModule();
        private static readonly UnitOfWorkWebModule _unitOfWorkWebModule = new UnitOfWorkWebModule();


        /// <summary>
        /// Executes custom initialization code after all event handler modules have been added.
        /// Registers Ninject's <see cref="OnePerRequestBehavior"/> module.
        /// </summary>
        public override void Init()
        {
            base.Init();

            RegisterUnitOfWorkWebModule();
            RegisterNinjectWebBehaviorModule();
            ConfigureApplication();
        }

        /// <summary>
        /// Registers the unit of work web module.
        /// </summary>
        private void RegisterUnitOfWorkWebModule()
        {
            _unitOfWorkWebModule.Init(this);
        }

        /// <summary>
        /// Registers the Ninject web behavior module.
        /// </summary>
        private void RegisterNinjectWebBehaviorModule()
        {
            //NOTE: This is temporary fix for Ninject OnePerRequestBehavior.
            // It should be fixed in official version 1.5  
            _onePerRequestModule.Init(this);
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        protected virtual void ConfigureApplication()
        {
            Bootstrapper.Configure();
        }
    }
}