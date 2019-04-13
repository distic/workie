using Utilities.Linux.Shell.Security;
using Utilities.Logger;
using Utilities.Logger.Base;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Utilities;
using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Modules
{
    internal class SetupEnvironmentModule : ModuleBase
    {
        /// <summary>
        /// Entry point of the routine.
        /// </summary>
        /// <returns></returns>
        internal ModuleReport Run()
        {
            var doWorkData = new DoWorkData
            {
                DeployMessage = Properties.Resources.ChooseRemoteHostToSetupEnvironment,
                OnRunPackageScripts = new OnRunPackageScripts(OnRunPackageScripts),
                OnSftpDisconnect = new OnSftpDisconnect(OnSftpDisconnect),
                OnSftpFileUploaded = new OnSftpFileUploaded(OnSftpFileUploaded),
                OnSshAuthenticateFailure = new OnSshAuthenticateFailure(OnSshAuthenticateFailure),
                OnSshAuthenticateSuccess = new OnSshAuthenticateSuccess(OnSshAuthenticateSuccess),
                OnSftpAuthenticateFailure = new OnSftpAuthenticateFailure(OnSftpAuthenticateFailure),
                OnSftpAuthenticateSuccess = new OnSftpAuthenticateSuccess(OnSftpAuthenticateSuccess)
            };

            return DoWork(doWorkData);
        }

        public override void OnRunPackageScripts(SshClientEx remoteHost)
        {
            // Create folders...
            LogOutputter.Print($"Creating directories...", isSub: true);
            remoteHost.CreateDirectory("/var/aspnetcore", sudo: true);
            remoteHost.CreateDirectory("/var/aspnetcore/webapps", sudo: true);
            remoteHost.CreateDirectory("/var/aspnetcore/webservices", sudo: true);

            // Add groups
            LogOutputter.Print("Creating groups...", isSub: true);
            remoteHost.AddGroup("QzCustomerConsole");
            remoteHost.AddGroup("QzCustomerFront");
            remoteHost.AddGroup("QzCustomer");
            remoteHost.AddGroup("AspNetCore");

            // Add users to their groups
            LogOutputter.Print("Updating user groups...", isSub: true);
            remoteHost.AddUserToGroup("apache", "QzCustomerFront", sudo: true);
            remoteHost.AddUserToGroup("apache", "QzCustomerConsole", sudo: true);
            remoteHost.AddUserToGroup("apache", "QzCustomer", sudo: true);
            remoteHost.AddUserToGroup("apache", "AspNetCore", sudo: true);

            // Setup permissions...
            LogOutputter.Print("Updating permissions...", isSub: true);
            remoteHost.ResetPermission("/var/aspnetcore", recursive: true, sudo: true);

            remoteHost.ChangeGroup("/var/aspnetcore", "AspNetCore", recursive: true, sudo: true);
            remoteHost.ChangeAttributes("/var/aspnetcore", recursive: true,
                user_permission: new FileAttributes { Read = true, Write = true, Execute = true },
                group_permission: new FileAttributes { Read = true, Write = true, Execute = true },
                sudo: true);
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