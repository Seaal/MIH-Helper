using Matt.Mih.Helper.LeagueApi;
using Ninject;
using Ninject.Modules;
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

            IKernel Kernel = new StandardKernel();
            NinjectModule Bindings = new Bindings();
            Kernel.Load(Bindings);

            ISettingsService settingsService = Kernel.Get<ISettingsService>();
            Kernel.Bind<ILeagueRepository>().To<LeagueRepository>().InSingletonScope().WithConstructorArgument("apiKey", settingsService.Get().ApiKey).WithConstructorArgument("region", settingsService.Get().Region);

            Helper helper = Kernel.Get<Helper>();
            MainForm mainForm = new MainForm();
            MainFormPresenter mainPresenter = new MainFormPresenter(mainForm, helper);

            Application.Run(mainForm);
        }
    }
}
