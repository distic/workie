using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using Utilities.Linux.Shell.Security;
using Utilities.Logger;
using Workie.DeployHelper.Base;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Extensions;
using Workie.DeployHelper.Models;
using Workie.DeployHelper.Utilities;
using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Modules
{
    internal class DeployWorkieWebAdminModule : ModuleBase
    {
        #region --- Requests ---

        public override List<UploadFileViewModel> OnRequestingUploadFileList() { return Globals.gApplicationViewModel.ModulesConfig.DeployWorkieWebAdminModule.UploadFileList; }

        public override string OnRequestingRoutedFilename(string filename)
        {
            return System.IO.Path.Combine(Globals.GetModuleDependenciesDirectory, GetType().Name, filename);
        }

        #endregion

        #region --- Properties ---

        public DoWorkData DoWorkData { get; set; }

        #endregion

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
            var sourceToPublish = Globals.gApplicationViewModel.ModulesConfig.DeployWorkieWebAdminModule.Source;

#if DEBUG
            var publishDirectory = Globals.gApplicationViewModel.ModulesConfig.DeployWorkieWebAdminModule.Publish.Debug;
#else
            var publishDirectory = Globals.gApplicationViewModel.DeployWorkieWebAdminModule.Publish.Release;
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
            System.IO.File.Delete(workieWebAdminZip);

            // Create a new compressed file.
            ZipFile.CreateFromDirectory(publishDirectory, workieWebAdminZip);
        }

        public override void OnRunPackageScripts(SshClientEx remoteHost)
        {
            base.OnRunPackageScripts(remoteHost);

            var deployWorkieWebAdminModule = Globals.gApplicationViewModel.ModulesConfig.DeployWorkieWebAdminModule;

            var remotehostWorkieWebAdminDirectory = deployWorkieWebAdminModule.RemotehostWorkieWebAdminDirectory;

            //TODO: HACK, make sure to keep this setting dynamic.
            remoteHost.Unzip(zipFilename: "/var/aspnetcore/webapps/Workie.Web.Admin/Workie.Web.Admin.zip", dst: remotehostWorkieWebAdminDirectory, forceOverwrite: true, sudo: true, output: true);

            remoteHost.CreateDirectory(remotehostWorkieWebAdminDirectory, sudo: true);


            // Update permissions
            LogOutputter.Print("Updating permissions...", isSub: true);


            var dstKestrelFile = deployWorkieWebAdminModule.RemotehostKestrelFilename;
            var dstHttpdConfFile = deployWorkieWebAdminModule.RemotehostHttpdFilename;

            remoteHost.ResetPermission(dstKestrelFile, sudo: true);
            remoteHost.ResetPermission(dstHttpdConfFile, sudo: true);

            remoteHost.ChangeOwner(dstKestrelFile, "root", sudo: true);
            remoteHost.ChangeGroup(dstKestrelFile, "root", sudo: true);

            remoteHost.ChangeAttributes(dstKestrelFile, false, sudo: true,
                user_permission: new FileAttributes { Read = true, Write = true, Execute = false },
                group_permission: new FileAttributes { Read = true, Write = false, Execute = false },
                other_permission: new FileAttributes { Read = true, Write = false, Execute = false });

            remoteHost.ChangeOwner(dstHttpdConfFile, "root", sudo: true);
            remoteHost.ChangeGroup(dstHttpdConfFile, "root", sudo: true);

            remoteHost.ChangeAttributes(dstHttpdConfFile, false, sudo: true,
                user_permission: new FileAttributes { Read = true, Write = true, Execute = false },
                group_permission: new FileAttributes { Read = true, Write = false, Execute = false },
                other_permission: new FileAttributes { Read = true, Write = false, Execute = false });

            // ============================================================================================= //

            remoteHost.ResetPermission(remotehostWorkieWebAdminDirectory, true, sudo: true);

            remoteHost.ChangeAttributes(remotehostWorkieWebAdminDirectory,
                recursive: true,
                sudo: true,
                user_permission: new FileAttributes { Read = true, Write = true, Execute = true },
                group_permission: new FileAttributes { Read = true, Write = true, Execute = true });

            remoteHost.ChangeGroup(remotehostWorkieWebAdminDirectory, "QzWorkieAdmin", true, sudo: true);
            remoteHost.ChangeOwner(remotehostWorkieWebAdminDirectory, ServerInfo.Username, true, sudo: true);

            // Start services
            LogOutputter.Print("Starting services...", isSub: true);

            remoteHost.SystemCtlEnable("httpd", sudo: true);
            remoteHost.SystemCtlRestart("httpd", sudo: true);
            remoteHost.SystemCtlEnable(dstKestrelFile, sudo: true);
            remoteHost.SystemCtlStart(dstKestrelFile, sudo: true);
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
