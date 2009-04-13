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