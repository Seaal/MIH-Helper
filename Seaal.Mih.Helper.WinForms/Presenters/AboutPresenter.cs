using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seaal.Mih.Helper.WinForms
{
    class AboutPresenter
    {
        private readonly IAboutFormView AboutView;

        public AboutPresenter(IAboutFormView aboutView)
        {
            AboutView = aboutView;

            AboutView.Version = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            AboutView.CloseClick += new EventHandler(OnClose);
            AboutView.SourceLinkClick += new LinkLabelLinkClickedEventHandler(OnSourceLinkClick);
        }

        public void ShowDialog()
        {
            AboutView.ShowDialog();
        }

        private void OnClose(object sender, EventArgs e)
        {
            AboutView.Close();
        }

        private void OnSourceLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }
    }
}
