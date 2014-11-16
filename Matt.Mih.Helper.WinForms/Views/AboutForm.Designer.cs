namespace Matt.Mih.Helper.WinForms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lInformation = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lVersion = new System.Windows.Forms.Label();
            this.lRiotStatement = new System.Windows.Forms.Label();
            this.llSourceLink = new System.Windows.Forms.LinkLabel();
            this.lLicense = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lInformation
            // 
            this.lInformation.Location = new System.Drawing.Point(12, 9);
            this.lInformation.Name = "lInformation";
            this.lInformation.Size = new System.Drawing.Size(260, 26);
            this.lInformation.TabIndex = 0;
            this.lInformation.Text = "An open source project which assists the user in the running of educational games" +
    " of League of Legends.";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(105, 226);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lVersion
            // 
            this.lVersion.Location = new System.Drawing.Point(12, 176);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(260, 13);
            this.lVersion.TabIndex = 2;
            this.lVersion.Text = "{{Version}}";
            this.lVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lRiotStatement
            // 
            this.lRiotStatement.Location = new System.Drawing.Point(12, 43);
            this.lRiotStatement.Name = "lRiotStatement";
            this.lRiotStatement.Size = new System.Drawing.Size(260, 91);
            this.lRiotStatement.TabIndex = 3;
            this.lRiotStatement.Text = resources.GetString("lRiotStatement.Text");
            // 
            // llSourceLink
            // 
            this.llSourceLink.AutoSize = true;
            this.llSourceLink.Location = new System.Drawing.Point(12, 197);
            this.llSourceLink.Name = "llSourceLink";
            this.llSourceLink.Size = new System.Drawing.Size(187, 13);
            this.llSourceLink.TabIndex = 5;
            this.llSourceLink.TabStop = true;
            this.llSourceLink.Text = "http://github.com/Seaaal/MIH-Helper";
            // 
            // lLicense
            // 
            this.lLicense.Location = new System.Drawing.Point(12, 142);
            this.lLicense.Name = "lLicense";
            this.lLicense.Size = new System.Drawing.Size(260, 26);
            this.lLicense.TabIndex = 6;
            this.lLicense.Text = "This projected is licensed under the terms of the MIT license.";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lLicense);
            this.Controls.Add(this.llSourceLink);
            this.Controls.Add(this.lRiotStatement);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lInformation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label lRiotStatement;
        private System.Windows.Forms.LinkLabel llSourceLink;
        private System.Windows.Forms.Label lLicense;
    }
}