using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Integration.Tests.Fakes.Model.Services;
using Arc.Integration.Tests.Fakes.Presentation.Mvp;

namespace Arc.Integration.Tests.Fakes.DependencyInjection
{
    public class DependencyConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        public void Configure(IServiceLocator locator)
        {
            locator.Register(
                Requested.Service<IParameterlessService>().IsImplementedBy<ParameterlessServiceImpl>(),
                Requested.Service<IService>().IsImplementedBy<ServiceImpl>(),
                Requested.Service<ITestPresenter>().IsImplementedBy<TestPresenter>(),
                Requested.Service(typeof(IGenericService<>)).IsImplementedBy(typeof(GenericServiceImpl<>)),
                Requested.Service<IGenericServiceHost>().IsImplementedBy<GenericServiceHostImpl>()
                );
        }
    }
}