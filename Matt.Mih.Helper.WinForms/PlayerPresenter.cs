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
        private readonly IIconPathManager IconPathManager;

        public int PlayerNumber { get; set; }

        public PlayerPresenter(IPlayerView playerView, Helper helper, IIconPathManager iconPathManager, List<Champion> champions, AutoCompleteStringCollection names, int playerNumber)
        {
            PlayerView = playerView;
            PlayerNumber = playerNumber;
            Helper = helper;
            IconPathManager = iconPathManager;

            PlayerView.Champions = new List<Champion>(champions);
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

        private void OnPlayerNameChange(object sender, EventArgs e)
        {
            try
            {
                Summoner summoner = Helper.GetSummoner(PlayerView.PlayerName, PlayerNumber);

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
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    switch (((HttpWebResponse)exception.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            PlayerView.Error = "Player not found.";
                            break;
                        case HttpStatusCode.Unauthorized:
                            PlayerView.Error = "Unauthorized, check your API key.";
                            break;
                        case HttpStatusCode.BadRequest:
                            PlayerView.Error = "Bad Request, try again later.";
                            break;
                        case HttpStatusCode.ServiceUnavailable:
                        case HttpStatusCode.InternalServerError:
                            PlayerView.Error = "API unavailable, try again later.";
                            break;
                        case (HttpStatusCode)429:
                            PlayerView.Error = "API limit reached, try again.";
                            break;
                        default:
                            PlayerView.Error = "An error has occurred.";
                            break;
                    }
                }
                else
                {
                    PlayerView.Error = "An error has occurred.";
                }

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
            string champName = PlayerView.SelectedChampion.key;

            string leagueFolder = Helper.SettingsManager.Get().LeagueFolder;

            try
            {
                PlayerView.ChampionIconPath = IconPathManager.GetIconPath(champName, leagueFolder);
            }
            catch (DirectoryNotFoundException)
            {
                PlayerView.ChampionIconPath = "";
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
