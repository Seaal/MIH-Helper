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
    public partial class PlayerView : UserControl, IPlayerView
    {
        private TextBox tbElo;
        private Label lError;
        private TextBox tbPlayer;
        private ComboBox cbChampions;
        private PictureBox pbChampion;

        public PlayerView()
        {
            InitializeComponent();

            BorderStyle = BorderStyle.FixedSingle;
        }

        public string PlayerName
        {
            get { return tbPlayer.Text; }
            set { tbPlayer.Text = value; }
        }

        public AutoCompleteStringCollection ExistingNames
        {
            set { tbPlayer.AutoCompleteCustomSource = value; }
        }

        public string Elo
        {
            get { return tbElo.Text; }
            set { tbElo.Text = value; }
        }

        public List<Champion> Champions
        {
            get { return (List<Champion>)cbChampions.DataSource; }
            set { cbChampions.DataSource = value; }
        }

        public string ChampionIconPath
        {
            set { pbChampion.ImageLocation = value; }
        }

        public int SelectedChampionIndex
        {
            get { return cbChampions.SelectedIndex; }
            set { cbChampions.SelectedIndex = value; }
        }

        public Champion SelectedChampion
        {
            get { return (Champion)cbChampions.SelectedItem; }
        }

        public string Error
        {
            get { return lError.Text; }
            set { lError.Text = value; }
        }

        public event EventHandler PlayerNameTextboxLeave
        {
            add { tbPlayer.Leave += value; }
            remove { tbPlayer.Leave -= value; }
        }

        public event EventHandler ChampionSelectedChanged
        {
            add { cbChampions.SelectedIndexChanged += value; }
            remove { cbChampions.SelectedIndexChanged -= value; }
        }
    }
}
