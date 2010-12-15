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
    /// Transaction.
    /// </summary>
    public interface ITransaction : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this transaction is active.
        /// </summary>
        /// <value><c>true</c> if this transaction is active; otherwise, <c>false</c>.</value>
        bool IsActive { get; }

        /// <summary>
        /// Commits this transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks this transaction.
        /// </summary>
        void Rollback();
    }
}