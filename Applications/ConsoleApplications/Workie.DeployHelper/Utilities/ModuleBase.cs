using Renci.SshNet;
using System;
using System.Diagnostics;
using System.IO;
using Utilities.Logger;
using Utilities.Logger.Base;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Enums;
using Workie.DeployHelper.Interfaces;
using Workie.DeployHelper.Models;

namespace Workie.DeployHelper.Utilities
{
    internal class ModuleBase : IModule
    {
        #region --- Properties ---

        internal ServerInfoViewModel ServerInfo { get; set; }

        #endregion

        #region --- Validation Functions ---

        public virtual ConflictReport GetConflictsReport()
        {
            // Do nothing...
            return null;
        }

        #endregion

        #region --- Event Handlers ---

        public virtual void OnResolvePrerequisites(SftpClient sftpClient)
        {
            // do nothing.
            LogOutputter.PrintWarning($"Event '{AssemblyInfo.GetCurrentMethod()}' not handled, consider handling when necessary.");
        }

        public virtual void OnRunPackageScripts(SshClientEx remoteHost)
        {
            // do nothing
            LogOutputter.PrintWarning($"Event '{AssemblyInfo.GetCurrentMethod()}' not handled, consider handling when necessary.");
        }

        public virtual void OnSshAuthenticateSuccess(SshClientEx remoteHost)
        {
            // do nothing
            LogOutputter.PrintWarning($"Event '{AssemblyInfo.GetCurrentMethod()}' not handled, consider handling when necessary.");
        }

        public virtual void OnSshAuthenticateFailure()
        {
            // do nothing
            LogOutputter.PrintWarning($"Event '{AssemblyInfo.GetCurrentMethod()}' not handled, consider handling when necessary.");
        }

        public virtual void OnSftpAuthenticateSuccess(SftpClient sftpClient)
        {
            // do nothing
            LogOutputter.PrintWarning($"Event '{AssemblyInfo.GetCurrentMethod()}' not handled, consider handling when necessary.");
        }

        public virtual void OnSftpAuthenticateFailure()
        {
            // do nothing
            LogOutputter.PrintWarning($"Event '{AssemblyInfo.GetCurrentMethod()}' not handled, consider handling when necessary.");
        }

        public virtual void OnSftpDisconnect()
        {
            // do nothing.
            LogOutputter.PrintWarning($"Event '{AssemblyInfo.GetCurrentMethod()}' not handled, consider handling when necessary.");
        }

        public virtual void OnSftpFileUploaded(SshClientEx remoteHost, UploadFileViewModel uploadFile)
        {
            // do nothing.
            LogOutputter.PrintWarning($"Event '{AssemblyInfo.GetCurrentMethod()}' not handled, consider handling when necessary.");
        }

        #endregion

