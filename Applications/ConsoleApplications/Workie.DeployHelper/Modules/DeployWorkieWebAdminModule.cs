using Utilities.Logger;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Utilities;
using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Modules
{
    internal class DeployWorkieWebAdminModule : ModuleBase
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
                DeployMessage = Properties.Resources.ChooseRemoteHostToDeployWorkieWebAdmin,
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
            LogOutputter.Print("Running module dependency scripts...", isSub: true);

            foreach (var uploadFileInfo in UploadedFileList)
            {
                foreach (var cmd in uploadFileInfo.Scripts)
                {
                    remoteHost.RunCommandWithOutput(cmd);
                }
            }
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
