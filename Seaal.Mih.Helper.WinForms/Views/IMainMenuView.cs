using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper.WinForms
{
    public interface IMainMenuView
    {
        event EventHandler SettingsClick;
        event EventHandler AboutClick;
    }
}
