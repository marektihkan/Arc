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

using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;

namespace Arc.Infrastructure.Validation.NHibernateValidator
{
    /// <summary>
    /// Configuration for validation with NHibernate Validator.
    /// </summary>
    public class ValidationConfiguration : IConfiguration<IServiceLocator>
    {
        public ValidatorEngine Engine { get; private set; }
        public INHVConfiguration Configuration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationConfiguration"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ValidationConfiguration(INHVConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Loads validation configuration to service locator.
        /// </summary>
        /// <param name="handler">The service locator.</param>
        public void Load(IServiceLocator handler)
        {
            Engine = new ValidatorEngine();
            Engine.Configure(Configuration);

            handler.Register(
                Requested.Service<ValidatorEngine>().IsConstructedBy(x => Engine).LifeStyle.IsSingelton(),
                Requested.Service<IValidationService>().IsImplementedBy<ValidationService>()    
            );
        }

        /// <summary>
        /// Creates default validation configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static ValidationConfiguration Default(INHVConfiguration configuration)
        {
            return new ValidationConfiguration(configuration);
        }
    }
}