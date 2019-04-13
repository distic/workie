using Renci.SshNet;
using System;
using Utilities.Linux.Shell;
using Utilities.Linux.Shell.Security;

namespace Workie.DeployHelper.Utilities
{
    public class SshClientEx : SshClient
    {
        #region --- Initializer ---

        public SshClientEx(string host, string username, string password) : base(host, username, password)
        {
        }

        #endregion

        #region --- General Methods ---

        private void RunCommand(SshCommand command, bool output)
        {
            if (output)
            {
                Console.Write(command.Execute());
            }
            else
            {
                command.Execute();
            }
        }

        internal void SystemCtlStart(string fileName, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.SystemCtlStart(fileName, sudo));

            RunCommand(cmd, output);
        }

        internal void SystemCtlEnable(string fileName, bool sudo, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.SystemCtlEnable(fileName, sudo));

            RunCommand(cmd, output);
        }

        internal void SystemCtlRestart(string fileName, bool sudo, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.SystemCtlRestart(fileName, sudo));

            RunCommand(cmd, output);
        }

        internal void CreateDirectory(string directoryName, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.CreateDirectory(directoryName, sudo));

            RunCommand(cmd, output);
        }

        internal void Delete(string fileName, bool recursive = false, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.Delete(fileName, recursive, sudo));

            RunCommand(cmd, output);
        }

        internal void ChangeGroup(string fileName, string groupName, bool recursive = false, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.ChangeGroup(fileName, groupName, recursive, sudo));

            RunCommand(cmd, output);
        }

        internal void ChangeAttributes(string fileName,
            bool recursive = false,
            FileAttributes user_permission = null,
            FileAttributes group_permission = null,
            FileAttributes other_permission = null,
            bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.ChangeAttributes(fileName, recursive, user_permission, group_permission, other_permission, sudo));

            RunCommand(cmd, output);
        }

        internal void AddGroup(string groupName, bool sudo = false, bool output = false)
        {
            var cmd = RunCommand(CommandHelper.AddGroup(groupName));

            RunCommand(cmd, output);
        }

        internal void AddUserToGroup(string userName, string groupName, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.AddUserToGroup(userName, groupName, sudo));

            RunCommand(cmd, output);
        }

        internal void ChangeOwner(string fileName, string ownerName, bool recursive = false, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.ChangeOwner(fileName, ownerName, recursive, sudo));

            RunCommand(cmd, output);
        }

        internal void Move(string srcFilename, string dstFilename, bool recursive = false, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.Move(srcFilename, dstFilename, recursive, sudo));

            RunCommand(cmd, output);
        }

        internal void Unzip(string zipFilename, string dst = "", bool forceOverwrite = false, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.Unzip(zipFilename, dst, forceOverwrite, sudo));

            RunCommand(cmd, output);
        }

        internal void ResetPermission(string filename, bool recursive = false, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.ResetPermission(filename, recursive, sudo));

            RunCommand(cmd, output);
        }

        internal void Reboot(int seconds, bool sudo = false, bool output = false)
        {
            var cmd = CreateCommand(CommandHelper.Reboot(seconds, sudo));

            RunCommand(cmd, output);
        }

        internal void RunCommandWithOutput(string command)
        {
            var cmd = CreateCommand(command);

            RunCommand(cmd, output: true);
        }

        #endregion
    }
}