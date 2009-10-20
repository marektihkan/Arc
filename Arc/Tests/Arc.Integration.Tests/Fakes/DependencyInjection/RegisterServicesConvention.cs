using System.Reflection;
using Arc.Infrastructure.Configuration.Conventions;

namespace Arc.Integration.Tests.Fakes.DependencyInjection
{
    public class RegisterServicesConvention : ServiceLocatorConvention
    {
        protected override void DefineRules()
        {
            For(Assembly.GetExecutingAssembly())
                .Pick(x => x.Name.Contains("Service") && !x.IsGenericType)
                .BindToInterface(x => x.Name.Contains("Service"));
        }
    }
}