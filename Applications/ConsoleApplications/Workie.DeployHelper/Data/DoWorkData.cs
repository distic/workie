using static Workie.DeployHelper.Delegates.ModuleDelegates;

namespace Workie.DeployHelper.Data
{
    internal struct DoWorkData
    {
        public string DeployMessage { get; set; }

        public OnSshAuthenticateSuccess OnSshAuthenticateSuccess { get; set; }

        public OnSshAuthenticateFailure OnSshAuthenticateFailure { get; set; }
    }
}
