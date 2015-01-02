using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt.Mih.Helper.WinForms
{
    public partial class AboutForm : Form, IAboutFormView
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        public string Version
        {
            get { return lVersion.Text; }
            set { lVersion.Text = value; }
        }

        public event EventHandler CloseClick
        {
            add { btnClose.Click += value; }
            remove { btnClose.Click -= value; }
        }

        public event LinkLabelLinkClickedEventHandler SourceLinkClick
        {
            add { llSourceLink.LinkClicked += value; }
            remove { llSourceLink.LinkClicked -= value; }
        }
    }
}
