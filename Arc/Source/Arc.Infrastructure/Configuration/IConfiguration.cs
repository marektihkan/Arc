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

namespace Arc.Infrastructure.Configuration
{
    /// <summary>
    /// Configuration module for specified handler.
    /// </summary>
    /// <typeparam name="TConfigurationHandler">The type of the configuration handler.</typeparam>
    public interface IConfiguration<TConfigurationHandler>
    {
        /// <summary>
        /// Loads the specified configuration to handler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        void Load(TConfigurationHandler handler);
    }
}