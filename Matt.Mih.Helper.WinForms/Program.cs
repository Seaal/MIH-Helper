using Matt.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SettingsManager settingsManager = new SettingsManager();
            LeagueRepository leagueRepository = new LeagueRepository(settingsManager.Get().ApiKey, settingsManager.Get().Region);
            NameManager nameManager = new NameManager();
            Helper helper = new Helper(leagueRepository, nameManager, settingsManager);
            MainForm mainForm = new MainForm();
            MainFormPresenter mainPresenter = new MainFormPresenter(mainForm, helper);

            Application.Run(mainForm);
        }
    }
}
