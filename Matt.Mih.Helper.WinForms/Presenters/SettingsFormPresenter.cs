﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper.WinForms
{
    class SettingsFormPresenter
    {
        private readonly ISettingsFormView SettingsView;
        private readonly ISettingsManager SettingsManager;
        private readonly IFolderBrowserManager FolderBrowserManager;
        private readonly IIconPathManager IconPathManager;

        public SettingsFormPresenter(ISettingsFormView settingsView, ISettingsManager settingsManager, IFolderBrowserManager folderBrowserManager, IIconPathManager iconPathManager)
        {
            SettingsView = settingsView;
            SettingsManager = settingsManager;
            FolderBrowserManager = folderBrowserManager;
            IconPathManager = iconPathManager;

            Settings settings = SettingsManager.Get();

            SettingsView.ApiKey = settings.ApiKey;
            SettingsView.LeagueFolder = settings.LeagueFolder;
            SettingsView.Regions = getRegions();
            SettingsView.Region = settings.Region;
            CheckLeagueFolderValid();

            if(settings.LeagueFolder != "")
            {
                FolderBrowserManager.SelectedPath = settings.LeagueFolder;
            }

            SettingsView.SaveClicked += new EventHandler(OnSaveButtonClicked);
            SettingsView.CancelClicked += new EventHandler(OnCancelButtonClicked);
            SettingsView.FindLeagueFolderClicked += new EventHandler(OnFindLeagueFolderClicked);
            SettingsView.LeagueFolderChanged += new EventHandler(OnLeagueFolderChanged);
        }

        private BindingSource getRegions()
        {
            Dictionary<string, string> regions = new Dictionary<string, string>();

            regions.Add("na", "North America");
            regions.Add("euw", "Europe West");
            regions.Add("eune", "Europe North & East");
            regions.Add("ru", "Russia");
            regions.Add("tr", "Turkey");
            regions.Add("kr", "Korea");
            regions.Add("oce", "Oceania");
            regions.Add("br", "Brazil");
            regions.Add("lan", "Latin America North");
            regions.Add("las", "Latin America South");

            return new BindingSource(regions, null);
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Settings settings = new Settings()
            {
                ApiKey = SettingsView.ApiKey,
                LeagueFolder = SettingsView.LeagueFolder,
                Region = SettingsView.Region
            };

            SettingsManager.Save(settings);

            SettingsView.Close();
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            SettingsView.Close();
        }

        private void OnFindLeagueFolderClicked(object sender, EventArgs e)
        {
            DialogResult result = FolderBrowserManager.ShowDialog();

            if (result == DialogResult.OK)
            {
                SettingsView.LeagueFolder = FolderBrowserManager.SelectedPath;
            }
        }

        private void OnLeagueFolderChanged(object sender, EventArgs e)
        {
            CheckLeagueFolderValid();
        }

        private void CheckLeagueFolderValid()
        {
            if (!IconPathManager.IsValidIconPath(SettingsView.LeagueFolder))
            {
                SettingsView.Error = "League of Legends Folder is not valid.";
            }
            else
            {
                SettingsView.Error = "";
            }
            }

        public void ShowDialog()
        {
            SettingsView.ShowDialog();
        }
    }
}