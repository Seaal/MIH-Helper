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
        private readonly Helper helper;

        public int PlayerNumber { get; set; }

        public PlayerPanel(int playerNumber, Helper helper, Dictionary<String, Champion> champsList, AutoCompleteStringCollection summonerNamesAutoComplete)
        {
            Name = "PlayerPanel" + playerNumber;
            InitializeComponent(champsList, summonerNamesAutoComplete);
            PlayerNumber = playerNumber;
            this.helper = helper;
        }

        private void getPlayerSummoner(object sender, EventArgs e)
        {
            try
            {
                Summoner summoner = helper.GetSummoner(tbPlayer.Text, PlayerNumber);

                tbElo.Text = summoner.Tier + " " + summoner.Division;

                if (summoner.Level < 30)
                {
                    lError.Text = "Warning: Player is level " + summoner.Level;
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
                    lError.Text = "Player not found";
                    tbElo.Text = "";
                }
            }
            catch (ArgumentException exception)
            {
                lError.Text = exception.Message;
                tbElo.Text = "";
            }
        }
    }
}
