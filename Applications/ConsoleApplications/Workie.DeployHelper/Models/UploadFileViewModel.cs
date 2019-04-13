namespace Workie.DeployHelper.Models
{
    internal class UploadFileViewModel
    {
        public string LocalhostFilename { get; set; }

        public string RemotehostFilename { get; set; }

        public bool IsRequired { get; set; }

        public bool IsOverwrite { get; set; }

        public string RequestingModule { get; set; }
    }
}
