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

using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Registry;
using Arc.Infrastructure.Validation.NHibernate;
using NHibernate;
using NHibernate.Event;
using Ninject.Core;
using Ninject.Core.Behavior;

namespace Arc.Infrastructure.Configuration.Dependencies
{
    /// <summary>
    /// Configures data access infrastructure.
    /// </summary>
    public class DataConfiguration : StandardModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind(typeof(IRegistry))
                .To(typeof(WebRequestRegistry));

            Bind<NHibernate.Cfg.Configuration>()
                .ToMethod(x =>
                      {
                          var configuration = new NHibernate.Cfg.Configuration();
                          configuration.SetListener(ListenerType.PreInsert, new PreInsertEventListener());
                          configuration.SetListener(ListenerType.PreUpdate, new PreUpdateEventListener());
                          return configuration.Configure();
                      })
                .Using<SingletonBehavior>();


            Bind<ISessionFactory>()
                .ToMethod(x => Kernel.Get<NHibernate.Cfg.Configuration>().BuildSessionFactory())
                .Using<SingletonBehavior>();

            Bind<IUnitOfWorkFactory>()
                .To<UnitOfWorkFactory>()
                .Using<SingletonBehavior>();

            Bind<IUnitOfWork>()
                .ToMethod(x => Kernel.Get<IUnitOfWorkFactory>().Create());
            
            Bind(typeof(IRepository<>))
                .To(typeof(Repository<>));
        }
    }
}