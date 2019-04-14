namespace Workie.Core.Entities.Legal
{
    public class TermsAndConditionsEntity
    {
        /// <summary>
        /// Gets or sets the _id.
        /// </summary>
        public string _id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        public double Version { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the _languageId.
        /// </summary>
        public int _languageId { get; set; }
    }
}
