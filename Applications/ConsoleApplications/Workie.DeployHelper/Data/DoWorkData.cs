using System.Collections.Generic;
using Workie.DeployHelper.Models;
using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Data
{
    internal struct DoWorkData
    {
        public string DeployMessage { get; set; }

        public List<UploadFileViewModel> UploadFileList { get; set; }

        public OnSshAuthenticateSuccess OnSshAuthenticateSuccess { get; set; }

        public OnSshAuthenticateFailure OnSshAuthenticateFailure { get; set; }

        public OnSftpDisconnect OnSftpDisconnect { get; set; }

        public OnSftpFileUploaded OnSftpFileUploaded { get; set; }

        public OnSftpAuthenticateSuccess OnSftpAuthenticateSuccess { get; set; }

        public OnSftpAuthenticateFailure OnSftpAuthenticateFailure { get; set; }

    }
}
