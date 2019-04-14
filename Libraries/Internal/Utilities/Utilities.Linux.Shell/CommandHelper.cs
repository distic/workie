using System;
using Utilities.Linux.Shell.Security;

namespace Utilities.Linux.Shell
{
    public class CommandHelper
    {
        #region --- File/Folder Operations ---

        /// <summary>
        /// Moves a resource to a different location.
        /// </summary>
        /// <param name="srcFilename"></param>
        /// <param name="dstFilename"></param>
        /// <param name="recursive"></param>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string Move(string srcFilename, string dstFilename, bool recursive = false, bool sudo = false)
        {
            var command = recursive ?
                string.Format("mv {0} {1} -R", srcFilename, dstFilename) :
                string.Format("mv {0} {1}", srcFilename, dstFilename);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Removes a file.
        /// </summary>
        /// <param name="directoryName"></param>
        /// <param name="recursive"></param>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string Delete(string fileName, bool recursive = false, bool sudo = false)
        {
            var command = recursive ?
                string.Format("rm -r {0}", fileName) :
                string.Format("rm {0}", fileName);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Add a group.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static string AddGroup(string groupName, bool sudo = false)
        {
            var command = string.Format("groupadd {0}", groupName);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Adds a user to a group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="groupName"></param>
        /// <param name="sudo"></param>
        public static string AddUserToGroup(string userName, string groupName, bool sudo = false)
        {
            var command = string.Format("gpasswd -a {0} {1}", userName, groupName);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Creates a directory.
        /// </summary>
        /// <param name="directoryName"></param>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string CreateDirectory(string directoryName, bool sudo = false)
        {
            var command = string.Format("mkdir {0}", directoryName);

            return sudo ?
                "sudo " + command :
                command;
        }

        #endregion

        #region --- Permission Operations ---

        /// <summary>
        /// Changes the group of a file or directory.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="groupName"></param>
        /// <param name="recursive"></param>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string ChangeGroup(string fileName, string groupName, bool recursive = false, bool sudo = false)
        {
            var command = recursive ?
                string.Format("chgrp {0} {1} -R", groupName, fileName) :
                string.Format("chgrp {0} {1}", groupName, fileName);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Sets the directory or file permissions to 000
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="recursive"></param>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string ResetPermission(string filename, bool recursive = false, bool sudo = false)
        {
            var command = recursive ?
                string.Format("chmod 000 {0} -R", filename) :
                string.Format("chmod 000 {0}", filename);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Changes the attributes of a file or directory by using CHMOD.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="recursive"></param>
        /// <param name="user_permission"></param>
        /// <param name="group_permission"></param>
        /// <param name="other_permission"></param>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string ChangeAttributes(string fileName,
            bool recursive = false,
            FileAttributes user_permission = null,
            FileAttributes group_permission = null,
            FileAttributes other_permission = null,
            bool sudo = false)
        {
            var user_permission_modified = false;
            var group_permission_modified = false;
            var other_permission_modified = false;

            var command = "chmod ";

            //
            // USER
            //

            if (user_permission != null)
            {
                if (user_permission.HasAnyTrue)
                {
                    command += "u+" + user_permission.AttributeString + ",";
                    user_permission_modified = true;
                }
            }

            if (!user_permission_modified)
            {
                command += "u-rwx,";
            }

            //
            // GROUP
            //

            if (group_permission != null)
            {
                if (group_permission.HasAnyTrue)
                {
                    command += "g+" + group_permission.AttributeString + ",";
                    group_permission_modified = true;
                }
            }

            if (!group_permission_modified)
            {
                command += "g-rwx,";
            }

            //
            // OTHER
            //

            if (other_permission != null)
            {
                if (other_permission.HasAnyTrue)
                {
                    command += "o+" + other_permission.AttributeString;
                    other_permission_modified = true;
                }
            }

            if (!other_permission_modified)
            {
                command += "o-rwx";
            }

            // Add the file name..
            command += " " + fileName;

            // Add '-r' if recursive..
            if (recursive)
            {
                command += " -R";
            }

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Changes the owner of a file or directory.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ownerName"></param>
        /// <param name="recursive"></param>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string ChangeOwner(string fileName, string ownerName, bool recursive = false, bool sudo = false)
        {
            var command = recursive ?
                string.Format("chown {0} {1} -R", ownerName, fileName) :
                string.Format("chown {0} {1}", ownerName, fileName);

            return sudo ?
                "sudo " + command :
                command;
        }

        #endregion

        #region --- File Compression/Decompression ---

        /// <summary>
        /// Extracts the content inside the compressed file.
        /// </summary>
        /// <param name="zipFilename"></param>
        /// <param name="dst"></param>
        /// <param name="forceOverwrite"></param>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string Unzip(string zipFilename, string dst = "", bool forceOverwrite = false, bool sudo = false)
        {
            var command = "unzip";

            if (forceOverwrite)
            {
                command += " -o";
            }

            command += " " + zipFilename;

            if (!string.IsNullOrEmpty(dst))
            {
                command += " -d " + dst;
            }

            return sudo ?
                "sudo " + command :
                command;
        }

        #endregion

        #region --- System Operations ---

        /// <summary>
        /// Starts a service.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sudo"></param>
        /// <returns></returns>
        public static string SystemCtlStart(string fileName, bool sudo)
        {
            var command = string.Format("systemctl start {0}", fileName);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Restarts a service.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sudo"></param>
        /// <returns></returns>
        public static string SystemCtlRestart(string fileName, bool sudo)
        {
            var command = string.Format("systemctl restart {0}", fileName);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Enables a service for startup.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sudo"></param>
        /// <returns></returns>
        public static string SystemCtlEnable(string fileName, bool sudo)
        {
            var command = string.Format("systemctl enable {0}", fileName);

            return sudo ?
                "sudo " + command :
                command;
        }

        /// <summary>
        /// Restarts the remote computer.
        /// </summary>
        /// <param name="sudo"></param>
        /// <returns> The generated command. </returns>
        public static string Reboot(int seconds, bool sudo = false)
        {
            var command = "reboot";

            if (seconds > 0)
            {
                command = $"sleep {seconds} ; {command}";
            }

            return sudo ?
                "sudo " + command :
                command;
        }

        #endregion
    }
}
