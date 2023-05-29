using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReleaseNameVerifier
{

    public static class LanguagesHelper
    {
        public static readonly List<string> LanguagesOptions = GenerateSubtitleOptions();

        public static readonly string RegexPattern = GenerateRegexPattern();

        private static List<string> GenerateSubtitleOptions()
        {
            List<string> options = new List<string>
        {
            "DKsubs", "SWsubs", "NOsubs", "Fisubs", "DANiSH",
            "NORWEGiAN", "SWEDiSH", "FiNNiSH", "DK.ENG", "SW.ENG",
            "NO.ENG", "Fi.ENG", "DK.SW", "DK.NO", "DK.Fi", "SW.NO",
            "SW.Fi", "NO.Fi","NORDiC", "MULTi", "Retail", "Custom"
        };

            List<string> combinedOptions = new List<string>();

            foreach (string option in options)
            {
                combinedOptions.Add(option);

                if (option.Contains('.') && option.Contains(".ENG") == false)
                {
                    string[] parts = option.Split('.');
                    string reversedOption = string.Join(".", parts.Reverse());
                    combinedOptions.Add(reversedOption);
                }
            }

            return combinedOptions;
        }
        private static string GenerateRegexPattern()
        {
            List<string> patterns = LanguagesOptions.Select(option => $@"\b{Regex.Escape(option)}\b").ToList();
            return string.Join("|", patterns);
        }

    }


}
