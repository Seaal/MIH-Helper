using Matt.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper
{
    partial class PlayerPanel
    {
        private void InitializeComponent(Dictionary<String, Champion> champsList, AutoCompleteStringCollection summonerNamesAutoComplete)
        {
            Label lPlayerName = new System.Windows.Forms.Label();
            this.tbPlayer = new System.Windows.Forms.TextBox();
            Label lChampion = new System.Windows.Forms.Label();
            this.cbChampions = new System.Windows.Forms.ComboBox();
            this.pbChampion = new System.Windows.Forms.PictureBox();
            Label lRankedElo = new System.Windows.Forms.Label();
            this.tbElo = new System.Windows.Forms.TextBox();
            this.lError = new System.Windows.Forms.Label();
            
            this.SuspendLayout();

            int inputsX = 55;
            int inputsY = 5;

            // Player Name Label
            lPlayerName.AutoSize = true;
            lPlayerName.Location = new System.Drawing.Point(inputsX, inputsY + 4);
            lPlayerName.Name = "label";
            lPlayerName.Size = new System.Drawing.Size(70, 13);
            lPlayerName.Text = "Player Name:";

            // Player Name Texbox
            this.tbPlayer.Location = new System.Drawing.Point(inputsX + 73, inputsY);
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer.TabIndex = 0;
            this.tbPlayer.Leave += new System.EventHandler(this.getPlayerSummoner);
            this.tbPlayer.AutoCompleteMode = AutoCompleteMode.Append;
            this.tbPlayer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.tbPlayer.AutoCompleteCustomSource = summonerNamesAutoComplete;

            // Champion Label
            lChampion.AutoSize = true;
            lChampion.Location = new System.Drawing.Point(inputsX + 13, inputsY + 30);
            lChampion.Name = "lChampion";
            lChampion.Size = new System.Drawing.Size(57, 13);
            lChampion.Text = "Champion:";

            // Champion Combo Box
            this.cbChampions.FormattingEnabled = true;
            this.cbChampions.Location = new System.Drawing.Point(inputsX + 73, inputsY + 26);
            this.cbChampions.Name = "cbChampions";
            this.cbChampions.Size = new System.Drawing.Size(121, 21);
            this.cbChampions.Sorted = true;
            this.cbChampions.TabStop = false;
            this.cbChampions.DataSource = new BindingSource(champsList, null);
            this.cbChampions.DisplayMember = "Value";
            this.cbChampions.ValueMember = "Key";
            this.cbChampions.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbChampions.SelectionChangeCommitted += new System.EventHandler(this.changeChampionPicture);

            // Champion Picture Box
            this.pbChampion.Name = "pbChampion";
            this.pbChampion.Size = new System.Drawing.Size(50, 50);
            this.pbChampion.Location = new System.Drawing.Point(5, 5);
            this.pbChampion.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pbChampion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Ranked Elo Label
            lRankedElo.AutoSize = true;
            lRankedElo.Location = new System.Drawing.Point(inputsX + 4, inputsY + 58);
            lRankedElo.Name = "lRankedElo";
            lRankedElo.Size = new System.Drawing.Size(66, 13);
            lRankedElo.Text = "Ranked Elo:";

            // Ranked Elo Textbox
            this.tbElo.Location = new System.Drawing.Point(inputsX + 73, inputsY + 54);
            this.tbElo.Name = "tbElo";
            this.tbElo.ReadOnly = true;
            this.tbElo.Size = new System.Drawing.Size(100, 20);
            this.tbElo.TabStop = false;

            // Error Label
            this.lError.ForeColor = System.Drawing.Color.Red;
            this.lError.Location = new System.Drawing.Point(inputsX, inputsY + 81);
            this.lError.Name = "lError";
            this.lError.Size = new System.Drawing.Size(200, 18);
            this.lError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //Add to Controls
            Controls.Add(lPlayerName);
            Controls.Add(tbPlayer);
            Controls.Add(lChampion);
            Controls.Add(cbChampions);
            Controls.Add(pbChampion);
            Controls.Add(lRankedElo);
            Controls.Add(tbElo);
            Controls.Add(lError);

            this.ResumeLayout(false);
        }
    }
}
