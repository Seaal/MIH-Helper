using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper.WinForms
{
    class FolderBrowserManager : IFolderBrowserManager
    {
        private readonly FolderBrowserDialog FolderBrowserDialog;

        public string SelectedPath
        {
            set { FolderBrowserDialog.SelectedPath = value; }
            get { return FolderBrowserDialog.SelectedPath; }
        }

        public FolderBrowserManager()
	    {
            FolderBrowserDialog = new FolderBrowserDialog();

            FolderBrowserDialog.Description = "Find your \"League of Legends\" Folder.";
            FolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            FolderBrowserDialog.ShowNewFolderButton = false;
	    }

        public DialogResult ShowDialog()
        {
            return FolderBrowserDialog.ShowDialog();
        }
        
    }
}
