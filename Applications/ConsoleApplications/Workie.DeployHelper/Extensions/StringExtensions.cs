namespace Workie.DeployHelper.Extensions
{
    public static class StringExtensions
    {
        public static string Filename(this string str)
        {
            // Redmond format
            var indexOfEither = str.LastIndexOf('\\') + 1;

            if (indexOfEither != 0)
            {
                return str.Substring(indexOfEither, str.Length - indexOfEither);
            }

            // Canonical format
            indexOfEither = str.LastIndexOf('/') + 1;

            if (indexOfEither != 0)
            {
                return str.Substring(indexOfEither, str.Length - indexOfEither);
            }

            return string.Empty;
        }
    }
}
