using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Matt.Mih.Helper
{
    public partial class MainForm : Form
    {
        private readonly Helper helper;

        public List<PlayerPanel> PlayerPanels { get; set; }

        public BalanceResult Swaps { get; set; }

        public bool Balancing { get; set; }

        public MainForm()
        {
            InitializeComponent();

            LeagueApiDAO leagueApi = new LeagueApiDAO();

            NameHandler names = new NameHandler();

            helper = new Helper(leagueApi, names);

            Balancing = true;

            PlayerPanels = new List<PlayerPanel>(10);

            Dictionary<string, Champion> champList = helper.Champions;

            for(int i=0;i<5;i++)
            {
                PlayerPanel panel = new PlayerPanel(i, helper, champList, names.AutoCompleteNames);
                panel.Location = new System.Drawing.Point(20, i * 115 + 20);
                panel.AutoSize = true;
                panel.ResumeLayout(false);
                panel.PerformLayout();

                Controls.Add(panel);
                PlayerPanels.Add(panel);
            }

            for (int i = 5; i < 10; i++)
            {
                PlayerPanel panel = new PlayerPanel(i, helper, champList, names.AutoCompleteNames);
                panel.Location = new System.Drawing.Point(560, i * 115 - 555);
                panel.AutoSize = true;
                panel.ResumeLayout(false);
                panel.PerformLayout();

                Controls.Add(panel);
                PlayerPanels.Add(panel);
            }

            lSwap1.SendToBack();
            lSwap2.SendToBack();
            lRatingDifference.SendToBack();
            

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            if(Balancing == true)
            {
                try
                {
                    BalanceResult result = helper.BalanceTeams();

                    if (result.Swaps.Count == 0)
                    {
                        lSwap1.Text = "Teams are Balanced";
                    }
                    else if (result.Swaps.Count == 1)
                    {
                        lSwap1.Text = "Swap " + result.Swaps[0].Item1.Name + " and " + result.Swaps[0].Item2.Name;
                        Swaps = result;

                        changeBalanceButton(false);
                    }
                    else
                    {
                        lSwap1.Text = "Swap " + result.Swaps[0].Item1.Name + " and " + result.Swaps[0].Item2.Name;
                        lSwap2.Text = "Swap " + result.Swaps[1].Item1.Name + " and " + result.Swaps[1].Item2.Name;
                        Swaps = result;

                        changeBalanceButton(false);
                    }

                    lRatingDifference.ForeColor = System.Drawing.Color.Black;
                    lRatingDifference.Text = "Rating Difference: " + result.RatingDifference;
                }
                catch (ArgumentException ex)
                {
                    lRatingDifference.ForeColor = System.Drawing.Color.Red;
                    lRatingDifference.Text = ex.Message;
                }
            }
            else
            {
                //Swap players and remove swap messages

                lSwap1.Text = "";
                lSwap2.Text = "";

                if (Swaps != null)
                {
                    List<Tuple<int, int>> uiSwaps = helper.PerformSwaps(Swaps);

                    foreach (Tuple<int, int> swap in uiSwaps)
                    {
                        PlayerPanels[swap.Item1].Swap(PlayerPanels[swap.Item2]);
                    }

                    Swaps = null;
                }

                changeBalanceButton(true);
            }
            
        }

        private void btnGameToggle_Click(object sender, EventArgs e)
        {
            if (helper.GameInProgress == false)
            {
                //Disable UI parts
                btnGameToggle.Text = "Game Ended";
                btnBalance.Enabled = false;
                helper.GameInProgress = true;

                foreach(PlayerPanel pPanel in PlayerPanels)
                {
                    pPanel.Enabled = false;
                }
            }
            else
            {
                btnGameToggle.Text = "Game Started";
                btnBalance.Enabled = true;
                helper.GameInProgress = false;

                foreach (PlayerPanel pPanel in PlayerPanels)
                {
                    pPanel.Enabled = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (PlayerPanel pPanel in PlayerPanels)
            {
                lSwap1.Text = "";
                lSwap2.Text = "";
                lRatingDifference.Text = "";
                Swaps = null;
                pPanel.Clear();
                helper.ClearPlayers();
                changeBalanceButton(true);
            }
        }

        private void changeBalanceButton(bool balance)
        {
            Balancing = balance;

            if(balance)
            {
                btnBalance.Text = "Balance Teams";
            }
            else
            {
                btnBalance.Text = "Swap Players";
            }
        }
    }
}
