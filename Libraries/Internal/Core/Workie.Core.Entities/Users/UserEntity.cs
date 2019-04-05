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
        /// Gets or sets the IsFirstLogin value.
        /// </summary>
        public bool IsFirstLogin { get; set; }
    }
}
