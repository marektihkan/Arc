using System;
using System.IO;
using ArcWizard.Core;
using ArcWizard.Tasks.IO;
using EnvDTE;
using EnvDTE80;
using Configuration=ArcWizard.Core.Configuration;

namespace ArcWizard.Tasks.Projects
{
    public class MoveProjectTask
    {
        private readonly Configuration _configuration;
        private readonly AddProjectTask _addProjectTask;
        private readonly RemoveProjectTask _removeProjectTask;
        private readonly MoveDirectoryTask _moveDirectoryTask;


        public MoveProjectTask(Configuration configuration)
        {
            _configuration = configuration;
            _addProjectTask = new AddProjectTask();
            _removeProjectTask = new RemoveProjectTask();
            _moveDirectoryTask = new MoveDirectoryTask();
        }


        public Project MoveTo(Project project, string targetSubFolder)
        {
            return MoveTo(project, targetSubFolder, null);
        }

        public Project MoveTo(Project project, string targetSubFolder, string solutionFolderName)
        {
            var projectName = project.Name;
            var originalLocation = GetOriginalLocation(projectName);

            if (!Directory.Exists(originalLocation))
                throw new ApplicationException("Couldn't find " + originalLocation + " to move");
            
            var solution = GetSolution();

            _removeProjectTask.RemoveProjectFrom(solution, project);

            var targetLocation = GetTargetLocation(projectName, targetSubFolder);
            _moveDirectoryTask.Move(originalLocation, targetLocation);

            var projectPath = ProjectPathBuilder.CSharpProject(targetLocation, projectName);

            return string.IsNullOrEmpty(solutionFolderName) 
                       ? _addProjectTask.AddProjectFromFileTo(solution, projectPath) 
                       : _addProjectTask.AddProjectFromFileTo(solution, solutionFolderName, projectPath);
        }

        private Solution2 GetSolution()
        {
            return _configuration.Application.Solution as Solution2;
        }


        private string GetTargetLocation(string projectName, string targetSubFolder)
        {
            return GetBaseLocation() + targetSubFolder + projectName;
        }

        private string GetOriginalLocation(string projectName)
        {
            return GetBaseLocation() + "\\" + projectName;
        }

        private string GetBaseLocation()
        {
            return _configuration.RootPath;
        }
    }
}