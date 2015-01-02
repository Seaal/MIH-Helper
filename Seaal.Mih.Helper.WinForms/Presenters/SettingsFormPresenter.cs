using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seaal.Mih.Helper.WinForms
{
    class SettingsFormPresenter
    {
        private readonly ISettingsFormView SettingsView;
        private readonly ISettingsService SettingsService;
        private readonly IFolderBrowserService FolderBrowserService;
        private readonly IIconPathService IconPathService;

        public SettingsFormPresenter(ISettingsFormView settingsView, ISettingsService settingsService, IFolderBrowserService folderBrowserService, IIconPathService iconPathService)
        {
            SettingsView = settingsView;
            SettingsService = settingsService;
            FolderBrowserService = folderBrowserService;
            IconPathService = iconPathService;

            Settings settings = SettingsService.Get();

            SettingsView.ApiKey = settings.ApiKey;
            SettingsView.LeagueFolder = settings.LeagueFolder;
            SettingsView.Regions = getRegions();
            SettingsView.Region = settings.Region;
            CheckLeagueFolderValid();

            if(settings.LeagueFolder != "")
            {
                FolderBrowserService.SelectedPath = settings.LeagueFolder;
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

            SettingsService.Save(settings);

            SettingsView.Close();
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            SettingsView.Close();
        }

        private void OnFindLeagueFolderClicked(object sender, EventArgs e)
        {
            DialogResult result = FolderBrowserService.ShowDialog();

            if (result == DialogResult.OK)
            {
                SettingsView.LeagueFolder = FolderBrowserService.SelectedPath;
            }
        }

        private void OnLeagueFolderChanged(object sender, EventArgs e)
        {
            CheckLeagueFolderValid();
        }

        private void CheckLeagueFolderValid()
        {
            if (!IconPathService.IsValidIconPath(SettingsView.LeagueFolder))
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
