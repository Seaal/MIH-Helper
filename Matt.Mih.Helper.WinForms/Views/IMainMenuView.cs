using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.WinForms
{
    public interface IMainMenuView
    {
        event EventHandler SettingsClick;
        event EventHandler AboutClick;
    }
}
