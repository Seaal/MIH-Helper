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

        public List<PlayerPresenter> PlayerPresenters { get; set; }

        public MainMenuPresenter (IMainMenuView mainMenuView, Helper helper, List<PlayerPresenter> playerPresenters)
	    {
            MainMenuView = mainMenuView;
            Helper = helper;
            PlayerPresenters = playerPresenters;

            MainMenuView.SettingsClick += new EventHandler(OnSettingsItemClick);
            MainMenuView.AboutClick += new EventHandler(OnAboutItemClick);
	    }

        private void OnSettingsItemClick(object sender, EventArgs e)
        {
            ShowSettingsForm(false);
        }

        public void ShowSettingsForm(bool showInTaskbar)
        {
            ISettingsFormView settingsForm = new SettingsForm();
            ISettingsManager settingsManager = Helper.SettingsManager;
            FolderBrowserManager folderBrowserManager = new FolderBrowserManager();
            IconPathManager iconPathManager = new IconPathManager();
            SettingsFormPresenter settingsPresenter = new SettingsFormPresenter(settingsForm, settingsManager, folderBrowserManager, iconPathManager);

            settingsForm.ShowInTaskbar = showInTaskbar;
            settingsPresenter.ShowDialog();

            Helper.LeagueRepository.ApiKey = settingsManager.Get().ApiKey;
            Helper.LeagueRepository.Region = settingsManager.Get().Region;

            if(Helper.Champions.Count != 0)
            {
                foreach(PlayerPresenter presenter in PlayerPresenters)
                {
                    presenter.Champions = Helper.Champions;
                }
            }
        }

        public void OnAboutItemClick(object sender, EventArgs e)
        {

        }
    }
}
