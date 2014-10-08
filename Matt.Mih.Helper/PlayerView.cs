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
    public partial class PlayerView : UserControl
    {
        private readonly string CHAMP_IMAGES_LOCATION_PRE_RELEASES = @"\RADS\projects\lol_air_client\releases\";
        private readonly string CHAMP_IMAGES_LOCATION_POST_RELEASES = @"\deploy\assets\images\champions\";
        private readonly string CHAMP_IMAGE_SUFFIX = "_Square_0.png";

        private TextBox tbElo;
        private Label lError;
        private TextBox tbPlayer;
        private ComboBox cbChampions;
        private PictureBox pbChampion;
        private readonly Helper helper;

        public int PlayerNumber { get; set; }

        public PlayerView(int playerNumber, Helper helper, Dictionary<String, Champion> champsList, AutoCompleteStringCollection summonerNamesAutoComplete)
        {
            Name = "PlayerPanel" + playerNumber;
            InitializeComponent(champsList, summonerNamesAutoComplete);
            PlayerNumber = playerNumber;
            this.helper = helper;
            BorderStyle = BorderStyle.FixedSingle;
        }

        private void getPlayerSummoner(object sender, EventArgs e)
        {
            try
            {
                Summoner summoner = helper.GetSummoner(tbPlayer.Text, PlayerNumber);

                tbElo.Text = summoner.Tier + " " + summoner.Division;

                if (summoner.Level < 30)
                {
                    lError.Text = "Warning: Player is level " + summoner.Level + ".";
                }
                else
                {
                    lError.Text = "";
                }
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    switch(((HttpWebResponse)exception.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound :
                            lError.Text = "Player not found.";
                            break;
                        case HttpStatusCode.Unauthorized :
                            lError.Text = "Unauthorized, check your API key.";
                            break;
                        case HttpStatusCode.BadRequest :
                            lError.Text = "Bad Request, try again later.";
                            break;
                        case HttpStatusCode.ServiceUnavailable :
                        case HttpStatusCode.InternalServerError :
                            lError.Text = "API unavailable, try again later.";
                            break;
                        case (HttpStatusCode)429:
                            lError.Text = "API limit reached, try again.";
                            break;
                        default:
                            lError.Text = "An error has occurred.";
                            break;
                    }    
                }
                else
                {
                    lError.Text = "An error has occurred.";
                }

                tbElo.Text = "";
            }
            catch (ArgumentException exception)
            {
                lError.Text = exception.Message;
                tbElo.Text = "";
            }
        }

        private void changeChampionPicture(object sender, EventArgs e)
        {
            string champName = ((KeyValuePair<string, Champion>)cbChampions.SelectedItem).Key;

            string leagueFolder = helper.Settings.Get().LeagueFolder;

            pbChampion.ImageLocation = getChampImagesLocation(leagueFolder) + champName + CHAMP_IMAGE_SUFFIX;
        }

        private string getChampImagesLocation(string leagueFolder)
        {
            List<string> folders = Directory.GetDirectories(leagueFolder + CHAMP_IMAGES_LOCATION_PRE_RELEASES).ToList();

            string pattern = "\\d+.\\d+.\\d+.\\d+";

            foreach(string folder in folders)
            {
                if(System.Text.RegularExpressions.Regex.IsMatch(folder.Remove(0, leagueFolder.Length + CHAMP_IMAGES_LOCATION_PRE_RELEASES.Length), pattern))
                {
                    return folder + CHAMP_IMAGES_LOCATION_POST_RELEASES;
                }
            }

            return "";
        }

        public void Swap(PlayerView otherPanel)
        {
            string tempName = otherPanel.tbPlayer.Text;
            string tempElo = otherPanel.tbElo.Text;
            string tempError = otherPanel.lError.Text;
            int tempChampIndex = otherPanel.cbChampions.SelectedIndex;

            otherPanel.tbPlayer.Text = tbPlayer.Text;
            otherPanel.tbElo.Text = tbElo.Text;
            otherPanel.lError.Text = lError.Text;
            otherPanel.cbChampions.SelectedIndex = cbChampions.SelectedIndex;

            tbPlayer.Text = tempName;
            tbElo.Text = tempElo;
            lError.Text = tempError;
            cbChampions.SelectedIndex = tempChampIndex;
        }

        public void Clear()
        {
            tbPlayer.Text = "";
            tbElo.Text = "";
            cbChampions.SelectedIndex = 0;
            lError.Text = "";
            pbChampion.ImageLocation = "";
        }
    }
}
