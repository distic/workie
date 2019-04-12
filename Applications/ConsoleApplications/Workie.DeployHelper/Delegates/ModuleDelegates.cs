using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Delegates
{
    internal class ModuleDelegates
    {
        /// <summary>
        /// Event occurs when authentication succeeds.
        /// </summary>
        /// <param name="remoteHost">Used to send command(s) to the connected host.</param>
        internal delegate void OnSshAuthenticateSuccess(SshClientEx remoteHost);

        /// <summary>
        /// Event occurs when authentication fails.
        /// </summary>
        internal delegate void OnSshAuthenticateFailure();
    }
}
