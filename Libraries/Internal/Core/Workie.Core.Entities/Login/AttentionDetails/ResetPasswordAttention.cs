namespace Workie.Core.Entities.Login.AttentionDetails
{
    public class ResetPasswordAttention
    {
        public string IPAddress { get; set; }

        public double Time { get; set; }

        public int _osPlatformId { get; set; }

        public int _webBrowswerPlatformId { get; set; }

        public string Location { get; set; }
    }
}
