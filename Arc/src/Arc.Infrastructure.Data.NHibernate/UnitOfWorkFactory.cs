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
            get { return _registry.Get<ISession>(SessionKey) ?? CreateAndRegisterNewSession(); }
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