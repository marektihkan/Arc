using EnvDTE;

namespace ArcWizard.Tasks.Projects
{
    public class AddNHibernateConfigurationTask
    {
        public void AddConfigurationLinkTo(Project project, string solutionRootPath)
        {
            var itemPath = solutionRootPath + "\\Configuration\\hibernate.cfg.xml";
            var item = project.ProjectItems.AddFromFile(itemPath);
            item.Properties.Item("CopyToOutputDirectory").Value = 1;
        }
    }
}