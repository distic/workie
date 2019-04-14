using Workie.Core.Entities.Login.AttentionDetails;

namespace Workie.Core.Entities.Login
{
    public class Attention
    {
        public bool IsFirstLogin { get; set; }
        public bool VerifyEmail { get; set; }

        public ResetPasswordAttention ResetPassword { get; set; }

        public bool TermsAndConditionId { get; set; }

        public ChangePasswordAttention ChangePassword { get; set; }
    }
}
