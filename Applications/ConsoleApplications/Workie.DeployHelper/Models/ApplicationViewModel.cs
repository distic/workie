using System.Collections.Generic;

namespace Workie.DeployHelper.Models
{
    internal class ApplicationViewModel
    {
        public RemoteHostViewModel RemoteHost { get; set; }

        public SecurityViewModel Security { get; set; }

        public CommonViewModel Common { get; set; }

        public List<UploadFileViewModel> ModuleDependencyList { get; set; }

        public List<ServerInfoViewModel> ServerInfoList { get; set; }
    }
}
