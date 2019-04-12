using System;
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

        public virtual DependencyReport GetDependencyReport()
        {
            // Do nothing...
            return null;
        }

        #endregion

        #region --- Module Main Processor ---

        public virtual void OnSshAuthenticateSuccess(SshClientEx remoteHost)
        {
            // do nothing
        }

        public virtual void OnSshAuthenticateFailure()
        {
            // do nothing
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
                LogOutputter.PrintInfo("Attempting to authenticate, please wait...");

                using (var remoteHost = new SshClientEx(ServerInfo.IpAddress, ServerInfo.Username, ServerInfo.Password))
                {
                    remoteHost.Connect();

                    if (!remoteHost.IsConnected)
                    {
                        LogOutputter.PrintError("Failed to connect to the remote host!");
                        doWorkData.OnSshAuthenticateFailure();
                    }

                    LogOutputter.PrintSuccess($"Logged in as '{ServerInfo.Username}' on remote host '{ServerInfo.IpAddress}'");

                    doWorkData.OnSshAuthenticateSuccess(remoteHost);
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