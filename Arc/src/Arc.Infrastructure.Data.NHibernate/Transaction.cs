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

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// NHibernate transaction adapter.
    /// </summary>
    public class Transaction : ITransaction
    {
        private readonly global::NHibernate.ITransaction _transaction;


        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="transaction">The NHibernate transaction.</param>
        public Transaction(global::NHibernate.ITransaction transaction)
        {
            _transaction = transaction;
        }


        /// <summary>
        /// Gets a value indicating whether this transaction is active.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this transaction is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return _transaction.IsActive; }
        }

        /// <summary>
        /// Commits this transaction.
        /// </summary>
        public void Commit()
        {
            _transaction.Commit();
        }

        /// <summary>
        /// Rollbacks this transaction.
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
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
            _transaction.Dispose();
        }
    }
}