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

using System.Web;
using Arc.Infrastructure.Dependencies.Registration;
using Castle.Core;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Registration
{
    internal static class LifeStyleFactory
    {
        public static LifestyleType Create(ServiceLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case ServiceLifeStyle.Transient:
                    return LifestyleType.Transient;
                case ServiceLifeStyle.Singleton:
                    return LifestyleType.Singleton;
                case ServiceLifeStyle.OnePerThread:
                    return LifestyleType.Thread;
                case ServiceLifeStyle.OnePerRequest:
                    return LifestyleType.PerWebRequest;
                case ServiceLifeStyle.OnePerRequestOrThread:
                    return (HttpContext.Current != null) ? LifestyleType.PerWebRequest : LifestyleType.Thread;
                default:
                    return LifestyleType.Transient;
            }           
        }
    }
}