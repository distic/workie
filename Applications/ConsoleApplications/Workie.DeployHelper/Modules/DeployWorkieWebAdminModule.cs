using System.Collections.Generic;
using System.Diagnostics;
using Utilities.Logger;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Models;
using Workie.DeployHelper.Utilities;
using Workie.DeployHelper.Extensions;
using static Workie.DeployHelper.Delegates.ModuleDelegates;
using System.IO.Compression;
using System.IO;

namespace Workie.DeployHelper.Modules
{
    internal class DeployWorkieWebAdminModule : ModuleBase
    {
        #region --- Requests ---

        public override List<UploadFileViewModel> OnRequestingUploadFileList() { return Program.gApplicationViewModel.DeployWorkieWebAdminModule.UploadFileList; }

        public override string OnRequestingRoutedFilename(string filename)
        {
            return Path.Combine(Globals.GetModuleDependenciesDirectory, GetType().Name, filename);
        }

        #endregion

        #region --- Properties ---

        public DoWorkData DoWorkData { get; set; }

        #endregion

        /// <summary>
        /// Entry point of the routine.
        /// </summary>
        /// <returns></returns>
        internal ModuleReport Run()
        {
            DoWorkData = new DoWorkData
            {
                DeployMessage = Properties.Resources.ChooseRemoteHostToDeployWorkieWebAdmin,
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

        public override void OnSshAuthenticateSuccess(SshClientEx remoteHost)
        {
            var sourceToPublish = Program.gApplicationViewModel.DeployWorkieWebAdminModule.Source;

#if DEBUG
            var publishDirectory = Program.gApplicationViewModel.DeployWorkieWebAdminModule.Publish.Debug;
#else
            var publishDirectory = Program.gApplicationViewModel.DeployWorkieWebAdminModule.Publish.Release;
#endif

            LogOutputter.PrintBusy("Publishing Workie.Web.Admin...");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"publish {sourceToPublish}",
                    UseShellExecute = true
                }
            };

            process.Start();
            process.WaitForExit();

            LogOutputter.Print($"Compressing published web app '{publishDirectory.Filename()}'...", isSub: true);

            var workieWebAdminZip = OnRequestingRoutedFilename("Workie.Web.Admin.zip");

            // Delete old web app...
            File.Delete(workieWebAdminZip);

            // Create a new compressed file.
            ZipFile.CreateFromDirectory(publishDirectory, workieWebAdminZip);
        }

        public override void OnRunPackageScripts(SshClientEx remoteHost)
        {
            foreach (var uploadFileInfo in UploadedFileList)
            {
                LogOutputter.PrintInfo($"Now running scripts for object '{uploadFileInfo.HostSourceFilename.Filename()}'...", isSub: true);

                foreach (var cmd in uploadFileInfo.Scripts)
                {
                    LogOutputter.Print($"Executing '{cmd}'...", isSub: true);

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
