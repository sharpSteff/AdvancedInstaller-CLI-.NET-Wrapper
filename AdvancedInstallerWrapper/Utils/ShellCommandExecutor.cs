using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AdvancedInstallerWrapper.Utils
{
    public static class ShellCommandExecutor
    {
        public static int ExecuteSynchronous(string arguments)
        {
            using (Process process = new Process())
            {

#if !FEATURE_TYPE_INFO
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
#endif
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = string.Format("{0} \"{1}\"", "/c", arguments);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                string err = process.StandardError.ReadToEnd();
                Console.WriteLine(err);
                process.WaitForExit();
                return process.ExitCode;
            }
        }
    }
}
