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

namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// Configuration syntax for setting service life style.
    /// </summary>
    public interface IServiceLifeStyleSyntax
    {
        /// <summary>
        /// Life style is transient.
        /// </summary>
        /// <returns></returns>
        IRegistration IsTransient();

        /// <summary>
        /// Life style is one per web request.
        /// </summary>
        /// <returns></returns>
        IRegistration IsOnePerRequest();

        /// <summary>
        /// Life style is one per thread.
        /// </summary>
        /// <returns></returns>
        IRegistration IsOnePerThread();

        /// <summary>
        /// Life style is singleton.
        /// </summary>
        /// <returns></returns>
        IRegistration IsSingelton();

        /// <summary>
        /// Life style is one per web request (if web context exists) or thread.
        /// </summary>
        /// <returns></returns>
        IRegistration IsOnePerRequestOrThread();

        /// <summary>
        /// Life style is spesified style.
        /// </summary>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        IRegistration Is(ServiceLifeStyle lifeStyle);
    }
}