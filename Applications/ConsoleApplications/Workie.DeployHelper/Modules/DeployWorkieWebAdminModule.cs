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
                OnSshAuthenticateSuccess = new OnSshAuthenticateSuccess(OnSshAuthenticateSuccess),
                OnSshAuthenticateFailure = new OnSshAuthenticateFailure(OnSshAuthenticateFailure),
                OnSftpAuthenticateSuccess = new OnSftpAuthenticateSuccess(OnSftpAuthenticateSuccess),
                OnSftpAuthenticateFailure = new OnSftpAuthenticateFailure(OnSftpAuthenticateFailure),
                OnSftpDisconnect = new OnSftpDisconnect(OnSftpDisconnect),
                OnSftpFileUploaded = new OnSftpFileUploaded(OnSftpFileUploaded),
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

        public override void OnSshAuthenticateSuccess(SshClientEx remoteHost)
        {

        }

        public override void OnSshAuthenticateFailure()
        {

        }

        public override void OnSftpAuthenticateSuccess(SftpClient sftpClient)
        {

        }

        public override void OnSftpAuthenticateFailure()
        {

        }

        public override void OnSftpDisconnect()
        {

        }

        public override void OnSftpFileUploaded(SshClientEx remoteHost, UploadFileViewModel uploadFile)
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
