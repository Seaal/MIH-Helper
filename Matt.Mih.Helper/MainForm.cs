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

namespace Matt.Mih.Helper
{
    public partial class MainForm : Form
    {
        private readonly App app;

        public bool GameInProgress { get; set; }

        public MainForm()
        {
            InitializeComponent();

            app = new App();

            setChampDropDowns();

            GameInProgress = false;
        }

        private void setChampDropDowns()
        {

            Dictionary<string, Champion> champList = app.Champions;

            cbChampions0.DataSource = new BindingSource(champList, null);
            cbChampions0.DisplayMember = "Value";
            cbChampions0.ValueMember = "Key";
            cbChampions0.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void tbPlayer0_Leave(object sender, EventArgs e)
        {
            try
            {
                Summoner summoner = app.GetSummoner(tbPlayer0.Text, 0);

                tbElo0.Text = summoner.Tier + " " + summoner.Division;

                if(summoner.Level < 30)
                {
                    lError0.Text = "Warning: Player is level " + summoner.Level;
                }
                else
                {
                    lError0.Text = "";
                }
            }
            catch(WebException exception)
            {
                if(exception.Status == WebExceptionStatus.ProtocolError)
                {
                    lError0.Text = "Player not found";
                    tbElo0.Text = "";
                }
            }
            catch(ArgumentException exception)
            {
                lError0.Text = exception.Message;
                tbElo0.Text = "";
            }
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            BalanceResult result = app.BalanceTeams();
        }

        private void btnGameToggle_Click(object sender, EventArgs e)
        {
            if(GameInProgress == false)
            {
                btnGameToggle.Text = "Game Ended";
                btnBalance.Enabled = false;
                tbPlayer0.Enabled = false;
                cbChampions0.Enabled = false;
                GameInProgress = true;
            }
            else
            {
                btnGameToggle.Text = "Game Started";
                btnBalance.Enabled = true;
                tbPlayer0.Enabled = true;
                cbChampions0.Enabled = true;
                GameInProgress = false;
            }
        }
    }
}
