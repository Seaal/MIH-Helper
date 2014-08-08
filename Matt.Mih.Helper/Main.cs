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

        private void setChampDropDowns()
        {
            LeagueApiDAO leagueDao = new LeagueApiDAO();

            ChampionDTO champList = leagueDao.GetChampions();

            

            cbChampions1.DataSource = new BindingSource(champList.data, null);
            cbChampions1.DisplayMember = "Value";
            cbChampions1.ValueMember = "Key";
            cbChampions1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void tbPlayer1_Leave(object sender, EventArgs e)
        {
            LeagueApiDAO leagueDao = new LeagueApiDAO();

            if(tbPlayer1.Text!="")
            {
                Summoner sum = leagueDao.GetSummoner(tbPlayer1.Text);

                LeagueInfo league = leagueDao.GetLeagueInfo(sum.id);

                tbElo1.Text = league.tier + " " + league.entries.FirstOrDefault().division;

                Runepage runes = leagueDao.GetCurrentRunepage(sum.id);
            }
        }
    }
}
