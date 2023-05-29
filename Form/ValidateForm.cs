using ReleaseNameVerifier.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ReleaseHandle;
using System.Media;

namespace ReleaseNameVerifier
{
    public partial class ReleaseNameVerifier : Form
    {
        public ReleaseNameVerifier()
        {
            InitializeComponent();
        }
       
        // Makes the background gradient.
        // Code found here: https://www.daveoncsharp.com/2009/09/how-to-paint-a-gradient-background-for-your-forms/
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle,
                                                                       ColorTranslator.FromHtml("#181818"),
                                                                       ColorTranslator.FromHtml("#6b6b6b"),
                                                                       60F);
            e.Graphics.FillRectangle(brush, ClientRectangle);
        }
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
            if (string.IsNullOrEmpty(txtRelease.Text) == true)
            {
                // Update the result text.
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "No release loaded!";
                SystemSounds.Beep.Play();

                //PlaySoundFromBinary.Play(TadaSoundInBinaryFormat.Tada());
                return;
            }
            // Get the release name from the textbox.
            string releaseName = txtRelease.Text;

            // First we check for illegal chars.
            if (InvalidChars.Check(releaseName) == false)
            {
                // If there was an illegal character, we update the result text.
                lblResult.ForeColor = Color.Red;
                lblResult.Text = $@"Failed validation, it contains: {InvalidChars.Contains}{Environment.NewLine}which is not allowed in a release name!";

                // Set the validate image to no (X).
                imgValidated.Image = Resources.imgno;
                SystemSounds.Beep.Play();
                return;
            }

            // If there wasn't any illegal chars, we check for proper casing.
            if (ProperCasing.Check(releaseName) == false)
            {
                // Some thing wasn't proper cased.

                lblResult.ForeColor = Color.Red;
                // Update the result text.
                lblResult.Text = $@"Failed validation, it contains {ProperCasing.Contains}{Environment.NewLine}but the proper naming is: {ProperCasing.Correct}";

                // Set the validate image to no (X).
                imgValidated.Image = Resources.imgno;
                SystemSounds.Beep.Play();
                return;
            }

            // If we didn't get any hits.
            lblResult.ForeColor = Color.Green;
            // Update the result text.
            lblResult.Text = "Release name is validated OK";

            // Set the validate image to yes (V).
            imgValidated.Image = Resources.imgyes;
            PlaySoundFromBinary.Play(TadaSoundInBinaryFormat.Tada());


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