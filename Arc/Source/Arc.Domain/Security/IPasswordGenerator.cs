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

namespace Arc.Domain.Security
{
    /// <summary>
    /// Service for password generation and computing hashes.
    /// </summary>
    public interface IPasswordGenerator
    {
        /// <summary>
        /// Creates the password.
        /// </summary>
        /// <param name="length">The password length.</param>
        /// <returns>Generated password.</returns>
        string Create(int length);

        /// <summary>
        /// Computes the password hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>Password hash.</returns>
        string ComputeHash(string password);
    }
}