using Workie.DeployHelper.Data;
using static Workie.DeployHelper.Delegates.ModuleDelegates;
using Workie.DeployHelper.Utilities;

namespace Workie.DeployHelper.Modules
{
    internal class DeployWorkieWebAdminModule : ModuleBase
    {
        /// <summary>
        /// Entry point of the routine.
        /// </summary>
        /// <returns></returns>
        internal ModuleReport Run()
        {
            var doWorkData = new DoWorkData
            {
                DeployMessage = Properties.Resources.ChooseRemoteHostToDeployWorkieWebAdmin,
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
