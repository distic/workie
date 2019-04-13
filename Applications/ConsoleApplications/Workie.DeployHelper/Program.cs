using Newtonsoft.Json;
using System.IO;
using Utilities.Logger;
using Utilities.Logger.Base;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Enums;
using Workie.DeployHelper.Models;

namespace Workie.DeployHelper
{
    class Program
    {
        #region --- Properties ---

        internal static ApplicationViewModel gApplicationViewModel;

        #endregion

        const string jsonFile = @"C:\Users\ahmad\source\repos\workie-core\Applications\ConsoleApplications\Workie.DeployHelper\_InstallData\Workie.DeployHelper.Linux.json";

        static void Main(string[] args)
        {
            ConsoleEx.PrintLicenseNotice();
            ConsoleEx.PrintNoInterruptionNotice();
            ConsoleEx.PrintTitle(Properties.Resources.AppTitle, withUnderline: true);

            using (StreamReader streamReader = new StreamReader(jsonFile))
            {
                var fileContent = streamReader.ReadToEnd();
                gApplicationViewModel = JsonConvert.DeserializeObject<ApplicationViewModel>(fileContent);
            }

            var isSslEnabledString = gApplicationViewModel.Security.UseSsl ? Properties.Resources.Yes : Properties.Resources.No;

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