using System;

namespace AdvancedInstallerWrapper.Utils
{
    public static class AdvinstCLIWrapper
    {
        private const string ComName = "AdvancedInstaller.com";

        public static bool CreateNewProject(string path, string projectFilePath, ProjectType type, ProjectLanguage lang, bool overwrite)
        {
            var result = ShellCommandExecutor.ExecuteSynchronous(path,
                ComName +
                "/newproject" +
                projectFilePath +
                (type == ProjectType.simple ? "" : " -type " + type.ToString()) +
                " -lang " + lang.ToString() +
                (overwrite ? " -overwrite" : ""));

            return CheckForError(result);   
        }

        // TODO: Add buildslist and configurationlist 
        public static bool BuildProject(string path, string projectFilePath, bool rebuild = false)
        {
            var result = ShellCommandExecutor.ExecuteSynchronous(path,
                ComName +
                (rebuild ? "/rebuild" : "/build") +
                projectFilePath);

            return CheckForError(result);
        }

        public static bool RefreshSynchronizedFolders(string path, string projectFilePath)
        {
            var result = ShellCommandExecutor.ExecuteSynchronous(path,
               ComName +
               "/RefreshSync" +
               projectFilePath);

            return CheckForError(result);
        }


        private static bool CheckForError(string result)
        {
            throw new NotImplementedException();
        }
    }
}
