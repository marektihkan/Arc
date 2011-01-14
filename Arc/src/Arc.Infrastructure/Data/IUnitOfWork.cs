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

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the provider's session.
        /// </summary>
        /// <value>The provider's session.</value>
        object Session { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is in transaction.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is in transaction; otherwise, <c>false</c>.
        /// </value>
        bool IsInTransaction { get; }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns>Transaction.</returns>
        ITransaction BeginTransaction();

        /// <summary>
        /// Flushes changes to database.
        /// </summary>
        void Flush();

        /// <summary>
        /// Flushes changes in transaction.
        /// </summary>
        void TransactionalFlush();
    }
}