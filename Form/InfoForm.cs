using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReleaseNameVerifier
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
            RtbInfo.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1030{\fonttbl{\f0\fswiss\fprq2\fcharset0 Calibri;}{\f1\fnil\fcharset0 Calibri;}}
{\colortbl ;\red255\green0\blue0;}
{\*\generator Riched20 10.0.17763}\viewkind4\uc1 
\pard\widctlpar\sa160\sl252\slmult1\b\f0\fs28\lang1033 How does release name verifier work?\par
\fs22 There is three ways you can add your release.\par

\pard 
{\pntext\f0 1.\tab}{\*\pn\pnlvlbody\pnf0\pnindent0\pnstart1\pndec{\pntxta.}}
\widctlpar\fi-360\li720\sa160\sl252\slmult1\b0\i\fs24 You can drag and drop your release into the input.\par
{\pntext\f0 2.\tab}You can use the browse button.\par
{\pntext\f0 3.\tab}You can copy paste the release name into the field.\par

\pard\widctlpar\sa160\sl252\slmult1\i0\fs28 What does the release name verifier check?\par
\i\fs24 It checks for characters other than \ldblquote a to z\rdblquote  (upper and lower), \ldblquote _\rdblquote  (underscore), \ldblquote .\rdblquote  (dot) and \ldblquote +\rdblquote  (plus).\par
\b\i0 It also checks if:\par
\b0\i Retail, Custom, DKsubs, DANiSH, NORDiC, MULTi, DK.ENG, DC, REMASTERED, EXTENDED, UNRATED, REMUX, BluRay, HDDVD, WEB-DL, WEBRip, HDTV, PAL, NTSC, DVDR, DVDRip, AVC, DTS-HD.MA, VC-1, TrueHD, TrueHD.Atmos, HDRip, XviD, H.264, x264 and x265\i0  \b is proper cased.\b0\par
\par
\b It does not check if the release is spelled correct, or if it\rquote s missing information\rquote s or characters, this means that releases like these will be verified as ok.\par
\b0\ldblquote\cf1\b My.ReleaseName2020.Dksubs.1080p.BluRay.x264-SuperRelease\cf0\b0\rdblquote\line Here we clearly is missing a dot after the title name.\par
\ldblquote\cf1\b My.Release.Name.2020.NORDiC.1090p.BluRay.H.264-NewRelease\cf0\b0\rdblquote\line Here we have a misspelling in 1090 which should had been 1080.\par
\ldblquote\cf1\b My.ReleaseName.2020DKSUBS.1080p.WEB-DL.x265-CoolRelease\cf0\b0\rdblquote\line Here DKSUBS is in in proper casing, but due to the missing dot after 2020, the verifier can\rquote t pick it up as an error, and will therefor verifies it as OK.  \par

\pard\sa200\sl276\slmult1\f1\fs22\lang6\par
}";
            RtbInfo.SelectAll();
            RtbInfo.SelectionIndent += 20;
            RtbInfo.DeselectAll();
        }

        private void BtnInfoOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
