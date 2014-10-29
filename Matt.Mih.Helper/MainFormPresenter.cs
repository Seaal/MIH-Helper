using Matt.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper
{
    class MainFormPresenter
    {
        private readonly IMainFormView MainView;
        private readonly Helper Helper;

        public bool Balancing { get; set; }

        public BalanceResult Swaps { get; set; }

        public List<PlayerPresenter> PlayerPresenters { get; set; }

        public MainFormPresenter(IMainFormView mainView, Helper helper)
        {
            MainView = mainView;
            Helper = helper;

            PlayerPresenters = new List<PlayerPresenter>(10);

            MainMenuPresenter mainMenuPresenter = new MainMenuPresenter(MainView.MainMenuView, Helper);

            List<Champion> champions = null;

            try
            {
                champions = Helper.Champions;
            }
            catch(WebException)
            {
                champions = new List<Champion>();

                MainView.RatingDifference = "An error has occurred";
                MainView.RatingDifferenceTextColor = System.Drawing.Color.Red;
            }
            
            AutoCompleteStringCollection names = Helper.NameManager.AutoCompleteNames;

            for(int i=0; i<10; i++)
            {
                IPlayerView playerView = MainView.PlayersView[i];
                PlayerPresenter presenter = new PlayerPresenter(playerView, Helper, champions, names, i);

                PlayerPresenters.Add(presenter);
            }

            Balancing = true;

            MainView.BalanceTeamsClick += new EventHandler(OnBalanceButtonClick);
            MainView.GameToggleClick += new EventHandler(OnGameToggleButtonClick);
            MainView.ClearAllClick += new EventHandler(OnClearAllButtonClick);

            if (Properties.Settings.Default.firstRun)
            {
                mainMenuPresenter.ShowSettingsForm();

                Properties.Settings.Default.firstRun = false;
                Properties.Settings.Default.Save();
            }
        }

        private void OnBalanceButtonClick(object sender, EventArgs e)
        {
            if (Balancing == true)
            {
                try
                {
                    BalanceResult result = Helper.BalanceTeams();

                    if (result.Swaps.Count == 0)
                    {
                        MainView.Swap1 = "Teams are Balanced";
                    }
                    else
                    {
                        MainView.Swap1 = "Swap " + result.Swaps[0].Item1.Name + " and " + result.Swaps[0].Item2.Name;
                        MainView.Swap2 = result.Swaps.Count == 2 ? "Swap " + result.Swaps[1].Item1.Name + " and " + result.Swaps[1].Item2.Name : MainView.Swap2 = "";
                        Swaps = result;

                        changeBalanceButton(false);
                    }

                    MainView.RatingDifferenceTextColor = System.Drawing.Color.Black;
                    MainView.RatingDifference = "Rating Difference: " + result.RatingDifference;
                }
                catch (ArgumentException ex)
                {
                    MainView.RatingDifferenceTextColor = System.Drawing.Color.Red;
                    MainView.RatingDifference = ex.Message;
                }
            }
            else
            {
                //Swap players and remove swap messages

                MainView.Swap1 = "";
                MainView.Swap2 = "";

                if (Swaps != null)
                {
                    List<Tuple<int, int>> uiSwaps = Helper.PerformSwaps(Swaps);

                    foreach (Tuple<int, int> swap in uiSwaps)
                    {
                        PlayerPresenters[swap.Item1].Swap(PlayerPresenters[swap.Item2]);
                    }

                    Swaps = null;
                }

                changeBalanceButton(true);
            }

        }

        private void OnGameToggleButtonClick(object sender, EventArgs e)
        {
            if (Helper.GameInProgress == false)
            {
                //Disable UI parts
                MainView.GameToggleButtonText = "Game Ended";
                MainView.BalanceButtonEnabled = false;
                MainView.ClearAllButtonEnabled = false;

                Helper.GameInProgress = true;

                foreach (PlayerPresenter pPresenter in PlayerPresenters)
                {
                    pPresenter.Enabled = false;
                }
            }
            else
            {
                MainView.GameToggleButtonText = "Game Started";
                MainView.BalanceButtonEnabled = true;
                MainView.ClearAllButtonEnabled = true;

                Helper.GameInProgress = false;

                foreach (PlayerPresenter pPanel in PlayerPresenters)
                {
                    pPanel.Enabled = true;
                }
            }
        }

        private void OnClearAllButtonClick(object sender, EventArgs e)
        {
            MainView.Swap1 = "";
            MainView.Swap2 = "";
            MainView.RatingDifference = "";

            foreach (PlayerPresenter pPresenter in PlayerPresenters)
            {
                Swaps = null;
                pPresenter.Clear();
                Helper.ClearPlayers();
                changeBalanceButton(true);
            }
        }

        private void changeBalanceButton(bool balance)
        {
            Balancing = balance;

            if (balance)
            {
                MainView.BalanceButtonText = "Balance Teams";
            }
            else
            {
                MainView.BalanceButtonText = "Swap Players";
            }
        }
    }
}
