using Matt.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper
{
    public class PlayerPresenter
    {
        private readonly string CHAMP_IMAGES_LOCATION_PRE_RELEASES = @"\RADS\projects\lol_air_client\releases\";
        private readonly string CHAMP_IMAGES_LOCATION_POST_RELEASES = @"\deploy\assets\images\champions\";
        private readonly string CHAMP_IMAGES_SUFFIX = "_Square_0.png";

        private readonly IPlayerView PlayerView;
        private readonly Helper helper;

        public int PlayerNumber { get; set; }

        public PlayerPresenter(IPlayerView playerView, Helper helper, List<Champion> champions, AutoCompleteStringCollection names, int playerNumber)
        {
            PlayerView = playerView;
            PlayerNumber = playerNumber;
            this.helper = helper;

            PlayerView.Champions = champions;
            PlayerView.ExistingNames = names;

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
                Summoner summoner = helper.GetSummoner(PlayerView.PlayerName, PlayerNumber);

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
            string champName = PlayerView.SelectedChampion.key;

            string leagueFolder = helper.Settings.Get().LeagueFolder;

            PlayerView.ChampionIconPath = getChampImagesLocation(leagueFolder) + champName + CHAMP_IMAGES_SUFFIX;
        }

        private string getChampImagesLocation(string leagueFolder)
        {
            List<string> folders = Directory.GetDirectories(leagueFolder + CHAMP_IMAGES_LOCATION_PRE_RELEASES).ToList();

            string pattern = "\\d+.\\d+.\\d+.\\d+";

            foreach (string folder in folders)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(folder.Remove(0, leagueFolder.Length + CHAMP_IMAGES_LOCATION_PRE_RELEASES.Length), pattern))
                {
                    return folder + CHAMP_IMAGES_LOCATION_POST_RELEASES;
                }
            }

            return "";
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
            PlayerView.ChampionIconPath = "";
        }

    }
}
