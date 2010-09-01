using Arc.Integration.Tests.Fakes.Model.Services;
using Arc.Integration.Tests.Fakes.Presentation.Mvp;
using Ninject.Modules;

namespace Arc.Integration.Tests.Fakes.DependencyInjection
{
    public class ConfigurationModule : NinjectModule
    {
        public const string ValidModuleName = "Arc.Integration.Tests.Fakes.DependencyInjection.ConfigurationModule, Arc.Integration.Tests";
        public const string InvalidModuleName = "Arc.Integration.Tests.Fakes.DependencyInjection.NotFoundConfigurationModule, Arc.Integration.Tests";

        public override void Load()
        {
            Bind<IParameterlessService>().To<ParameterlessServiceImpl>();
            Bind<IService>().To<ServiceImpl>();
            Bind<ITestPresenter>().To<TestPresenter>();
        }
    }
}