        /// <summary>
        /// Main routine.
        /// </summary>
        /// <returns></returns>
        public ModuleReport DoWork(DoWorkData doWorkData)
        {
            Console.Clear();

            GetRemoteHostStringFromUserInput(doWorkData.DeployMessage);

            if (string.IsNullOrEmpty(ServerInfo.IpAddress))
            {
                LogOutputter.PrintError("User cancelled the operation!");
                return new ModuleReport(ExecutionResult.UserCancel, isCompleted: false);
            }

            if (!GetRemoteHostAuthenticationFromUserInput(Properties.Resources.PleaseEnterTheRemoteHostLoginCredentials))
            {
                LogOutputter.PrintError("Didn't get credentials!");
                return new ModuleReport(ExecutionResult.Failure, isCompleted: false);
            }

            try
            {
                LogOutputter.PrintBusy("Authenticating SSH session...");

                using (var remoteHost = new SshClientEx(ServerInfo.IpAddress, ServerInfo.Username, ServerInfo.Password))
                {
                    remoteHost.Connect();

                    if (!remoteHost.IsConnected)
                    {
                        LogOutputter.PrintError("Failed to connect to the remote host!", isSub: true);
                        doWorkData.OnSshAuthenticateFailure();
                    }

                    LogOutputter.PrintSuccess($"Logged in as '{ServerInfo.Username}' on remote host '{ServerInfo.IpAddress}'", isSub: true);

                    doWorkData.OnSshAuthenticateSuccess(remoteHost);

                    if (doWorkData.UploadFileList != null)
                    {
                        if (doWorkData.UploadFileList.Count > 0)
                        {
                            LogOutputter.PrintBusy("Authenticating SFTP session...");
                            using (var sftpClient = new SftpClient(remoteHost.ConnectionInfo))
                            {
                                sftpClient.Connect();

                                if (!sftpClient.ConnectionInfo.IsAuthenticated)
                                {
                                    LogOutputter.PrintError("SFTP pipe cannot be opened.", isSub: true);
                                    doWorkData.OnSftpAuthenticateFailure();
                                    return new ModuleReport(ExecutionResult.Failure, isCompleted: false);
                                }

                                LogOutputter.PrintSuccess("SFTP pipe opened.", isSub: true);
                                doWorkData.OnSftpAuthenticateSuccess(sftpClient);

                                FileStream fileStream;

                                foreach (var uploadFileInfo in doWorkData.UploadFileList)
                                {
                                    LogOutputter.PrintBusy($"Uploading file '{uploadFileInfo.LocalhostFilename}'...");

                                    if (!File.Exists(uploadFileInfo.LocalhostFilename) && !uploadFileInfo.IsRequired)
                                    {
                                        LogOutputter.PrintWarning($"File not found, but skipped anyway.", isSub: true);
                                        continue;
                                    }

                                    if ((fileStream = new FileStream(uploadFileInfo.LocalhostFilename, FileMode.Open)) == null)
                                    {
                                        if (!uploadFileInfo.IsRequired)
                                        {
                                            LogOutputter.PrintWarning($"Skipped.", isSub: true);
                                            continue;
                                        }

                                        LogOutputter.PrintError("File stream problem, please try again later!", isSub: true);
                                        return new ModuleReport(ExecutionResult.Failure, isCompleted: false);
                                    }

                                    sftpClient.UploadFile(fileStream, uploadFileInfo.RemotehostFilename);
                                    LogOutputter.PrintWarning($"Assuming upload of '{uploadFileInfo.LocalhostFilename}' was successful.", isSub: true);
                                    doWorkData.OnSftpFileUploaded(remoteHost, uploadFileInfo);
                                }

                                doWorkData.OnSftpDisconnect();
                                sftpClient.Disconnect();
                            }
                        }
                    }

                    LogOutputter.PrintBusy("Running package scripts...");
                    doWorkData.OnRunPackageScripts(remoteHost);
                }
            }
            catch (Exception ex)
            {
                LogOutputter.PrintFatal(ex.Message);
                return new ModuleReport(ExecutionResult.Failure, isCompleted: false);
            }

            return new ModuleReport(ExecutionResult.Success, isCompleted: true);
        }

        /// <summary>
        /// Get the remote host string from the user.
        /// </summary>
        /// <param name="description">The message to be shown before displaying the listed servers.</param>
        /// <returns>TRUE if successful. FALSE, otherwise.</returns>
        private bool GetRemoteHostStringFromUserInput(string description)
        {
            var serverInfoList = Program.gApplicationViewModel.ServerInfoList;

            var serverArray = new string[serverInfoList.Count];

            for (int i = 0; i < serverInfoList.Count; i++)
            {
                serverArray[i] = serverInfoList[i].ListName;
            }

            var index = ConsoleEx.MultipleChoice(
                withNumbering: false,
                canCancel: true,
                description: description,
                serverArray);

            if (index == -1)
            {
                return false;
            }

            ServerInfo = serverInfoList[index];

            return true;
        }

        /// <summary>
        /// Get the remote host authentication from the user.
        /// </summary>
        /// <param name="description">The message to be shown before displaying the listed servers.</param>
        /// <returns>The server's IP Address.</returns>
        private bool GetRemoteHostAuthenticationFromUserInput(string description)
        {
            if (!string.IsNullOrEmpty(ServerInfo.Username) && !string.IsNullOrEmpty(ServerInfo.Password))
            {
                return true;
            }

            ServerInfo.Username = string.Empty;
            ServerInfo.Password = string.Empty;

            if (!string.IsNullOrEmpty(description))
            {
                System.Console.WriteLine("-> {0}:", description);
            }

            System.Console.WriteLine();

            System.Console.Write("{0}: ", Properties.Resources.EnterUsername);
            ServerInfo.Username = System.Console.ReadLine();

            System.Console.Write("{0}: ", Properties.Resources.EnterPassword);
            ServerInfo.Password = System.Console.ReadLine();

            if (string.IsNullOrEmpty(ServerInfo.Username))
            {
                return false;
            }

            if (string.IsNullOrEmpty(ServerInfo.Password))
            {
                return false;
            }

            return true;
        }
    }
}