using Workie.Core.Entities.Login;

namespace Workie.Core.Entities.Users
{
    public class UserEntity
    {
        /// <summary>
        /// Gets or sets the _id value.
        /// </summary>
        public string _id { get; set; }

        /// <summary>
        /// Gets or sets the FirstName value.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName value.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress value.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the Password value.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets the _languageId
        /// </summary>
        public int _languageId { get; set; }

        /// <summary>
        /// Gets or sets the _termsAndConditionId .
        /// </summary>
        public string _termsAndConditionId { get; set; }

        /// <summary>
        /// Gets or sets the _countryId.
        /// </summary>
        public int _countryId { get; set; }

        /// <summary>
        /// Gets or sets the _companyId.
        /// </summary>
        public int _companyId { get; set; }

        /// <summary>
        /// Gets or sets the Attention.
        /// </summary>
        public Attention Attention { get; set; }
    }
}
