using System.Collections.Generic;

namespace Workie.DeployHelper.Models
{
    internal class DeployWorkieWebAdminModuleViewModel
    {
        public string Source { get; set; }

        public string RemotehostHttpdFilename { get; set; }

        public string RemotehostKestrelFilename { get; set; }

        public string RemotehostWorkieWebAdminDirectory { get; set; }

        public PublishViewModel Publish { get; set; }

        public List<UploadFileViewModel> UploadFileList { get; set; }
    }
}
