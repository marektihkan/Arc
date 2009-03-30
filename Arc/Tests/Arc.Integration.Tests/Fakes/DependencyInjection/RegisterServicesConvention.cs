using System.Reflection;
using Arc.Infrastructure.Dependencies.Conventions;

namespace Arc.Integration.Tests.Fakes.DependencyInjection
{
    public class RegisterServicesConvention : BaseConvention
    {
        protected override void DefineRules()
        {
            For(Assembly.GetExecutingAssembly())
                .Pick(x => x.Name.Contains("Service") && !x.IsGenericType)
                .BindToInterface(x => x.Name.Contains("Service"));
        }
    }
}