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

namespace Arc.Domain.Time
{
    /// <summary>
    /// System clock.
    /// </summary>
    public class Clock : IClock
    {
        /// <summary>
        /// Gets the current date and time.
        /// </summary>
        /// <value>The current date and time.</value>
        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// Gets the today's date.
        /// </summary>
        /// <value>The today's date.</value>
        public DateTime Today
        {
            get { return DateTime.Today; }
        }
    }
}