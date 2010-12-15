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
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Presentation.Mvp
{
    /// <summary>
    /// Base class for master pages.
    /// For registering event handlers its best to use <c>HookupEventhandlers</c> method.
    /// </summary>
    /// <remarks>
    /// For using it, presenter should have constructor parameter named "view" and MasterPage must be implementing that interface. 
    /// </remarks>
    /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
    public abstract class MasterPage<TPresenter> : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>The presenter.</value>
        protected TPresenter Presenter { get; set; }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Presenter = ServiceLocator.Resolve<TPresenter>(With.Parameters.ConstructorArgument("view", this));
            HookupEventHandlers();
        }

        /// <summary>
        /// Hookups the event handlers.
        /// </summary>
        protected abstract void HookupEventHandlers();
    }
}