using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper.WinForms
{
    class MainMenuPresenter
    {
        private readonly IMainMenuView MainMenuView;
        private readonly Helper Helper;
        private readonly MainFormPresenter MainFormPresenter;

        public MainMenuPresenter(IMainMenuView mainMenuView, Helper helper, MainFormPresenter mainFormPresenter)
	    {
            MainMenuView = mainMenuView;
            Helper = helper;
            MainFormPresenter = mainFormPresenter;

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
            ISettingsService settingsService = Helper.SettingsService;
            FolderBrowserService folderBrowserService = new FolderBrowserService();
            IconPathService iconPathService = new IconPathService();
            SettingsFormPresenter settingsPresenter = new SettingsFormPresenter(settingsForm, settingsService, folderBrowserService, iconPathService);

            settingsForm.ShowInTaskbar = showInTaskbar;
            settingsPresenter.ShowDialog();

            Helper.LeagueRepository.ApiKey = settingsService.Get().ApiKey;
            Helper.LeagueRepository.Region = settingsService.Get().Region;

            MainFormPresenter.SetChampions();
        }

        public void OnAboutItemClick(object sender, EventArgs e)
        {

        }
    }
}
