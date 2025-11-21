namespace UI.Interfaces.Sesion.Help
{
    partial class frmNotasVersion
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
            this.webBrowserAbout = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserAbout
            // 
            this.webBrowserAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserAbout.Location = new System.Drawing.Point(0, 0);
            this.webBrowserAbout.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAbout.Name = "webBrowserAbout";
            this.webBrowserAbout.Size = new System.Drawing.Size(602, 642);
            this.webBrowserAbout.TabIndex = 0;
            this.webBrowserAbout.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 642);
            this.Controls.Add(this.webBrowserAbout);
            this.Name = "frmAbout";
            this.Text = "frmAbout";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserAbout;
    }
}