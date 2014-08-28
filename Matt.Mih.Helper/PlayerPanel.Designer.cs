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
            Label lRankedElo = new System.Windows.Forms.Label();
            this.tbElo = new System.Windows.Forms.TextBox();
            this.lError = new System.Windows.Forms.Label();
            this.btnSwap = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Player Name Label
            lPlayerName.AutoSize = true;
            lPlayerName.Location = new System.Drawing.Point(0, 4);
            lPlayerName.Name = "label";
            lPlayerName.Size = new System.Drawing.Size(70, 13);
            lPlayerName.Text = "Player Name:";

            // Player Name Texbox
            this.tbPlayer.Location = new System.Drawing.Point(73, 0);
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer.TabIndex = 0;
            this.tbPlayer.Leave += new System.EventHandler(this.getPlayerSummoner);
            this.tbPlayer.AutoCompleteMode = AutoCompleteMode.Append;
            this.tbPlayer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.tbPlayer.AutoCompleteCustomSource = summonerNamesAutoComplete;

            // Champion Label
            lChampion.AutoSize = true;
            lChampion.Location = new System.Drawing.Point(13, 30);
            lChampion.Name = "lChampion";
            lChampion.Size = new System.Drawing.Size(57, 13);
            lChampion.Text = "Champion:";

            // Champion Combo Box
            this.cbChampions.FormattingEnabled = true;
            this.cbChampions.Location = new System.Drawing.Point(73, 26);
            this.cbChampions.Name = "cbChampions";
            this.cbChampions.Size = new System.Drawing.Size(121, 21);
            this.cbChampions.Sorted = true;
            this.cbChampions.TabStop = false;
            this.cbChampions.DataSource = new BindingSource(champsList, null);
            this.cbChampions.DisplayMember = "Value";
            this.cbChampions.ValueMember = "Key";
            this.cbChampions.DropDownStyle = ComboBoxStyle.DropDownList;

            // Ranked Elo Label
            lRankedElo.AutoSize = true;
            lRankedElo.Location = new System.Drawing.Point(4, 58);
            lRankedElo.Name = "lRankedElo";
            lRankedElo.Size = new System.Drawing.Size(66, 13);
            lRankedElo.Text = "Ranked Elo:";

            // Ranked Elo Textbox
            this.tbElo.Location = new System.Drawing.Point(73, 54);
            this.tbElo.Name = "tbElo";
            this.tbElo.ReadOnly = true;
            this.tbElo.Size = new System.Drawing.Size(100, 20);
            this.tbElo.TabStop = false;

            // Error Label
            this.lError.AutoSize = true;
            this.lError.ForeColor = System.Drawing.Color.Red;
            this.lError.Location = new System.Drawing.Point(73, 81);
            this.lError.Name = "lError";
            this.lError.Size = new System.Drawing.Size(0, 13);

            // Swap Button
            this.btnSwap.Location = new System.Drawing.Point(73, 81);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(100, 23);
            this.btnSwap.TabIndex = 20;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.TabStop = false;
            this.btnSwap.Hide();
            //this.btnSwap.Click += new System.EventHandler(this.btnBalance_Click);

            //Add to Controls
            Controls.Add(lPlayerName);
            Controls.Add(tbPlayer);
            Controls.Add(lChampion);
            Controls.Add(cbChampions);
            Controls.Add(lRankedElo);
            Controls.Add(tbElo);
            Controls.Add(lError);
            Controls.Add(btnSwap);

            this.ResumeLayout(false);
        }
    }
}
