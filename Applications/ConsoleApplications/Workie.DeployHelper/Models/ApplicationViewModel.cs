using System.Collections.Generic;

namespace Workie.DeployHelper.Models
{
    internal class ApplicationViewModel
    {
        public DeployWorkieWebAdminModuleViewModel DeployWorkieWebAdminModule { get; set; }

        public InstallOrUpdatePackagesModuleViewModel InstallOrUpdatePackagesModule { get; set; }

        public RemoteHostViewModel RemoteHost { get; set; }

        public SecurityViewModel Security { get; set; }

        public CommonViewModel Common { get; set; }

        public List<ServerInfoViewModel> ServerInfoList { get; set; }
    }
}
