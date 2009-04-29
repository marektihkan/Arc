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

using Arc.Testing.Utilities;
using NUnit.Framework;

namespace Arc.Testing.Styles
{
    /// <summary>
    /// Base class for Behavior Driven Development testing.
    /// </summary>
    /// <typeparam name="TSystemUnderTest">The type of the system under test.</typeparam>
    public abstract class BaseStyle<TSystemUnderTest>
    {
        /// <summary>
        /// Gets or sets the System Under Test.
        /// </summary>
        /// <value>The System Under Test.</value>
        public TSystemUnderTest SUT { get; set; }

        /// <summary>
        /// Gets or sets the auto mocker.
        /// </summary>
        /// <value>The mockery.</value>
        public IAutoMocker Mockery { get; set; }

        /// <summary>
        /// Main setup.
        /// </summary>
        [SetUp]
        public void MainSetup()
        {
            Mockery = new AutoMocker();

            ContextSetUp();
        }

        /// <summary>
        /// Main cleanup.
        /// </summary>
        [TearDown]
        public void MainTearDown()
        {
            CleanUp();
        }

        /// <summary>
        /// Cleans up after execution.
        /// </summary>
        public virtual void CleanUp()
        {
        }

        /// <summary>
        /// Sets up context.
        /// </summary>
        protected abstract void ContextSetUp();
    }
}