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

using System.Web;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Web module for releasing unit of work at the end of request.
    /// </summary>
    public class UnitOfWorkWebModule : IHttpModule
    {
        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
        public void Init(HttpApplication context)
        {
            context.EndRequest += (x, y) => ReleaseUnitOfWork();
        }

        private static void ReleaseUnitOfWork()
        {
            var factory = ServiceLocator.Resolve<IUnitOfWorkFactory>();
            if (!factory.IsUnitOfWorkOpen)
                return;

            var unitOfWork = ServiceLocator.Resolve<IUnitOfWork>();
            unitOfWork.TransactionalFlush();
            factory.Release(unitOfWork);
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
        }
    }
}