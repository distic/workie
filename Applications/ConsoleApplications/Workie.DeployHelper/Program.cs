using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using Utilities.Logger;
using Utilities.Logger.Base;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Enums;
using Workie.DeployHelper.Models;
using Workie.DeployHelper.Utilities;
namespace Workie.DeployHelper
{
    class Program
    {
        #region --- Properties ---

        internal static ApplicationViewModel gApplicationViewModel;

        #endregion

        static void Main(string[] args)
        {
            ConsoleEx.PrintLicenseNotice();
            ConsoleEx.PrintNoInterruptionNotice();
            ConsoleEx.PrintTitle(Properties.Resources.AppTitle, withUnderline: true);

            using (StreamReader sr = new StreamReader(Globals.GetConfigFilename))
            {
                var fileContent = sr.ReadToEnd();
                gApplicationViewModel = JsonConvert.DeserializeObject<ApplicationViewModel>(fileContent);
            }

            var isSslEnabledString = gApplicationViewModel.Security.UseSsl ? Properties.Resources.Yes : Properties.Resources.No;

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            var versionArray = fvi.FileVersion.Split('.');
            var versionString = $"{versionArray[0]}.{versionArray[1]} ({versionArray[2]}) ";

            if (System.Convert.ToInt32(versionArray[3]) > 0)
            {
                versionString += "BETA " + versionArray[3];
            }

            LogOutputter.PrintInfo($"{Properties.Resources.Version}: {versionString}", greyScale: true);
            LogOutputter.PrintInfo($"{Properties.Resources.IsSslEnabled} {isSslEnabledString}", newLineAfter: 1, greyScale: true);

            var userChoice = (MainMenuResult)ConsoleEx.MultipleChoice(withNumbering: true, canCancel: true,
                description: string.Empty,
                Properties.Resources.SetupEnvironment,
                Properties.Resources.InstallOrUpdatePackages,
                Properties.Resources.DeployWorkieWebAdmin,
                Properties.Resources.DeployWorkieWebAdminWithoutConfig,
                Properties.Resources.UpdateKestrelForWorkieWebAdmin);

            ModuleReport moduleReport = null;

            switch (userChoice)
            {
                case MainMenuResult.SetupEnvironment:
                    moduleReport = new Modules.SetupEnvironmentModule().Run();
                    break;

                case MainMenuResult.InstallOrUpdatePackages:
                    moduleReport = new Modules.InstallOrUpdatePackagesModule().Run();
                    break;

                case MainMenuResult.DeployWorkieWebAdmin:
                    moduleReport = new Modules.DeployWorkieWebAdminModule().Run();
                    break;

                case MainMenuResult.DeployWorkieWebAdminWithoutConfig:
                    moduleReport = new Modules.DeployWorkieWebAdminWithoutConfigModule().Run();
                    break;

                case MainMenuResult.UpdateKestrelForWorkieWebAdmin:
                    moduleReport = new Modules.UpdateKestrelForWorkieWebAdminModule().Run();
                    break;
            }
        }
    }
}