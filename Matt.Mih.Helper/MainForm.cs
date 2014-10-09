﻿using Matt.Mih.Helper.LeagueApi;
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
    public partial class MainForm : Form, IMainFormView
    {
        private readonly List<IPlayerView> PlayerViews;

        public MainForm()
        {
            InitializeComponent();

            if(Properties.Settings.Default.firstRun)
            {
                itSettings.PerformClick();

                Properties.Settings.Default.firstRun = false;
                Properties.Settings.Default.Save();
            }

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

        public List<IPlayerView> Players
        {
            get { return PlayerViews; }
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
            set { btnBalance.Text = value; }
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

        private void itSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            SettingsManager settingsManager = new SettingsManager();
            SettingsPresenter settingsPresenter = new SettingsPresenter(settingsForm, settingsManager);

            settingsForm.ShowDialog();

            //helper.LeagueRepository.ApiKey = settingsManager.Get().ApiKey;
            //helper.LeagueRepository.Region = settingsManager.Get().Region;
        }
    }
}
