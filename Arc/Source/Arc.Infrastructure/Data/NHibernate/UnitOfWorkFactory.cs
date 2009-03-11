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

using Arc.Infrastructure.Registry;
using NHibernate;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Unit of work factory.
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        /// Key for registering unit of work to registry.
        /// </summary>
        public const string UnitOfWorkKey = "UnitOfWork.Current";
        /// <summary>
        /// Key for registring NHibernate session to registry.
        /// </summary>
        public const string SessionKey = "NHibernate.Session.Current";
        
        private readonly ISessionFactory _factory;
        private readonly IRegistry _registry;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkFactory"/> class.
        /// </summary>
        /// <param name="registry">The registry.</param>
        /// <param name="factory">The NHibernate session factory.</param>
        public UnitOfWorkFactory(IRegistry registry, ISessionFactory factory)
        {
            _registry = registry;
            _factory = factory;
        }


        /// <summary>
        /// Creates new unit of work or returns existing.
        /// </summary>
        /// <returns>New or existing unit of work.</returns>
        public IUnitOfWork Create()
        {
            return CurrentUnitOfWork;
        }

        /// <summary>
        /// Gets the current unit of work.
        /// </summary>
        /// <value>The current unit of work.</value>
        public IUnitOfWork CurrentUnitOfWork
        {
            get { return _registry.Get<IUnitOfWork>(UnitOfWorkKey) ?? CreateAndRegisterNewUnitOfWork(); }
        }

        /// <summary>
        /// Gets a value indicating whether current unit of work is open.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if current unit of work is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsUnitOfWorkOpen
        {
            get { return _registry.Get<IUnitOfWork>(UnitOfWorkKey) != null; }
        }

        /// <summary>
        /// Gets the current session.
        /// </summary>
        /// <value>The current session.</value>
        public ISession CurrentSession
        {
            get
            {
                return _registry.Get<ISession>(SessionKey) ?? CreateAndRegisterNewSession();
            }
        }

        private IUnitOfWork CreateAndRegisterNewUnitOfWork()
        {
            var unitOfWork = new UnitOfWork(CurrentSession, this);
            _registry.Register(UnitOfWorkKey, unitOfWork);
            return unitOfWork;
        }

        private ISession CreateAndRegisterNewSession()
        {
            var session = _factory.OpenSession();
            _registry.Register(SessionKey, session);
            return session;
        }

        /// <summary>
        /// Releases the specified unit of work.
        /// </summary>
        /// <param name="releasable">The releasable unit of work.</param>
        public void Release(IUnitOfWork releasable)
        {
            _registry.Unregister(UnitOfWorkKey);
            
            var session = _registry.Unregister<ISession>(SessionKey);
            if (session != null)
                session.Dispose();
        }
    }
}