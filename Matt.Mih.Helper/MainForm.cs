using Matt.Mih.Helper.LeagueApi;
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

        public List<PlayerPresenter> PlayerPresenters { get; set; }

        public BalanceResult Swaps { get; set; }

        public bool Balancing { get; set; }

        public MainForm()
        {
            InitializeComponent();

            SettingsManager settings = new SettingsManager();

            LeagueRepository leagueRepository = new LeagueRepository(settings.Get().ApiKey, settings.Get().Region);

            NameManager nameManager = new NameManager();

            helper = new Helper(leagueRepository, nameManager, settings);
            Balancing = true;

            if(Properties.Settings.Default.firstRun)
            {
                itSettings.PerformClick();

                Properties.Settings.Default.firstRun = false;
                Properties.Settings.Default.Save();
            }

            /*Runepage page = helper.GetRunepage(0);

            RunepageStats stats = helper.GetRunepageStats(page);*/

            PlayerPresenters = new List<PlayerPresenter>(10);

            List<Champion> champList = helper.Champions;

            int playerViewHeight = 110;

            Size playerViewSize = new Size(150, playerViewHeight);

            for(int i=0;i<5;i++)
            {
                PlayerView panel = new PlayerView();
                PlayerPresenter presenter = new PlayerPresenter(panel, helper, champList, nameManager.AutoCompleteNames, i);
                panel.Size = playerViewSize;
                panel.Location = new System.Drawing.Point(20, i * (playerViewHeight + 5) + 40);
                
                panel.AutoSize = true;
                panel.ResumeLayout(false);
                panel.PerformLayout();

                Controls.Add(panel);
                PlayerPresenters.Add(presenter);
            }

            for (int i = 5; i < 10; i++)
            {
                PlayerView panel = new PlayerView();
                PlayerPresenter presenter = new PlayerPresenter(panel, helper, champList, nameManager.AutoCompleteNames, i);
                panel.Size = playerViewSize;
                panel.Location = new System.Drawing.Point(505, i * (playerViewHeight + 5) - (playerViewHeight + 5) * 5 + 40);

                panel.AutoSize = true;
                panel.ResumeLayout(false);
                panel.PerformLayout();

                Controls.Add(panel);
                PlayerPresenters.Add(presenter);
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
                        PlayerPresenters[swap.Item1].Swap(PlayerPresenters[swap.Item2]);
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

                foreach(PlayerPresenter pPresenter in PlayerPresenters)
                {
                    pPresenter.Enabled = false;
                }
            }
            else
            {
                btnGameToggle.Text = "Game Started";
                btnBalance.Enabled = true;
                helper.GameInProgress = false;

                foreach (PlayerPresenter pPanel in PlayerPresenters)
                {
                    pPanel.Enabled = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lSwap1.Text = "";
            lSwap2.Text = "";
            lRatingDifference.Text = "";

            foreach (PlayerPresenter pPresenter in PlayerPresenters)
            {
                Swaps = null;
                pPresenter.Clear();
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

        private void itSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            SettingsManager settingsManager = new SettingsManager();
            SettingsPresenter settingsPresenter = new SettingsPresenter(settingsForm, settingsManager);

            settingsForm.ShowDialog();

            helper.LeagueRepository.ApiKey = settingsManager.Get().ApiKey;
            helper.LeagueRepository.Region = settingsManager.Get().Region;
        }
    }
}
