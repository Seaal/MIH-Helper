using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.WinForms
{
    class MainMenuPresenter
    {
        private readonly IMainMenuView MainMenuView;
        private readonly Helper Helper;

        public MainMenuPresenter (IMainMenuView mainMenuView, Helper helper)
	    {
            MainMenuView = mainMenuView;
            Helper = helper;

            MainMenuView.SettingsClick += new EventHandler(OnSettingsItemClick);
            MainMenuView.AboutClick += new EventHandler(OnAboutItemClick);
	    }

        private void OnSettingsItemClick(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        public void ShowSettingsForm()
        {
            ISettingsFormView settingsForm = new SettingsForm();
            ISettingsManager settingsManager = Helper.SettingsManager;
            FolderBrowserManager folderBrowserManager = new FolderBrowserManager();
            IconPathManager iconPathManager = new IconPathManager();
            SettingsFormPresenter settingsPresenter = new SettingsFormPresenter(settingsForm, settingsManager, folderBrowserManager, iconPathManager);

            settingsPresenter.ShowDialog();

            Helper.LeagueRepository.ApiKey = settingsManager.Get().ApiKey;
            Helper.LeagueRepository.Region = settingsManager.Get().Region;
        }

        public void OnAboutItemClick(object sender, EventArgs e)
        {

        }
    }
}
