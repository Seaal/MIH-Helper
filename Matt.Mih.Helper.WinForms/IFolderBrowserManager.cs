using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper.WinForms
{
    public interface IFolderBrowserManager
    {
        DialogResult ShowDialog();
        string SelectedPath { set; get; }
    }
}
