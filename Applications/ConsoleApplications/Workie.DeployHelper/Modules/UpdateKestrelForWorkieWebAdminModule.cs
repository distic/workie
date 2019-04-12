using Workie.DeployHelper.Data;
using Workie.DeployHelper.Utilities;
using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Modules
{
    internal class UpdateKestrelForWorkieWebAdminModule : ModuleBase
    {
        /// <summary>
        /// Entry point of the routine.
        /// </summary>
        /// <returns></returns>
        internal ModuleReport Run()
        {
            var doWorkData = new DoWorkData
            {
                DeployMessage = Properties.Resources.ChooseRemoteHostToUpdateKestrelForWorkieWebAdmin,
                OnSshAuthenticateSuccess = new OnSshAuthenticateSuccess(OnSshAuthenticateSuccess),
                OnSshAuthenticateFailure = new OnSshAuthenticateFailure(OnSshAuthenticateFailure)
            };

            return DoWork(doWorkData);
        }

        public override void OnSshAuthenticateSuccess(SshClientEx remoteHost)
        {

        }

        public override void OnSshAuthenticateFailure()
        {

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
