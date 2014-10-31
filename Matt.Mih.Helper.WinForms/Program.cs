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

            SettingsService settingsService = new SettingsService();
            LeagueRepository leagueRepository = new LeagueRepository(settingsService.Get().ApiKey, settingsService.Get().Region);
            NameService nameService = new NameService();
            Helper helper = new Helper(leagueRepository, nameService, settingsService);
            MainForm mainForm = new MainForm();
            MainFormPresenter mainPresenter = new MainFormPresenter(mainForm, helper);

            Application.Run(mainForm);
        }
    }
}
