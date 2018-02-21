namespace Zadatak03
{
    partial class Form1
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
            this.cbDrzave = new System.Windows.Forms.ComboBox();
            this.lbGradovi = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cbDrzave
            // 
            this.cbDrzave.FormattingEnabled = true;
            this.cbDrzave.Location = new System.Drawing.Point(13, 13);
            this.cbDrzave.Name = "cbDrzave";
            this.cbDrzave.Size = new System.Drawing.Size(259, 21);
            this.cbDrzave.TabIndex = 0;
            this.cbDrzave.SelectedIndexChanged += new System.EventHandler(this.cbDrzave_SelectedIndexChanged);
            // 
            // lbGradovi
            // 
            this.lbGradovi.FormattingEnabled = true;
            this.lbGradovi.Location = new System.Drawing.Point(13, 41);
            this.lbGradovi.Name = "lbGradovi";
            this.lbGradovi.Size = new System.Drawing.Size(259, 212);
            this.lbGradovi.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbGradovi);
            this.Controls.Add(this.cbDrzave);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDrzave;
        private System.Windows.Forms.ListBox lbGradovi;
    }
}

