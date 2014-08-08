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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            setChampDropDowns();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string[] Ranks = { "Unranked", "Bronze V", "Bronze IV", "Bronze III", "Bronze II", "Bronze I", "Silver V", "Silver IV", "Silver III", "Silver II", "Silver I" };

            cbElo1.DataSource = Ranks;
            cbElo1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void setChampDropDowns()
        {
            LeagueApiDAO leagueDao = new LeagueApiDAO();

            ChampionDTO champList = leagueDao.GetChampions();

            Summoner sum = leagueDao.GetSummoner("9eq2yhf872g68rg y2gfyuwegyufg");

            cbChampions1.DataSource = new BindingSource(champList.data, null);
            cbChampions1.DisplayMember = "Value";
            cbChampions1.ValueMember = "Key";
            cbChampions1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
