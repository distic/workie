using System.Collections.Generic;

namespace Workie.DeployHelper.Models
{
    internal class DeployWorkieWebAdminModuleViewModel
    {
        public string Source { get; set; }

        public PublishViewModel Publish { get; set; }

        public List<UploadFileViewModel> UploadFileList { get; set; }
    }
}
