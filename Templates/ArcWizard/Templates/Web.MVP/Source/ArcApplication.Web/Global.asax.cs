using $solutionname$.Configuration;

namespace $safeprojectname$
{
    public class Global : Arc.Infrastructure.Configuration.ArcApplication
    {
        public override void Init()
        {
            base.Init();

            Bootstrapper.Configure();
        }
    }
}