using ReleaseNameVerifier;
using ReleaseNameVerifier.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace releaseNameVerifyer
{
    public partial class ReleaseNameVerifier : Form
    {
        public ReleaseNameVerifier()
        {
            InitializeComponent();
        }

        private string CheckForIllegalChars(string releaseName)
        {
            // Check for invalid chars
            string pattern = @"[^+_\w\.-]|\.{2,}|(?i)\bLiMiTED\b|(?i)[æøå]";

            Regex regexp = new Regex(pattern);
            Match match = regexp.Match(releaseName);

            // Check if there is a match.
            if (match.Success)
            {
                // Switch through the match.
                return match.Value switch
                {
                    // If the match contains one or more spaces.
                    var spaces when new Regex(@"\s").IsMatch(spaces) => "The release contains one or more spaces.",
                    // If the match contains limited.
                    var limited when new Regex(@"\bLiMiTED\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant).IsMatch(limited) => "The release contains LiMiTED, this is an irrelevant information and should be removed.",
                    // Else if the match contains, an illegal character.
                    _ => $"The release contains { match.Value } which is not allowed in a torrent name",
                };
            }
            return string.Empty;
        }

        private string CheckProperCasing(string releaseName)
        {
            // Check the release name for proper casing.

            // List of proper naming to check.
            var namingCheckList = new List<string>() {"Retail", "Custom", "DKsubs", "DANiSH", "NORDiC", "MULTi", "DK.ENG", "DC",
                "REMASTERED", "EXTENDED", "UNRATED", "REMUX", "BluRay", "HDDVD", "WEB-DL", "WEBRip", "HDTV", "PAL", "NTSC", "DVDR",
                "DVDRip", "AVC", "DTS-HD.MA", "VC-1", "TrueHD", "TrueHD.Atmos", "HDRip", "XviD", "H.264", "H.265", "x264", "x265" };

            // Create a pattern string, from the check list.
            StringBuilder stringBuilder = new StringBuilder();

            // Loop through the list items and create the pattern string.
            foreach (var item in namingCheckList)
            {
                // Here we create a regex pattern string by append a leading and trailing \b and add a | to separate the strings
                // also if a "." exists, we replace it with \. which is the escape char in a regex pattern.
                stringBuilder.Append(@"\b").Append(Regex.Replace(item, @"\.", @"\.")).Append(@"\b").Append("|");
            }
            Console.WriteLine("StringBuilder string = " + stringBuilder.ToString().TrimEnd('|'));
            // Create the regex with ignoreCase and CultureInvarient, using the pattern list where we strip the trailing "|".
            Regex regex = new Regex(stringBuilder.ToString().TrimEnd('|'), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

            // Get a collection of matches, that we can search through.
            MatchCollection matchCollection = regex.Matches(releaseName);

            // Loop through the matches and compare them to the naming check list.
            for (int i = 0; i < matchCollection.Count; i++)
            {
                int index = namingCheckList.FindIndex(result => result.StartsWith(matchCollection[i].Value, StringComparison.InvariantCultureIgnoreCase));

                // Check if the match is different from the proper casing list.
                if (namingCheckList[index] != matchCollection[i].Value)
                {
                    // The result was different, so we have an invalid casing.
                    string contains = $"The release name contains { matchCollection[i].Value } but the proper naming is { namingCheckList[index] }";

                    return contains;
                }
            }
            return string.Empty;
        }

/*
        private string ProperNaming(string release)
        {
            if (Regex.IsMatch(release, "\bBluRay\b"))
            {

            }
        }
*/
        private void TxtRelease_DragEnter(object sender, DragEventArgs e)
        {
            // Handle the drag and drop enter (when user drags an item over the textbox).
            DragDropEffects effects = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (Directory.Exists(path))
                    effects = DragDropEffects.Copy;
            }

            e.Effect = effects;
        }

        private void TxtRelease_DragDrop(object sender, DragEventArgs e)
        {
            // When the user drops the item on the textbox.
            // Get the release name.
            string releaseName = Path.GetFileName(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);

            // Set the textbox text, to the release name.
            txtRelease.Text = releaseName;

            // Clear the result text (if any).
            lblResult.Text = string.Empty;

            // Clear the image (if any).
            imgValidated.Image = null;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // Handle the browse button click.

            // Create a open folder browse dialog.
            var source = new FolderBrowserDialog()
            {
                // Don't show create a new folder button.
                ShowNewFolderButton = false,

                // Set start folder to My computer.
                RootFolder = Environment.SpecialFolder.MyComputer
            };

            // Show the browse folder window.
            DialogResult result = source.ShowDialog();

            // If the user selected a folder.
            if (result == DialogResult.OK)
            {
                // Get the name of the release.
                string releaseName = Path.GetFileName(source.SelectedPath);

                // Update the textbox with the release name.
                txtRelease.Text = releaseName;

                // Clear the result text (if any).
                lblResult.Text = string.Empty;

                // Clear the image (if any).
                imgValidated.Image = null;
            }
            // Dispose the browse window.
            source.Dispose();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            // Check if the textbox contains text.
            if (string.IsNullOrEmpty(txtRelease.Text) == false)
            {
                // Get the release name from the textbox.
                string releaseName = txtRelease.Text;

                // First we check for illegal chars.
                if (string.IsNullOrEmpty(CheckForIllegalChars(releaseName)) == false)
                {
                    // If there was an illegal character, we update the result text.
                    lblResult.Text = CheckForIllegalChars(releaseName);

                    // Set the validate image to no (X).
                    imgValidated.Image = Resources.imgno;
                }

                // If there wasn't any illegal chars, we check for proper casing.
                else if (string.IsNullOrEmpty(CheckProperCasing(releaseName)) == false)
                {
                    // Some thing wasn't proper cased.

                    // Update the result text.
                    lblResult.Text = CheckProperCasing(releaseName);

                    // Set the validate image to no (X).
                    imgValidated.Image = Resources.imgno;
                }

                // If we didn't get any hits.
                else
                {
                    // Update the result text.
                    lblResult.Text = "Release name is validated OK";

                    // Set the validate image to yes (V).
                    imgValidated.Image = Resources.imgyes;
                }
            }

            // If the textbox is empty.
            else
            {
                // Update the result text.
                lblResult.Text = "No release loaded!";
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Clear result text.
            lblResult.Text = string.Empty;

            // Clear textbox text.
            txtRelease.Text = string.Empty;

            // Clear validate image.
            imgValidated.Image = null;
        }

        private void ImgInfo_Click(object sender, EventArgs e)
        {
            var infoWindow = new InfoForm();
            infoWindow.ShowDialog();
        }
    }
}