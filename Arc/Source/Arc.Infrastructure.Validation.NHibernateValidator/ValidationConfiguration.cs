  

using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;

namespace Arc.Infrastructure.Validation.NHibernateValidator
{
    public class ValidationConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        public ValidatorEngine Engine { get; private set; }
        public INHVConfiguration Configuration { get; set; }

        public ValidationConfiguration(INHVConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IServiceLocator serviceLocator)
        {
            Engine = new ValidatorEngine();
            Engine.Configure(Configuration);

            serviceLocator.Register(
                Requested.Service<ValidatorEngine>().IsConstructedBy(x => Engine).LifeStyle.IsSingelton(),
                Requested.Service<IValidationService>().IsImplementedBy<ValidationService>()    
            );
        }

        public static ValidationConfiguration Default(INHVConfiguration configuration)
        {
            return new ValidationConfiguration(configuration);
        }
    }
}