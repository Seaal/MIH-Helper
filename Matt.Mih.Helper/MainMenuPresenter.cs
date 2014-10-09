using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
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
	    }

        private void OnSettingsItemClick(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        public void ShowSettingsForm()
        {
            SettingsForm settingsForm = new SettingsForm();
            SettingsManager settingsManager = Helper.SettingsManager;
            SettingsFormPresenter settingsPresenter = new SettingsFormPresenter(settingsForm, settingsManager);

            settingsForm.ShowDialog();

            Helper.LeagueRepository.ApiKey = settingsManager.Get().ApiKey;
            Helper.LeagueRepository.Region = settingsManager.Get().Region;
        }
    }
}
