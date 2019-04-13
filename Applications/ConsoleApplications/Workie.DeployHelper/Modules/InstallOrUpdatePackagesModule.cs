using Renci.SshNet;
using Utilities.Logger;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Utilities;
using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Modules
{
    internal class InstallOrUpdatePackagesModule : ModuleBase
    {
        /// <summary>
        /// Entry point of the routine.
        /// </summary>
        /// <returns></returns>
        internal ModuleReport Run()
        {
            var doWorkData = new DoWorkData
            {
                ModuleCallerName = GetType().Name,
                DeployMessage = Properties.Resources.ChooseRemoteHostToInstallOrUpdatePackages,
                OnRunPackageScripts = new OnRunPackageScripts(OnRunPackageScripts),
                OnResolvePrerequisites = new OnResolvePrerequisites(OnResolvePrerequisites),
                OnSftpDisconnect = new OnSftpDisconnect(OnSftpDisconnect),
                OnSftpFileUploaded = new OnSftpFileUploaded(OnSftpFileUploaded),
                OnSshAuthenticateFailure = new OnSshAuthenticateFailure(OnSshAuthenticateFailure),
                OnSshAuthenticateSuccess = new OnSshAuthenticateSuccess(OnSshAuthenticateSuccess),
                OnSftpAuthenticateFailure = new OnSftpAuthenticateFailure(OnSftpAuthenticateFailure),
                OnSftpAuthenticateSuccess = new OnSftpAuthenticateSuccess(OnSftpAuthenticateSuccess)
            };

            return DoWork(doWorkData);
        }

        public override void OnResolvePrerequisites(SftpClient sftpClient)
        {

        }

        public override void OnRunPackageScripts(SshClientEx remoteHost)
        {
            // Create folders...
            LogOutputter.PrintInfo("Updating operating system packages...");
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
