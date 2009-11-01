using System.Web.Mvc;
using $solutionname$.Configuration;
using Spark;
using Spark.Web.Mvc;

namespace $safeprojectname$
{
    public class MvcApplication : ArcApplication
    {
        protected override void ConfigureViewEngine()
        {
            var settings = new SparkSettings()
                .SetDebug(true)
                .AddNamespace("System")
                .AddNamespace("System.Collections.Generic")
                .AddNamespace("System.Web.Mvc");

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new SparkViewFactory(settings));
        }
    }
}