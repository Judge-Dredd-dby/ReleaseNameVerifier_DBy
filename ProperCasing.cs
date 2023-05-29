using ReleaseNameVerifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReleaseHandle
{
    public static class ProperCasing
    {
        
        public static string Contains { get; private set; } = string.Empty;
        public static string Correct { get; private set; } = string.Empty;

        //public ProperCasing(string releaseName)
        //{
        //    Check(releaseName);
        //}

        public static bool Check(string releaseName)
        {
            // Check the release name for proper casing.

            // List of proper cased names
            List<string> properCaseList = new List<string>() {
                "DC", "HYBRiD", "REMASTERED", "EXTENDED", "UNRATED", "REMUX", "BluRay", "HDDVD", "WEB-DL",
                "WEBRip", "HDTV", "PAL", "NTSC", "DVDR","UHD-BluRay","DV.HDR", "HDR10", "HDR", "DVDRip", "AVC", "DTS-HD.MA", "VC-1", "TrueHD", "TrueHD.Atmos",
                "HDRip", "XviD", "DivX", "H.264", "x264","x265", "H.265", "HEVC", "UHDTV" , "DV" , "AAC" , "DD" , "DDP" , "Atmos" , "DTS" , "REPACK"
            };

                properCaseList.AddRange(LanguagesHelper.LanguagesOptions);
                List<string> patterns = properCaseList.Select(option => $@"\b{Regex.Escape(option)}\b").ToList();
                string regexPattern = string.Join("|", patterns);
            

            // Now we "convert" the list to am use full string pattern.
            StringBuilder stringBuilder = new StringBuilder();

            // Loop through the list items and create the pattern string.
            foreach (var item in properCaseList)
            {
               // Here we create a regex pattern string by append a leading and trailing \b and add a | to separate the strings
               // also if a "." exists, we replace it with \. which is the escape char in a regex pattern.
                stringBuilder.Append(@"\b").Append(Regex.Replace(item, @"\.", @"\.")).Append(@"\b").Append("|");
            }
            //Console.WriteLine("RegexPattern= " + regexPattern);
            //Console.WriteLine($"Language list = {string.Join("|",LanguagesHelper.LanguagesOptions)}");
            //Console.WriteLine($"Language list regex = {LanguagesHelper.RegexPattern}");
            // Create the regex with ignoreCase and CultureInvarient, using the pattern list where we strip the trailing "|".
            Regex regex = new Regex(stringBuilder.ToString().TrimEnd('|'), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            
            // Get a collection of matches, that we can search through.
            MatchCollection matchCollection = regex.Matches(releaseName);

            // Loop through the matches and compare them to the Proper casing list
            for (int i = 0; i < matchCollection.Count; i++)
            {
                int index = properCaseList.FindIndex(result => result.StartsWith(matchCollection[i].Value, StringComparison.InvariantCultureIgnoreCase));
                
                // Check if the match is different from the proper casing list.
                if (properCaseList[index] != matchCollection[i].Value)
                {
                    // The result was different, so we have an invalid casing.
                    Contains = matchCollection[i].Value;
                    Correct = properCaseList[index];
                    return false;
                    
                }
            }
            return true;
            
        }
    }
}
