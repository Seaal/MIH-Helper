using Matt.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper.WinForms
{
    public class PlayerPresenter
    {
        private readonly IPlayerView PlayerView;
        private readonly Helper Helper;
        private readonly IIconPathService IconPathService;

        public int PlayerNumber { get; set; }

        public PlayerPresenter(IPlayerView playerView, Helper helper, IIconPathService iconPathService, AutoCompleteStringCollection names, int playerNumber)
        {
            PlayerView = playerView;
            PlayerNumber = playerNumber;
            Helper = helper;
            IconPathService = iconPathService;

            PlayerView.Champions = new List<Champion>();
            PlayerView.ExistingNames = names;
            PlayerView.Error = "";
            UpdateChampionIcon();

            PlayerView.PlayerNameTextboxLeave += new EventHandler(OnPlayerNameChange);
            PlayerView.ChampionSelectedChanged += new EventHandler(OnSelectedChampionChange);
        }

        public bool Enabled
        {
            get { return PlayerView.Enabled; }
            set { PlayerView.Enabled = value; }
        }

        public List<Champion> Champions
        {
            get { return PlayerView.Champions; }
            set
            {
                if(Champions.Count == 0)
                {
                    PlayerView.Champions = new List<Champion>(value);
                }
            }
        }

        private async void OnPlayerNameChange(object sender, EventArgs e)
        {
            try
            {
                Summoner summoner = await Helper.GetSummonerAsync(PlayerView.PlayerName, PlayerNumber);

                PlayerView.PlayerName = summoner.Name;
                PlayerView.Elo = summoner.Tier + " " + summoner.Division;

                if (summoner.Level < 30)
                {
                    PlayerView.Error = "Warning: Player is level " + summoner.Level + ".";
                }
                else
                {
                    PlayerView.Error = "";
                }
            }
            catch (WebException exception)
            {
                WebExceptionService wexService = new WebExceptionService();

                PlayerView.Error = wexService.Handle(exception);
                PlayerView.Elo = "";
            }
            catch (ArgumentException exception)
            {
                PlayerView.Error = exception.Message;
                PlayerView.Elo = "";
            }
        }

        private void OnSelectedChampionChange(object sender, EventArgs e)
        {
            UpdateChampionIcon();
        }

        private void UpdateChampionIcon()
        {
            if(PlayerView.SelectedChampion != null)
            {
                string champName = PlayerView.SelectedChampion.key;

                string leagueFolder = Helper.SettingsService.Get().LeagueFolder;

                try
                {
                    PlayerView.ChampionIconPath = IconPathService.GetIconPath(champName, leagueFolder);
                }
                catch (DirectoryNotFoundException)
                {
                    PlayerView.ChampionIconPath = "";
                }
            } 
        }

        public void Swap(PlayerPresenter otherPresenter)
        {
            string tempName = otherPresenter.PlayerView.PlayerName;
            string tempElo = otherPresenter.PlayerView.Elo;
            string tempError = otherPresenter.PlayerView.Error;
            int tempChampIndex = otherPresenter.PlayerView.SelectedChampionIndex;

            otherPresenter.PlayerView.PlayerName = PlayerView.PlayerName;
            otherPresenter.PlayerView.Elo = PlayerView.Elo;
            otherPresenter.PlayerView.Error = PlayerView.Error;
            otherPresenter.PlayerView.SelectedChampionIndex = PlayerView.SelectedChampionIndex;

            PlayerView.PlayerName = tempName;
            PlayerView.Elo = tempElo;
            PlayerView.Error = tempError;
            PlayerView.SelectedChampionIndex = tempChampIndex;
        }

        public void Clear()
        {
            PlayerView.PlayerName = "";
            PlayerView.Elo = "";
            PlayerView.SelectedChampionIndex = 0;
            PlayerView.Error = "";
            UpdateChampionIcon();
        }

    }
}
