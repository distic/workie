using Renci.SshNet;
using Workie.DeployHelper.Models;
using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Delegates
{
    internal class ModuleDelegates
    {
        /// <summary>
        /// Resolves prerequisits for files.
        /// </summary>
        /// <param name="sftpClient"></param>
        internal delegate void OnResolvePrerequisites(SftpClient sftpClient);

        /// <summary>
        /// Event occurs when authentication to SSH succeeds.
        /// </summary>
        /// <param name="remoteHost">Used to send command(s) to the connected host.</param>
        internal delegate void OnSshAuthenticateSuccess(SshClientEx remoteHost);

        /// <summary>
        /// Event occurs when authentication to SSH fails.
        /// </summary>
        internal delegate void OnSshAuthenticateFailure();

        /// <summary>
        /// Event occurs when authentication to SFTP succeeds.
        /// </summary>
        internal delegate void OnSftpAuthenticateSuccess(SftpClient sftpClient);

        /// <summary>
        /// Event occurs when authentication to SFTP fails.
        /// </summary>
        internal delegate void OnSftpAuthenticateFailure();

        /// <summary>
        /// Event occurs when SFTP disconnects.
        /// </summary>
        internal delegate void OnSftpDisconnect();

        /// <summary>
        /// Event occurs when SFTP is done with the file upload. This event gets triggered per file upload.
        /// </summary>
        /// <param name="uploadFile"></param>
        internal delegate void OnSftpFileUploaded(SshClientEx remoteHost, UploadFileViewModel uploadFile);

        /// <summary>
        /// Event occurs right after a successful authentication to the SSH session.
        /// </summary>
        /// <param name="remoteHost"></param>
        internal delegate void OnRunPackageScripts(SshClientEx remoteHost);
    }
}
