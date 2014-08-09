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

        public MainForm()
        {
            InitializeComponent();

            app = new App();

            setChampDropDowns();
        }

        private void setChampDropDowns()
        {

            Dictionary<string, Champion> champList = app.Champions;

            cbChampions0.DataSource = new BindingSource(champList, null);
            cbChampions0.DisplayMember = "Value";
            cbChampions0.ValueMember = "Key";
            cbChampions0.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void tbPlayer1_Leave(object sender, EventArgs e)
        {
            try
            {
                Summoner summoner = app.GetSummoner(tbPlayer0.Text, 0);

                tbElo0.Text = summoner.Tier + " " + summoner.Division;
            }
            catch(WebException exception)
            {
                if(exception.Status == WebExceptionStatus.ProtocolError)
                {
                    lError0.Text = "Player not found";
                }
            }
        }

        private void btnGameToggle_Click(object sender, EventArgs e)
        {

        }

        private void tbElo1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
