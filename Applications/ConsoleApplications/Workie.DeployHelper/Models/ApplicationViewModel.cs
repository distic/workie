using System.Collections.Generic;
using Workie.DeployHelper.Modules;

namespace Workie.DeployHelper.Models
{
    internal class ApplicationViewModel
    {
        public bool UseSsl { get; set; }

        public ModulesConfigViewModel ModulesConfig { get; set; }

        public List<ServerInfoViewModel> ServerInfoList { get; set; }
    }
}
