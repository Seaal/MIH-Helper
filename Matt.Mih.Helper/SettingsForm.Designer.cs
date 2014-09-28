using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    partial class SettingsForm
    {
        private void InitializeComponent()
        {
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.lApiKey = new System.Windows.Forms.Label();
            this.fbLeagueFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tbLeagueFolder = new System.Windows.Forms.TextBox();
            this.lLeagueFolder = new System.Windows.Forms.Label();
            this.btnLeagueFolder = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lRegion = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(79, 51);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(219, 20);
            this.tbApiKey.TabIndex = 0;
            // 
            // lApiKey
            // 
            this.lApiKey.AutoSize = true;
            this.lApiKey.Location = new System.Drawing.Point(25, 55);
            this.lApiKey.Name = "lApiKey";
            this.lApiKey.Size = new System.Drawing.Size(48, 13);
            this.lApiKey.TabIndex = 1;
            this.lApiKey.Text = "API Key:";
            // 
            // fbLeagueFolder
            // 
            this.fbLeagueFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbLeagueFolder.ShowNewFolderButton = false;
            // 
            // tbLeagueFolder
            // 
            this.tbLeagueFolder.Location = new System.Drawing.Point(79, 77);
            this.tbLeagueFolder.Name = "tbLeagueFolder";
            this.tbLeagueFolder.Size = new System.Drawing.Size(219, 20);
            this.tbLeagueFolder.TabIndex = 2;
            // 
            // lLeagueFolder
            // 
            this.lLeagueFolder.AutoSize = true;
            this.lLeagueFolder.Location = new System.Drawing.Point(13, 81);
            this.lLeagueFolder.Name = "lLeagueFolder";
            this.lLeagueFolder.Size = new System.Drawing.Size(60, 13);
            this.lLeagueFolder.TabIndex = 3;
            this.lLeagueFolder.Text = "LoL Folder:";
            // 
            // btnLeagueFolder
            // 
            this.btnLeagueFolder.Location = new System.Drawing.Point(304, 76);
            this.btnLeagueFolder.Name = "btnLeagueFolder";
            this.btnLeagueFolder.Size = new System.Drawing.Size(75, 20);
            this.btnLeagueFolder.TabIndex = 4;
            this.btnLeagueFolder.Text = "Find";
            this.btnLeagueFolder.UseVisualStyleBackColor = true;
            this.btnLeagueFolder.Click += new System.EventHandler(this.btnLeagueFolder_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(50, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(243, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lRegion
            // 
            this.lRegion.AutoSize = true;
            this.lRegion.Location = new System.Drawing.Point(29, 108);
            this.lRegion.Name = "lRegion";
            this.lRegion.Size = new System.Drawing.Size(44, 13);
            this.lRegion.TabIndex = 7;
            this.lRegion.Text = "Region:";
            // 
            // cbRegion
            // 
            this.cbRegion.Location = new System.Drawing.Point(80, 104);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(121, 21);
            this.cbRegion.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(391, 346);
            this.Controls.Add(this.cbRegion);
            this.Controls.Add(this.lRegion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLeagueFolder);
            this.Controls.Add(this.lLeagueFolder);
            this.Controls.Add(this.tbLeagueFolder);
            this.Controls.Add(this.lApiKey);
            this.Controls.Add(this.tbApiKey);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.Label lRegion;
    }
}
