using Utilities.Console;
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

        public virtual ModuleReport Run()
        {
            GetRemoteHostStringFromUserInput(Properties.Resources.ChooseRemoteHostToDeployWorkieWebAdmin);

            if (string.IsNullOrEmpty(ServerInfo.IpAddress))
            {
                return new ModuleReport(ExecutionResult.UserCancel, isCompleted: false);
            }

            if (!GetRemoteHostAuthenticationFromUserInput(Properties.Resources.PleaseEnterTheRemoteHostLoginCredentials))
            {
                return new ModuleReport(ExecutionResult.Failure, isCompleted: false);
            }

            return null;
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
                serverArray[i] = serverInfoList[i].IpAddress;
            }

            var index = Menu.MultipleChoice(
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