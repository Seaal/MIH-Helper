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
        private readonly App app;

        public bool GameInProgress { get; set; }

        public MainForm()
        {
            InitializeComponent();

            app = new App();

            setChampDropDowns();

            GameInProgress = false;
            
            AutoCompleteStringCollection summonerNamesAutoComplete = new AutoCompleteStringCollection();

            XDocument summonerNames = XDocument.Load("names.xml");

            String[] names = (from name in summonerNames.Descendants("Name")
                              select (string)name).ToArray();

            summonerNamesAutoComplete.AddRange(names);

            tbPlayer0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbPlayer0.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbPlayer0.AutoCompleteCustomSource = summonerNamesAutoComplete;

            this.ResumeLayout(false);
            this.PerformLayout();
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
            if(GameInProgress == false)
            {
                btnGameToggle.Text = "Game Ended";
                lSwap1.Text = "";
                lSwap2.Text = "";
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
