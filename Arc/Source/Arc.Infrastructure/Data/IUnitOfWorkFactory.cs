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

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Factory for unit of work.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates new unit of work.
        /// </summary>
        /// <returns>Unit of work.</returns>
        IUnitOfWork Create();

        /// <summary>
        /// Releases the specified unit of work.
        /// </summary>
        /// <param name="releasable">The releasable unit of work.</param>
        void Release(IUnitOfWork releasable);

        /// <summary>
        /// Gets a value indicating whether current unit of work is open.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if current unit of work is open; otherwise, <c>false</c>.
        /// </value>
        bool IsUnitOfWorkOpen { get; }
    }
}