using Arc.Infrastructure.Dependencies;

namespace $safeprojectname$
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ServiceLocator.Load("$safeprojectname$.Dependencies.PresentersConfiguration, $safeprojectname$");
            ServiceLocator.Load("$safeprojectname$.Dependencies.RepositoriesConfiguration, $safeprojectname$");
            ServiceLocator.Load("$safeprojectname$.Dependencies.ServicesConfiguration, $safeprojectname$");
        }
    }
}