using Arc.Infrastructure.Dependencies;

namespace Arc.Integration.Tests.Fakes.DependencyInjection
{
    public class DependencyConfiguration : IDependencyConfiguration
    {
        public void Configure(IServiceLocator locator)
        {
            locator.Register<IParameterlessService, ParameterlessServiceImpl>();
        }
    }
}