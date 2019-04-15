using Renci.SshNet;
using System.Collections.Generic;
using Workie.DeployHelper.Data;
using Workie.DeployHelper.Models;
using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Interfaces
{
    internal interface IModule
    {
        /// <summary>
        /// Runs the routine.
        /// </summary>
        /// <returns>The reported result of the operation.</returns>
        ModuleReport DoWork(DoWorkData doWorkData);

        /// <summary>
        /// Checks for any occurring conflicts.
        /// </summary>
        /// <returns>The reported result of the operation.</returns>
        ConflictReport GetConflictsReport();

        /// <summary>
        /// Event occurs when the authentication to the remote host succeeds.
        /// </summary>
        void OnSshAuthenticateSuccess(SshClientEx remoteHost);

        /// <summary>
        /// Event occurs when authentication to the remote host fails.
        /// </summary>
        void OnSshAuthenticateFailure();

        /// <summary>
        /// Event occurs when scripts need to be executed.
        /// </summary>
        /// <param name="remoteHost"></param>
        void OnRunPackageScripts(SshClientEx remoteHost);

        /// <summary>
        /// Event occurs when ModuleBase requests an upload list specific to the module.
        /// </summary>
        /// <returns>Upload list.</returns>
        List<UploadFileViewModel> OnRequestingUploadFileList();

        /// <summary>
        /// Gets the absolute path of the host source file name.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        string OnRequestingRoutedFilename(string filename);
    }
}
