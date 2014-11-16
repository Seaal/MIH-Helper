using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper.WinForms
{
    interface IAboutFormView
    {
        string Version { get; set; }

        DialogResult ShowDialog();
        void Close();

        event EventHandler CloseClick;
        event LinkLabelLinkClickedEventHandler SourceLinkClick;
    }
}
