using Workie.DeployHelper.Models.ModulesConfig;

namespace Workie.DeployHelper.Modules
{
    internal class ModulesConfigViewModel
    {
        internal DeployWorkieWebAdminModuleViewModel DeployWorkieWebAdminModule { get; set; }

        internal InstallOrUpdatePackagesModuleViewModel InstallOrUpdatePackagesModule { get; set; }
    }
}
