using System.Collections.Generic;
using System.IO;
using Utilities.Logger;
using Workie.DeployHelper.Base;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Models;
using Workie.DeployHelper.Utilities;
using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Modules
{
    internal class InstallOrUpdatePackagesModule : ModuleBase
    {
        #region --- Requests ---

        public override List<UploadFileViewModel> OnRequestingUploadFileList() { return Globals.gApplicationViewModel.ModulesConfig.InstallOrUpdatePackagesModule.UploadFileList; }

        public override string OnRequestingRoutedFilename(string filename)
        {
            return Path.Combine(Globals.GetModuleDependenciesDirectory, GetType().Name, filename);
        }

        #endregion

        #region --- Properties ---

        public DoWorkData DoWorkData { get; set; }

        #endregion

        internal ModuleReport Run()
        {
            DoWorkData = new DoWorkData
            {
                DeployMessage = Properties.Resources.ChooseRemoteHostToInstallOrUpdatePackages,
                OnRunPackageScripts = new OnRunPackageScripts(OnRunPackageScripts),
                OnSftpDisconnect = new OnSftpDisconnect(OnSftpDisconnect),
                OnSftpFileUploaded = new OnSftpFileUploaded(OnSftpFileUploaded),
                OnSshAuthenticateFailure = new OnSshAuthenticateFailure(OnSshAuthenticateFailure),
                OnSshAuthenticateSuccess = new OnSshAuthenticateSuccess(OnSshAuthenticateSuccess),
                OnSftpAuthenticateFailure = new OnSftpAuthenticateFailure(OnSftpAuthenticateFailure),
                OnSftpAuthenticateSuccess = new OnSftpAuthenticateSuccess(OnSftpAuthenticateSuccess),
                OnRequestingUploadFileList = new OnRequestingUploadFileList(OnRequestingUploadFileList),
                OnRequestingRoutedFilename = new OnRequestingRoutedFilename(OnRequestingRoutedFilename)
            };

            return DoWork(DoWorkData);
        }

        public override void OnRunPackageScripts(SshClientEx remoteHost)
        {
            base.OnRunPackageScripts(remoteHost);

            // Create folders...
            LogOutputter.PrintInfo("Updating OS packages...");
            remoteHost.RunCommandWithOutput("sudo yum -y update");

            // Install Apache Service...
            LogOutputter.PrintInfo($"Downloading and installing Apache...");
            remoteHost.RunCommandWithOutput("sudo yum -y install httpd mod_ssl");

            // Install .NET Runtime...
            LogOutputter.PrintInfo("Downloading and installing Microsoft .NET Core runtime...");
            remoteHost.RunCommandWithOutput("sudo rpm -Uvh https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm");

            remoteHost.RunCommandWithOutput("sudo yum -y install dotnet-sdk-2.1");
        }

        #region --- Validation Functions ---

        public override ConflictReport GetConflictsReport()
        {
            var report = new ConflictReport();

            return report;
        }

        #endregion
    }
}
