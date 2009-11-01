using System.Collections.Generic;

namespace ArcWizard.Core
{
    public class ArcSolution : SolutionTemplate
    {
        private readonly Configuration _configuration;

        public ArcSolution(Configuration configuration)
        {
            _configuration = configuration;
        }

        public override string Name
        {
            get
            {
                return Configuration.SolutionName;
            }
            protected set {}
        }

        public override string RootPath
        {
            get
            {
                return _configuration.RootPath;
            }
            protected set
            {
            }
        }

        public override EnvDTE.Solution Solution
        {
            get
            {
                return _configuration.Application.Solution;
            }
            protected set
            {
            }
        }

        public override IList<string> Directories
        {
            get
            {
                return new List<string>
                           {
                               "\\Schema",
                               "\\Source", 
                               "\\Tests", 
                               "\\Tools"
                           };
            }
        }
    }
}