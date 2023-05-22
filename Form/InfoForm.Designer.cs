namespace ReleaseNameVerifier
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.RtbInfo = new System.Windows.Forms.RichTextBox();
            this.BtnInfoOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RtbInfo
            // 
            this.RtbInfo.BackColor = System.Drawing.Color.SkyBlue;
            this.RtbInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RtbInfo.ForeColor = System.Drawing.Color.Navy;
            this.RtbInfo.Location = new System.Drawing.Point(12, 12);
            this.RtbInfo.Name = "RtbInfo";
            this.RtbInfo.ReadOnly = true;
            this.RtbInfo.Size = new System.Drawing.Size(776, 391);
            this.RtbInfo.TabIndex = 0;
            this.RtbInfo.Text = "blablbla";
            // 
            // BtnInfoOK
            // 
            this.BtnInfoOK.BackColor = System.Drawing.Color.SkyBlue;
            this.BtnInfoOK.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.BtnInfoOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnInfoOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.BtnInfoOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnInfoOK.Location = new System.Drawing.Point(363, 415);
            this.BtnInfoOK.Name = "BtnInfoOK";
            this.BtnInfoOK.Size = new System.Drawing.Size(75, 23);
            this.BtnInfoOK.TabIndex = 1;
            this.BtnInfoOK.Text = "&OK";
            this.BtnInfoOK.UseVisualStyleBackColor = false;
            this.BtnInfoOK.Click += new System.EventHandler(this.BtnInfoOK_Click);
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnInfoOK);
            this.Controls.Add(this.RtbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RtbInfo;
        private System.Windows.Forms.Button BtnInfoOK;
    }
}