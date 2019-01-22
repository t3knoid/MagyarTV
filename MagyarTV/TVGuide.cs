using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace MagyarTV
{
    public partial class TVGuide : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public string Url { get; internal set; }

        public TVGuide()
        {
            InitializeComponent();
        }

        private void TVGuide_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();

            Cef.Initialize(settings);
            chromeBrowser = new ChromiumWebBrowser(Url);
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void TVGuide_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
