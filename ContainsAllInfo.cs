// Ignore Spelling: Codec

using ReleaseNameVerifier;
using System.Text.RegularExpressions;

namespace ReleaseHandle
{
    public static class ContainsAllInfo
    {

        public static bool CheckCodec(string releaseName)
        {
            string pattern = @"\bH\.264\b|\bx264\b|\bx265\b|\bH\.265\b";
            Regex regex = new Regex(pattern, RegexOptions.CultureInvariant);
            Match match = regex.Match(releaseName);

            return match.Success;
        }

        public static bool CheckType(string releaseName)
        {
            string pattern = ReleaseTypeHelper.GetRegexPattern();
            Regex regex = new Regex(pattern, RegexOptions.CultureInvariant);
            Match match = regex.Match(releaseName);

            return match.Success;
        }

        public static bool CheckResolution(string releaseName)
        {
            if (CheckType(releaseName))
            {
                string pattern = @"\b720p\b|\b1080p\b|\b2160p\b";
                Regex regex = new Regex(pattern, RegexOptions.CultureInvariant);
                Match match = regex.Match(releaseName);

                if (match.Success == false)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
