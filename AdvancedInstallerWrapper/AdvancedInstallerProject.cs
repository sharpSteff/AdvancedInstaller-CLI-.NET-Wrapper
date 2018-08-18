using System.IO;
using AdvancedInstallerWrapper.Utils;

namespace AdvancedInstaller
{
    public class AdvancedInstallerProject
    {
        /// <summary>
        /// Creates an <see cref="AdvancedInstallerProject"/> instance to interact with the advanced installer CLI API
        /// </summary>
        /// <param name="pathToExe">Path to Advanced Installer executable</param>
        public AdvancedInstallerProject(string pathToExe)
        {
            if (!Directory.Exists(pathToExe))
            {
                throw new DirectoryNotFoundException();
            }

            if (!File.Exists(Path.Combine(pathToExe, "advinst.exe")))
            {
                throw new FileNotFoundException("Advanced Installer executable not found!", pathToExe);
            }

            if (!File.Exists(Path.Combine(pathToExe, "AdvancedInstaller.com")))
            {
                throw new FileNotFoundException("Advanced Installer CLI API not found!", pathToExe);
            }

            AdvancedInstallerPath = pathToExe;
        }


        public string ProjectPath
        {
            get;
            private set;
        }

        public string AdvancedInstallerPath
        {
            get;
            private set;
        }

        public bool Open(string path)
        {
            return true;
        }

        public bool CreateProject(string path, ProjectType type = ProjectType.simple, ProjectLanguage lang = ProjectLanguage.en, bool overwrite = false)
        {
            string directoryPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            bool result = AdvinstCLIWrapper.CreateNewProject(AdvancedInstallerPath, path, type, lang, overwrite);
            ProjectPath = result ? path : "";

            return result;
        }
    }
}
