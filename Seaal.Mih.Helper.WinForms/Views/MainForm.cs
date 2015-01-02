using Seaal.Mih.Helper.LeagueApi;
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

namespace Seaal.Mih.Helper.WinForms
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly List<IPlayerView> PlayerViews;
        private readonly MainMenuView MainMenu;

        public MainForm()
        {
            MainMenu = new MainMenuView();
            Controls.Add(MainMenu);

            InitializeComponent();

            PlayerViews = new List<IPlayerView>(10);

            int playerViewHeight = 110;

            Size playerViewSize = new Size(150, playerViewHeight);

            for(int i=0;i<5;i++)
            {
                PlayerView panel = getPlayerView(20, i * (playerViewHeight + 5) + 40, playerViewSize);
                PlayerViews.Add(panel);
                Controls.Add(panel);
            }

            for (int i = 5; i < 10; i++)
            {
                PlayerView panel = getPlayerView(505, i * (playerViewHeight + 5) - (playerViewHeight + 5) * 5 + 40, playerViewSize);
                PlayerViews.Add(panel);
                Controls.Add(panel);
            }

            lSwap1.SendToBack();
            lSwap2.SendToBack();
            lRatingDifference.SendToBack();
            

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private PlayerView getPlayerView(int x, int y, Size size)
        {
            PlayerView panel = new PlayerView();
            panel.Size = size;
            panel.Location = new System.Drawing.Point(x, y);

            panel.AutoSize = true;
            panel.ResumeLayout(false);
            panel.PerformLayout();

            return panel;
        }

        public List<IPlayerView> PlayersView
        {
            get { return PlayerViews; }
        }

        public IMainMenuView MainMenuView
        {
            get { return MainMenu; }
        }

        public string Swap1
        {
            set { lSwap1.Text = value; }
        }

        public string Swap2
        {
            set { lSwap2.Text = value; }
        }

        public string RatingDifference
        {
            set { lRatingDifference.Text = value; }
        }

        public Color RatingDifferenceTextColor
        {
            set { lRatingDifference.ForeColor = value; }
        }

        public string BalanceButtonText
        {
            set { btnBalance.Text = value; }
        }

        public bool BalanceButtonEnabled
        {
            set { btnBalance.Enabled = value; }
        }

        public string GameToggleButtonText
        {
            set { btnGameToggle.Text = value; }
        }

        public bool ClearAllButtonEnabled
        {
            set { btnClear.Enabled = value; }
        }

        public event EventHandler BalanceTeamsClick
        {
            add { btnBalance.Click += value; }
            remove { btnBalance.Click -= value; }
        }

        public event EventHandler GameToggleClick
        {
            add { btnGameToggle.Click += value; }
            remove { btnGameToggle.Click -= value; }
        }

        public event EventHandler ClearAllClick
        {
            add { btnClear.Click += value; }
            remove { btnClear.Click -= value; }
        }
    }
}
