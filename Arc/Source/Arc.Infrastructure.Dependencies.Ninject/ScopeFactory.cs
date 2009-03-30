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

using Ninject.Core.Behavior;

namespace Arc.Infrastructure.Dependencies.Ninject
{
    /// <summary>
    /// Scope factory for Ninject.
    /// </summary>
    public class ScopeFactory : IScopeFactory
    {
        /// <summary>
        /// Gets the transient scope.
        /// </summary>
        /// <value>The transient scope.</value>
        public IScope Transient
        {
            get { return new Scope(new TransientBehavior()); }
        }

        /// <summary>
        /// Gets the one per request scope.
        /// </summary>
        /// <value>The one per request scope.</value>
        public IScope OnePerRequest
        {
            get { return new Scope(new OnePerRequestBehavior()); }
        }

        /// <summary>
        /// Gets the one per thread scope.
        /// </summary>
        /// <value>The one per thread scope.</value>
        public IScope OnePerThread
        {
            get { return new Scope(new OnePerThreadBehavior()); }
        }

        /// <summary>
        /// Gets the singleton scope.
        /// </summary>
        /// <value>The singleton scope.</value>
        public IScope Singleton
        {
            get { return new Scope(new SingletonBehavior()); }
        }
    }
}