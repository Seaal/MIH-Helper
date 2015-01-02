using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seaal.Mih.Helper.WinForms
{
    public partial class SettingsForm : Form, ISettingsFormView
    {
        private TextBox tbApiKey;
        private TextBox tbLeagueFolder;
        private Label lLeagueFolder;
        private Button btnLeagueFolder;
        private Button btnSave;
        private Button btnCancel;
        private Label lApiKey;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public string ApiKey
        {
            get { return tbApiKey.Text; }
            set { tbApiKey.Text = value; }
        }

        public string LeagueFolder
        {
            get { return tbLeagueFolder.Text; }
            set { tbLeagueFolder.Text = value; }
        }

        public new string Region
        {
            get { return (string)cbRegion.SelectedValue; }
            set { cbRegion.SelectedValue = value; }
        }

        public BindingSource Regions
        {
            set { cbRegion.DataSource = value; }
        }

        public string Error
        {
            get { return lError.Text; }
            set { lError.Text = value; }
        }

        public event EventHandler SaveClicked
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }

        public event EventHandler CancelClicked
        {
            add { btnCancel.Click += value; }
            remove { btnCancel.Click -= value; }
        }

        public event EventHandler FindLeagueFolderClicked
        {
            add { btnLeagueFolder.Click += value; }
            remove { btnLeagueFolder.Click -= value; }
        }

        public event EventHandler LeagueFolderChanged
        {
            add { tbLeagueFolder.TextChanged += value; }
            remove { tbLeagueFolder.TextChanged -= value; }
        }
    }
}
