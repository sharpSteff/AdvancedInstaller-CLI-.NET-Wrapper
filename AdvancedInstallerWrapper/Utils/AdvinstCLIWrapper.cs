using System;
using System.IO;

namespace AdvancedInstallerWrapper.Utils
{
    public static class AdvinstCLIWrapper
    {
        private const string ComName = "AdvancedInstaller.com";

        public static bool CreateNewProject(string path, string projectFilePath, ProjectType type, ProjectLanguage lang, bool overwrite)
        {
            string command = string.Format("\"{0}\" {1} \"{2}\" {3} {4} {5}",
               Path.Combine(path, ComName),
               "/newproject",
               projectFilePath,
                (type == ProjectType.simple ? "" : " -type " + type.ToString()),
               " -lang " + lang.ToString(),
               (overwrite ? " -overwrite" : ""));

            var result = ShellCommandExecutor.ExecuteSynchronous(command);

            return CheckForError(result);   
        }

        // TODO: Add buildslist and configurationlist 
        public static bool BuildProject(string path, string projectFilePath, bool rebuild = false)
        {
            var result = ShellCommandExecutor.ExecuteSynchronous(
                Path.Combine(path, ComName) +
                (rebuild ? "/rebuild" : "/build") +
                projectFilePath);

            return CheckForError(result);
        }

        public static bool RefreshSynchronizedFolders(string path, string projectFilePath)
        {
            var result = ShellCommandExecutor.ExecuteSynchronous(
               Path.Combine(path, ComName) +
               "/RefreshSync" +
               projectFilePath);

            return CheckForError(result);
        }

        /// <summary>
        /// Change the package output type
        /// </summary>
        /// <param name="path"></param>
        /// <param name="projectFilePath"></param>
        /// <param name="packageType"> MsiInside, MsiOutside, ExeInside, ExeOutside, and WebInstaller</param>
        /// <param name="buildName"> is optional, if not specified, the command applies to the current build</param>
        /// <param name="msiUrl">is required only for the WebInstaller package type</pa6ram>
        /// <returns></returns>
        public static bool ChangePackageOutputType(string path, string projectFilePath, PackageType packageType, string buildName = "", string msiUrl = "")
        {
            string command = string.Format("{0} {1} \"{2}\" {3} {4} {5} {6}",
                Path.Combine(path, ComName), 
                "/edit", 
                projectFilePath, 
                "/SetOutputType", 
                packageType.ToString(), 
                string.IsNullOrWhiteSpace(buildName) ? "" : "-buildname " + buildName,
                (packageType == PackageType.WebInstaller) ? "-msi_url " + "\""+ msiUrl +"\"" : "");

            var result = ShellCommandExecutor.ExecuteSynchronous(command);

            return CheckForError(result);
        }

        private static bool CheckForError(int errorCode)
        {
            if (errorCode == 0)
            {
                return true;
            }

            uint code = errorCode < 0 ?  (uint)(uint.MaxValue - Math.Abs(errorCode) + 1) : (uint)errorCode;
            if (AdvinstErrorCodes.ErrorCodes.ContainsKey(code))
            {
                Console.Write(AdvinstErrorCodes.ErrorCodes[code]);
            }

            return false;
        }
    }
}
