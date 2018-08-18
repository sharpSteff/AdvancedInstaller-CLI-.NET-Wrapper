using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdvancedInstallerWrapper.Utils
{
    public static class ShellCommandExecutor
    {
        public static string ExecuteSynchronous(string workingDirectory, string arguments)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

#if !FEATURE_TYPE_INFO
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
#endif
            startInfo.WorkingDirectory = workingDirectory;
            startInfo.FileName = @"C:\Windows\System32\cmd.exe";
            startInfo.Arguments = "/c" + arguments;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;

            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            string err = process.StandardError.ReadToEnd();
            Console.WriteLine(err);
            process.WaitForExit();

            return string.IsNullOrWhiteSpace(err) ? output : err;
        }
    }
}
