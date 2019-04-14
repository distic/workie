namespace Workie.Core.Entities.Setup
{
    public class CountryEntity
    {
        /// <summary>
        /// Gets or sets the _id.
        /// </summary>
        public int _id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Abbreviation.
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the _defaultLanguageId.
        /// </summary>
        public int _defaultLanguageId { get; set; }
    }
}
