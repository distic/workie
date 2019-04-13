using Renci.SshNet;
using System.Collections.Generic;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Models;
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
                DeployMessage = Properties.Resources.ChooseRemoteHostToDeployWorkieWebAdmin,
                OnRunPackageScripts = new OnRunPackageScripts(OnRunPackageScripts),
                OnSftpDisconnect = new OnSftpDisconnect(OnSftpDisconnect),
                OnSftpFileUploaded = new OnSftpFileUploaded(OnSftpFileUploaded),
                OnSshAuthenticateFailure = new OnSshAuthenticateFailure(OnSshAuthenticateFailure),
                OnSshAuthenticateSuccess = new OnSshAuthenticateSuccess(OnSshAuthenticateSuccess),
                OnSftpAuthenticateFailure = new OnSftpAuthenticateFailure(OnSftpAuthenticateFailure),
                OnSftpAuthenticateSuccess = new OnSftpAuthenticateSuccess(OnSftpAuthenticateSuccess),
                UploadFileList = new List<UploadFileViewModel>
                {
                    new UploadFileViewModel
                    {
                        LocalhostFilename = Program.gApplicationViewModel.Localhost.DefaultZipFilename,
                        RemotehostFilename = "setupZipFileName",
                        IsRequired = true
                    }
                }
            };

            return DoWork(doWorkData);
        }

        public override void OnRunPackageScripts(SshClientEx remoteHost)
        {

        }

        #region --- Validation Functions ---

        public override ConflictReport GetConflictsReport()
        {
            var report = new ConflictReport();

            return report;
        }

        public override DependencyReport GetDependencyReport()
        {
            var report = new DependencyReport();

            return report;
        }

        #endregion
    }
}
