using Newtonsoft.Json;
using System;
using System.IO;
using Utilities.Console;
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
            const string jsonFile = "C:\\Users\\ahmad\\source\\repos\\workie-core\\Applications\\ConsoleApplications\\Workie.DeployHelper\\Workie.DeployHelper.Linux.json";

            Outputter.PrintLicenseNotice();

            Outputter.PrintNoInterruptionNotice(
                preDescription: Properties.Resources.PreDescription,
                withTimer: true,
                preDescriptionNewLineAfter: true);

            Outputter.PrintTitle(Properties.Resources.AppTitle, withUnderline: true);

            using (StreamReader streamReader = new StreamReader(jsonFile))
            {
                var fileContent = streamReader.ReadToEnd();
                gApplicationViewModel = JsonConvert.DeserializeObject<ApplicationViewModel>(fileContent);
            }

            Console.WriteLine("[ INFO ] {0}: {1}\n", Properties.Resources.IsSslEnabled, gApplicationViewModel.Security.UseSsl ? 
                Properties.Resources.Yes : Properties.Resources.No);

            var userChoice = (MainMenuResult)Menu.MultipleChoice(withNumbering: true, canCancel: true,
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