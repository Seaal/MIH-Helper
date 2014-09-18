using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper
{
    public partial class SettingsForm : Form
    {
        private TextBox tbApiKey;
        private FolderBrowserDialog fbLeagueFolder;
        private TextBox tbLeagueFolder;
        private Label lLeagueFolder;
        private Button btnLeagueFolder;
        private Button btnSave;
        private Button btnCancel;
        private Label lApiKey;

        public SettingsHandler SHandler { get; set; }

        public SettingsForm(SettingsHandler sHandler)
        {
            InitializeComponent();

            SHandler = sHandler;

            Settings settings = SHandler.Get();

            tbApiKey.Text = settings.ApiKey;
            tbLeagueFolder.Text = settings.LeagueFolder;
        }

        private void btnLeagueFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = fbLeagueFolder.ShowDialog();

            if(result == DialogResult.OK)
            {
                tbLeagueFolder.Text = fbLeagueFolder.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings()
            {
                ApiKey = tbApiKey.Text,
                LeagueFolder = tbLeagueFolder.Text
            };

            SHandler.Save(settings);

            this.Close();
        }
    }
}
