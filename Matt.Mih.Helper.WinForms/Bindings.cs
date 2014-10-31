using Matt.Mih.Helper.LeagueApi;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.WinForms
{
    class Bindings : NinjectModule
    {
        public override void Load()
        {
            //Views
            Bind<IMainFormView>().To<MainForm>();
            Bind<IMainMenuView>().To<MainMenuView>();
            Bind<IPlayerView>().To<PlayerView>();
            Bind<ISettingsFormView>().To<SettingsForm>();

            //Services
            Bind<IFolderBrowserService>().To<FolderBrowserService>();
            Bind<ISettingsService>().To<SettingsService>().InSingletonScope();
            Bind<IIconPathService>().To<IconPathService>();
            Bind<INameService>().To<NameService>().InSingletonScope();
        }
    }
}
