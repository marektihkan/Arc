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
using NHibernate;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// NHibernate unit of work adapter.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUnitOfWorkFactory _factory;
        

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="session">The NHibernate session.</param>
        /// <param name="factory">The factory.</param>
        public UnitOfWork(ISession session, IUnitOfWorkFactory factory)
        {
            _factory = factory;
            RealSession = session;
        }

        /// <summary>
        /// Gets or sets the real session.
        /// </summary>
        /// <value>The real session.</value>
        public ISession RealSession { get; set; }

        /// <summary>
        /// Gets the NHibernate session.
        /// </summary>
        /// <value>The NHibernate session.</value>
        public object Session
        {
            get { return RealSession; }
        }


        /// <summary>
        /// Gets a value indicating whether this instance is in transaction.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is in transaction; otherwise, <c>false</c>.
        /// </value>
        public bool IsInTransaction
        {
            get { return RealSession.Transaction.IsActive; }
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns>Transaction.</returns>
        public ITransaction BeginTransaction()
        {
            return new Transaction(RealSession.BeginTransaction());
        }

        /// <summary>
        /// Flushes changes in transaction.
        /// </summary>
        public void TransactionalFlush()
        {
            var transaction = BeginTransaction();
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposeAll"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposeAll)
        {
            _factory.Release(this);
        }
    }
}