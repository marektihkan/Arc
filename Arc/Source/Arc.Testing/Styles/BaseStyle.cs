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
        /// Gets or sets a thrown exception.
        /// </summary>
        /// <value>The thrown exception.</value>
        public Exception ThrownException { get; set; }

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

            try
            {
                ContextSetUp();
            }
            catch (Exception exception)
            {
                ThrownException = exception;
            }
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