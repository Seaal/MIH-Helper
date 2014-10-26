using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper.WinForms
{
    public interface ISettingsFormView
    {
        string ApiKey { get; set; }
        string LeagueFolder { get; set; }
        string Region { get; set; }
        BindingSource Regions { set; }

        event EventHandler SaveClicked;
        event EventHandler CancelClicked;
        event EventHandler FindLeagueFolderClicked;

        void Close();
        DialogResult ShowDialog();
    }
}
