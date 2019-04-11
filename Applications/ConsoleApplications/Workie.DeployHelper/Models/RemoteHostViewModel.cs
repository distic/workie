namespace Workie.DeployHelper.Models
{
    internal class RemoteHostViewModel
    {
        public string WorkieWebAdminDirectory { get; set; }

        public string HttpdConfDirectory { get; set; }

        public string SystemdSystemDirectory { get; set; }

        public string DefaultZipFilename { get; set; }
    }
}
