using Workie.DeployHelper.Data;
using Workie.DeployHelper.Utilities;
using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Modules
{
    internal class UpdateKestrelForWorkieWebAdminModule : ModuleBase
    {
        #region --- Requests ---

        public override string OnRequestingRoutedFilename(string filename)
        {
            return System.IO.Path.Combine(Globals.GetModuleDependenciesDirectory, GetType().Name, filename);
        }

        #endregion

        #region --- Properties ---

        public DoWorkData DoWorkData { get; set; }

        #endregion

        /// <summary>
        /// Entry point of the routine.
        /// </summary>
        /// <returns></returns>
        internal ModuleReport Run()
        {
            DoWorkData = new DoWorkData
            {
                DeployMessage = Properties.Resources.ChooseRemoteHostToUpdateKestrelForWorkieWebAdmin,
                OnRunPackageScripts = new OnRunPackageScripts(OnRunPackageScripts),
                OnSftpDisconnect = new OnSftpDisconnect(OnSftpDisconnect),
                OnSftpFileUploaded = new OnSftpFileUploaded(OnSftpFileUploaded),
                OnSshAuthenticateFailure = new OnSshAuthenticateFailure(OnSshAuthenticateFailure),
                OnSshAuthenticateSuccess = new OnSshAuthenticateSuccess(OnSshAuthenticateSuccess),
                OnSftpAuthenticateFailure = new OnSftpAuthenticateFailure(OnSftpAuthenticateFailure),
                OnSftpAuthenticateSuccess = new OnSftpAuthenticateSuccess(OnSftpAuthenticateSuccess),
                OnRequestingRoutedFilename = new OnRequestingRoutedFilename(OnRequestingRoutedFilename)
            };

            return DoWork(DoWorkData);
        }

        public override void OnRunPackageScripts(SshClientEx remoteHost)
        {

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
