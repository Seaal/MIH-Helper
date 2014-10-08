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

        public SettingsManager SHandler { get; set; }



        public SettingsForm(SettingsManager sHandler)
        {
            InitializeComponent();

            SHandler = sHandler;

            Settings settings = SHandler.Get();

            cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRegion.DataSource = getRegions();
            cbRegion.DisplayMember = "Value";
            cbRegion.ValueMember = "Key";

            tbApiKey.Text = settings.ApiKey;
            tbLeagueFolder.Text = settings.LeagueFolder;
            cbRegion.SelectedValue = settings.Region;
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
                LeagueFolder = tbLeagueFolder.Text,
                Region = (string)cbRegion.SelectedValue
            };

            SHandler.Save(settings);

            this.Close();
        }
    }
}
