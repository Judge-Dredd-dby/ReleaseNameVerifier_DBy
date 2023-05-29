using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
{\colortbl ;\red255\green255\blue255;\red255\green0\blue0;\red112\green173\blue71;}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\widctlpar\sa160\sl252\slmult1\cf1\b\f0\fs28\lang1033 Hvordan fungere \par
How does release name verifier work?\par
\fs22 There is three ways you can add your release.\par

\pard 
{\pntext\f0 1.\tab}{\*\pn\pnlvlbody\pnf0\pnindent0\pnstart1\pndec{\pntxta.}}
\fi-360\li720\sa160\sl252\slmult1\b0\i\fs24 You can drag and drop your release into the input.\par
{\pntext\f0 2.\tab}You can use the browse button.\par
{\pntext\f0 3.\tab}You can copy paste the release name into the field.\par

\pard\widctlpar\sa160\sl252\slmult1\i0\fs28 What does the release name verifier check?\par
\i\fs24 It checks for characters other than \ldblquote a to z\rdblquote  (upper and lower), \ldblquote _\rdblquote  (underscore) and \ldblquote .\rdblquote  (dot). \par
\b\i0 It also checks if:\par
\b0\i Retail, Custom, DKsubs, DANiSH, NORDiC, MULTi, DK.ENG, DC, REMASTERED, EXTENDED, UNRATED, REMUX, BluRay, HDDVD, WEB-DL, WEBRip, HDTV, PAL, NTSC, DVDR, DVDRip, AVC, DTS-HD.MA, VC-1, TrueHD, TrueHD.Atmos, HDRip, XviD, H.264, x264 and x265\i0  \b is proper cased.\b0\par
\par
\b It does not check if the release is spelled correct, or if it\rquote s missing information\rquote s or characters, this means that releases like these will be verified as ok.\par
\cf0\b0\ldblquote\cf2\b My.ReleaseName2020.Dksubs.1080p.BluRay.x264-SuperRelease\cf0\b0\rdblquote\line\cf1 Here we clearly is missing a dot after the title name.\par
\cf0\ldblquote\cf2\b My.Release.Name.2020.NORDiC.1090p.BluRay.H.264-NewRelease\cf0\b0\rdblquote\line\cf1 Here we have a misspelling in 1090 which should had been 1080.\par
\cf0\ldblquote\cf2\b My.ReleaseName.2020DKSUBS.1080p.WEB-DL.x265-CoolRelease\cf0\b0\rdblquote\line\cf1 Here DKSUBS is in in proper casing, but due to the missing dot after 2020, the verifier can\rquote t pick it up as an error, and will therefor verifies it as OK.  \par

\pard\sa200\sl276\slmult1\cf0\f1\fs22\lang6\par

\pard\widctlpar\sb120\sa160\sl360\slmult1\fs24\lang1030 Hvordan fungere \rdblquote Release name verifier\rdblquote ?\par
Der er 3 m\'e5der hvorp\'e5 du kan tilf\'f8je dit release:\par

\pard 
{\pntext\f1 1.\tab}{\*\pn\pnlvlbody\pnf1\pnindent0\pnstart1\pndec{\pntxta.}}
\fi-360\li720\sb120\sa160\sl360\slmult1 Du kan tr\'e6kke og smide i feltet.\par
{\pntext\f1 2.\tab}Du kan bruge s\'f8g knappen\par
{\pntext\f1 3.\tab}Du kan inds\'e6tte navnet i feltet.\par

\pard\widctlpar\sb120\sa160\sl360\slmult1 Hvad tjekker \rdblquote Release name verifier\rdblquote ?\par
Den tjekker om navnet indeholder andre tegn end dem der er tilladt i et torrentnavn:\par
\cf3\b\rdblquote a til z\rdblquote  (store/sm\'e5 bogstaver), \rdblquote 0-9\rdblquote , \rdblquote _\rdblquote  underscore, \rdblquote -\rdblquote  bindestreg og \rdblquote .\rdblquote  punktum.\par
\cf0\b0 Derudover tjekker den om, ting som Retail, NORDiC mm. er navngivet korrekt, med store og sm\'e5 bogstaver.\par
Om der er BluRay i navnet, om det indeholder opl\'f8sning (720p, 1080p, 2160p)\par
Om der er video codec i navnet: x264, H.265 etc.\par
Hvis der er lyd codec, om det er navngivet korrekt: DTS5.1, DDP5.1, DTS-HDMA.7.1 osv.\par
Hvis det er serie episode, om det er korrekt navngivet SxxExx\par
Hvis serie s\'e6son om det er korrekt navngivet: Sxx / Sxx-xx\par

\pard\sa200\sl276\slmult1\fs22\lang6\par
}
";
            RtbInfo.SelectAll();
            RtbInfo.SelectionIndent += 20;
            RtbInfo.DeselectAll();
        }

        private void BtnInfoOK_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle,
                                                                       ColorTranslator.FromHtml("#181818"),
                                                                       ColorTranslator.FromHtml("#6b6b6b"),
                                                                       60F);
            e.Graphics.FillRectangle(brush, ClientRectangle);
        }
    }
}
