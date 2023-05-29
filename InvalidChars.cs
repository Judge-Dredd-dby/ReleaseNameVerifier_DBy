using System.Linq;
using System.Text.RegularExpressions;

namespace ReleaseNameVerifier
{
    public static class InvalidChars
    {
        public static string Contains { get; private set; } = null;
        public static bool Check(string releaseName)
        {
            // Check for invalid chars
            string pattern = @"[^_\w\.-]|\.{2,}|(?i)[æøå]";

            Regex regexp = new Regex(pattern);
            Match match = regexp.Match(releaseName);

            if (match.Success)
            {
                switch (match.Value)
                {
                    case var spaces when new Regex(@"\s").IsMatch(spaces):

                        int spaceCount = releaseName.Count(c => c == ' ');

                        Contains = spaceCount > 1 ? $"{spaceCount} spaces" : "a space";
                        return false;

                    case var multiDot when new Regex(@"\.{2,}").IsMatch(multiDot):

                        int dotCount = match.Value.Length;
                        Contains = $"{dotCount} dots in a row";
                        return false;

                    default:
                        Contains = match.Value;
                        return false;
                }

            }
            return true;
        }
    }
}
