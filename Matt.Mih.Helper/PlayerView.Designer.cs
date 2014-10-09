using Matt.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper
{
    partial class PlayerView
    {
        private void InitializeComponent()
        {
            this.lPlayerName = new System.Windows.Forms.Label();
            this.tbPlayer = new System.Windows.Forms.TextBox();
            this.lChampion = new System.Windows.Forms.Label();
            this.cbChampions = new System.Windows.Forms.ComboBox();
            this.pbChampion = new System.Windows.Forms.PictureBox();
            this.lRankedElo = new System.Windows.Forms.Label();
            this.tbElo = new System.Windows.Forms.TextBox();
            this.lError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbChampion)).BeginInit();
            this.SuspendLayout();
            // 
            // lPlayerName
            // 
            this.lPlayerName.AutoSize = true;
            this.lPlayerName.Location = new System.Drawing.Point(61, 9);
            this.lPlayerName.Name = "lPlayerName";
            this.lPlayerName.Size = new System.Drawing.Size(70, 13);
            this.lPlayerName.TabIndex = 0;
            this.lPlayerName.Text = "Player Name:";
            // 
            // tbPlayer
            // 
            this.tbPlayer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.tbPlayer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbPlayer.Location = new System.Drawing.Point(137, 5);
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer.TabIndex = 0;
            // 
            // lChampion
            // 
            this.lChampion.AutoSize = true;
            this.lChampion.Location = new System.Drawing.Point(74, 35);
            this.lChampion.Name = "lChampion";
            this.lChampion.Size = new System.Drawing.Size(57, 13);
            this.lChampion.TabIndex = 1;
            this.lChampion.Text = "Champion:";
            // 
            // cbChampions
            // 
            this.cbChampions.DisplayMember = "name";
            this.cbChampions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChampions.FormattingEnabled = true;
            this.cbChampions.Location = new System.Drawing.Point(137, 31);
            this.cbChampions.Name = "cbChampions";
            this.cbChampions.Size = new System.Drawing.Size(121, 21);
            this.cbChampions.Sorted = true;
            this.cbChampions.TabIndex = 2;
            this.cbChampions.TabStop = false;
            // 
            // pbChampion
            // 
            this.pbChampion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbChampion.Location = new System.Drawing.Point(5, 5);
            this.pbChampion.Name = "pbChampion";
            this.pbChampion.Size = new System.Drawing.Size(50, 50);
            this.pbChampion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChampion.TabIndex = 3;
            this.pbChampion.TabStop = false;
            // 
            // lRankedElo
            // 
            this.lRankedElo.AutoSize = true;
            this.lRankedElo.Location = new System.Drawing.Point(65, 61);
            this.lRankedElo.Name = "lRankedElo";
            this.lRankedElo.Size = new System.Drawing.Size(66, 13);
            this.lRankedElo.TabIndex = 4;
            this.lRankedElo.Text = "Ranked Elo:";
            // 
            // tbElo
            // 
            this.tbElo.Location = new System.Drawing.Point(137, 57);
            this.tbElo.Name = "tbElo";
            this.tbElo.ReadOnly = true;
            this.tbElo.Size = new System.Drawing.Size(100, 20);
            this.tbElo.TabIndex = 5;
            this.tbElo.TabStop = false;
            // 
            // lError
            // 
            this.lError.ForeColor = System.Drawing.Color.Red;
            this.lError.Location = new System.Drawing.Point(32, 87);
            this.lError.Name = "lError";
            this.lError.Size = new System.Drawing.Size(200, 18);
            this.lError.TabIndex = 6;
            this.lError.Text = "{{Error Label}}";
            this.lError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerView
            // 
            this.Controls.Add(this.lPlayerName);
            this.Controls.Add(this.tbPlayer);
            this.Controls.Add(this.lChampion);
            this.Controls.Add(this.cbChampions);
            this.Controls.Add(this.pbChampion);
            this.Controls.Add(this.lRankedElo);
            this.Controls.Add(this.tbElo);
            this.Controls.Add(this.lError);
            this.Name = "PlayerView";
            this.Size = new System.Drawing.Size(264, 113);
            ((System.ComponentModel.ISupportInitialize)(this.pbChampion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lPlayerName;
        private Label lChampion;
        private Label lRankedElo;
    }
}
