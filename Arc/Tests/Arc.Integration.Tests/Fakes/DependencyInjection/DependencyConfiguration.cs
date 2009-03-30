using Arc.Infrastructure.Dependencies;
using Arc.Integration.Tests.Fakes.Model.Services;
using Arc.Integration.Tests.Fakes.Presentation.Mvp;

namespace Arc.Integration.Tests.Fakes.DependencyInjection
{
    public class DependencyConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        public void Configure(IServiceLocator locator)
        {
            var configuration = locator.Configuration;
            configuration.Register<IParameterlessService, ParameterlessServiceImpl>();
            configuration.Register<IService, ServiceImpl>();
            configuration.Register<ITestPresenter, TestPresenter>();
            configuration.Register(typeof(IGenericService<>), typeof(GenericServiceImpl<>));
            configuration.Register<IGenericServiceHost, GenericServiceHostImpl>();
        }
    }
}