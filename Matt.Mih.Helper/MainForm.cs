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

        public MainForm()
        {
            InitializeComponent();

            helper = new Helper();

            PlayerPanels = new List<PlayerPanel>(10);

            Dictionary<string, Champion> champList = helper.Champions;

            for(int i=0;i<5;i++)
            {
                PlayerPanel panel = new PlayerPanel(i, helper, champList, NameHandler.GetInstance().AutoCompleteNames);
                panel.Location = new System.Drawing.Point(20, i * 100 + 20);
                panel.AutoSize = true;
                panel.ResumeLayout(false);
                panel.PerformLayout();

                Controls.Add(panel);
                PlayerPanels.Add(panel);
            }

            for (int i = 5; i < 10; i++)
            {
                PlayerPanel panel = new PlayerPanel(i, helper, champList, NameHandler.GetInstance().AutoCompleteNames);
                panel.Location = new System.Drawing.Point(580, i * 100 - 480);
                panel.AutoSize = true;
                panel.ResumeLayout(false);
                panel.PerformLayout();

                Controls.Add(panel);
                PlayerPanels.Add(panel);
            }

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            BalanceResult result = helper.BalanceTeams();

            if(result.Swaps.Count == 0)
            {
                lSwap1.Text = "Teams are Balanced";
            }
            else if (result.Swaps.Count == 1)
            {
                lSwap1.Text = "Swap " + result.Swaps[0].Item1.Name + " and " + result.Swaps[0].Item2.Name;
            }
            else
            {
                lSwap1.Text = "Swap " + result.Swaps[0].Item1.Name + " and " + result.Swaps[0].Item2.Name;
                lSwap2.Text = "Swap " + result.Swaps[1].Item1.Name + " and " + result.Swaps[1].Item2.Name;
            }

            lRatingDifference.Text = "Rating Difference: " + result.RatingDifference;
        }

        private void btnGameToggle_Click(object sender, EventArgs e)
        {
            if (helper.GameInProgress == false)
            {
                btnGameToggle.Text = "Game Ended";
                lSwap1.Text = "";
                lSwap2.Text = "";
                btnBalance.Enabled = false;
                helper.GameInProgress = true;

                foreach(PlayerPanel ppanel in PlayerPanels)
                {
                    ppanel.Enabled = false;
                }
                
            }
            else
            {
                btnGameToggle.Text = "Game Started";
                btnBalance.Enabled = true;
                helper.GameInProgress = false;

                foreach (PlayerPanel ppanel in PlayerPanels)
                {
                    ppanel.Enabled = true;
                }
            }
        }
    }
}
