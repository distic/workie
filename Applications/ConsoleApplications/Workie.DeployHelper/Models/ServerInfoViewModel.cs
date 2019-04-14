namespace Workie.DeployHelper.Models
{
    internal class ServerInfoViewModel
    {
        public string FriendlyName { get; set; }

        public string IpAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Gets the convenient name of the server.
        /// </summary>
        public string ListName
        {
            get
            {
                if (string.IsNullOrEmpty(FriendlyName))
                {
                    return IpAddress;
                }

                return $"{FriendlyName} ({IpAddress})";
            }
        }
    }
}
