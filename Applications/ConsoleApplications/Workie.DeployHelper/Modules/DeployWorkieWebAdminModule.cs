using System;
using Utilities.Logger;
using Workie.DeployHelper.Enums;
using Workie.DeployHelper.Exceptions;
using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Modules
{
    internal class DeployWorkieWebAdminModule : ModuleBase
    {
        public override ModuleReport Run()
        {
            var result = base.Run();
            if (result != null) { return result; }

            try
            {
                LogOutputter.PrintInfo("Attempting to authenticate, please wait...");

                using (var remoteHost = new SshClientEx(ServerInfo.IpAddress, ServerInfo.Username, ServerInfo.Password))
                {
                    remoteHost.Connect();

                    if (!remoteHost.IsConnected)
                    {
                        LogOutputter.PrintError("Failed to connect to the remote host!");
                        throw new DeployWorkieWebAdminException();
                    }

                    LogOutputter.PrintSuccess($"Logged in as '{ServerInfo.Username}' on remote host '{ServerInfo.IpAddress}'");


                }
            }
            catch (Exception ex)
            {
                LogOutputter.PrintFatal(ex.Message);
                return new ModuleReport(ExecutionResult.Failure, isCompleted: false);
            }

            return new ModuleReport(ExecutionResult.Success, isCompleted: true);
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
