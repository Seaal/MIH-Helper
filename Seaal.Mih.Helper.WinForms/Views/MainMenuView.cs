using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seaal.Mih.Helper.WinForms
{
    public partial class MainMenuView : UserControl, IMainMenuView
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        public event EventHandler SettingsClick
        {
            add { itSettings.Click += value; }
            remove { itSettings.Click -= value; }
        }

        public event EventHandler AboutClick
        {
            add { itAbout.Click += value; }
            remove { itAbout.Click -= value; }
        }

        public event EventHandler HelpClick
        {
            add { itHelp.Click += value; }
            remove { itHelp.Click -= value; }
        }
    }
}
