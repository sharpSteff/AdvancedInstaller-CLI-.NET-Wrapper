using System;
using System.IO;

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
            if (!File.Exists(pathToExe))
            {
                throw new FileNotFoundException("Advanced Installer executable not found!", pathToExe);
            }

        }

        public bool Open(string path)
        {
            return true;
        }
    }
}
