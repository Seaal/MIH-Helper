using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seaal.Mih.Helper.WinForms
{
    public interface IFolderBrowserService
    {
        DialogResult ShowDialog();
        string SelectedPath { set; get; }
    }
}
