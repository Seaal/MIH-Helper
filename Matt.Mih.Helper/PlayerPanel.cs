using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper
{
    public partial class PlayerPanel : Panel
    {
        private TextBox tbElo;
        private Label lError;
        private TextBox tbPlayer;
        private ComboBox cbChampions;
        private PictureBox pbChampion;
        private readonly Helper helper;

        public int PlayerNumber { get; set; }

        public PlayerPanel(int playerNumber, Helper helper, Dictionary<String, Champion> champsList, AutoCompleteStringCollection summonerNamesAutoComplete)
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

        public void Swap(PlayerPanel otherPanel)
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
    }
}
