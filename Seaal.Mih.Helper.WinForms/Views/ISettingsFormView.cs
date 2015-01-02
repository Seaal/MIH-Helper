using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seaal.Mih.Helper.WinForms
{
    public interface ISettingsFormView
    {
        string ApiKey { get; set; }
        string LeagueFolder { get; set; }
        string Region { get; set; }
        BindingSource Regions { set; }
        string Error { get; set; }
        bool ShowInTaskbar { get; set; }

        event EventHandler SaveClicked;
        event EventHandler CancelClicked;
        event EventHandler FindLeagueFolderClicked;
        event EventHandler LeagueFolderChanged;

        void Close();
        DialogResult ShowDialog();
    }
}
