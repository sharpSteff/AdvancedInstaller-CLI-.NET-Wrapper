using AdvancedInstallerWrapper.Utils;
using NUnit.Framework;

namespace AdvancedInstallerWrapper_Unittests
{
    [TestFixture]
    public class CLIWrapperTests
    {
        private const string AdvancedInstallerPath = @"C:\Program Files (x86)\Caphyon\Advanced Installer 15.2\bin\x86\";

        [Test]
        public void CreateNewProject()
        {
            bool result = AdvinstCLIWrapper.CreateNewProject(AdvancedInstallerPath, @"D:\test.aip", ProjectType.simple, ProjectLanguage.en, true);
            Assert.IsTrue(result);
        }
    }
}
