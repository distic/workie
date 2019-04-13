using System.Collections.Generic;

namespace Workie.DeployHelper.Models
{
    internal class UploadFileViewModel
    {
        public string LocalhostFilename { get; set; }

        public string RemotehostFilename { get; set; }

        public bool IsRequired { get; set; }

        public bool IsOverwrite { get; set; }

        public List<string> Scripts { get; set; }
    }
}
