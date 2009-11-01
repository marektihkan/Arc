using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Configuration.Conventions;
using Arc.Infrastructure.Dependencies;

namespace $safeprojectname$.Dependencies
{
    public class ControllersConvention : ServiceLocatorConvention
    {
        private readonly string[] _assemblies;

        private ControllersConvention(string[] assemblies)
        {
            _assemblies = assemblies;
        }

        public static IConvention<IServiceLocator> ApplyTo(params string[] assemblies)
        {
            return new ControllersConvention(assemblies);
        }

        protected override void DefineRules()
        {
            For(_assemblies)
                .Pick(x => x.Name.EndsWith("Controller"))
                .BindToSelf();
        }
    }
}