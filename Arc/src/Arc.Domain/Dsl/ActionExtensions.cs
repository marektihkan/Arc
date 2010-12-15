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

namespace Arc.Domain.Dsl
{
    /// <summary>
    /// Extensions for actions.
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Executes specified action when condition is true.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="condition">if set to <c>true</c> action is executed.</param>
        public static void When(this Action action, bool condition)
        {
            if (condition)
                action.Invoke();
        }

        /// <summary>
        /// Executes specified action when condition is false.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="condition">if set to <c>false</c> action is executed.</param>
        public static void Unless(this Action action, bool condition)
        {
            if (!condition)
                action.Invoke();
        }

        /// <summary>
        /// On specified Exception it executes recovery action.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="recovery">The recovery action.</param>
        public static void On<TException>(this Action action, Action<TException> recovery) where TException : Exception
        {
            try
            {
                action.Invoke();
            }
            catch (TException exception)
            {
                recovery.Invoke(exception);
            }
        }
    }
}