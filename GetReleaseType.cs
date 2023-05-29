using ReleaseNameVerifier;
using System.Text.RegularExpressions;

namespace ReleaseHandle
{
    public static class GetReleaseType
    {
        /// <summary>
        /// Get the release type: Series, SerieSet or Movie.
        /// </summary>
        /// <param name="releaseName"></param>
        /// <returns>
        /// 1 if it's a Series, 2 if SerieSet, 3 if Move and 0 if nothing matched.
        /// </returns>
        public static int Get(string releaseName)
        {
            // Get release type.
            string pattern = @"(?<Series>S\d{2,}E\d{2,}-\d{2,}|S\d{2,}E\d{2,})|(?<SerieSet>" +
                $@"S\d{{2,}}-(?>\d{{2,}})|S\d{{2,}})|(?<Movie>\.\d{{4}}\.{LanguagesHelper.RegexPattern}" ;
            Regex regex = new Regex(pattern, RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
            Match match = regex.Match(releaseName);

            if (match.Success)
            {
                if (match.Groups["Series"].Success)
                {
                    // Matched first option...
                    // It's a series.
                    return 1;
                }
                else if (match.Groups["SerieSet"].Success)
                {
                    // Matched second option...
                    // It's a seriesSet.
                    return 2;
                }
                else if (match.Groups["Movie"].Success)
                {
                    // Matched third option...
                    // It's a movie.
                    return 3;
                }
            }
            return 0;
        }
    }
}
