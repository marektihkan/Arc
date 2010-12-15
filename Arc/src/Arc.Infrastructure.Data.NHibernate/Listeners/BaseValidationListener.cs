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
using Arc.Domain.Identity;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Validation;

namespace Arc.Infrastructure.Data.NHibernate.Listeners
{
    /// <summary>
    /// Base class for integrating validation to NHibernate.
    /// </summary>
    public class BaseValidationListener
    {
        private readonly IValidationService _validation;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationListener"/> class.
        /// </summary>
        public BaseValidationListener()
            : this(ServiceLocator.Resolve<IValidationService>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationListener"/> class.
        /// </summary>
        /// <param name="validation">The validation service.</param>
        public BaseValidationListener(IValidationService validation)
        {
            _validation = validation;
        }


        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="type">The type.</param>
        public void Validate(object entity, Type type)
        {
            var validatable = entity as IEntity;
            if (validatable == null)
                return;

            var results = _validation.Validate(entity, type);

            if (!results.IsValid)
                throw new ValidationException(results);
        }
    }
}