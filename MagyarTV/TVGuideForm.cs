using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagyarTV
{
    public partial class TVGuideForm : Form
    {
        public TVGuideForm()
        {
            InitializeComponent();
        }

        private void TVGuideForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void TVGuideForm_Load(object sender, EventArgs e)
        {
            Database database = new Database();

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            bgwTVGuide.RunWorkerAsync();
        }

        #region TVGuide Background worker
        private void bgwTVGuide_DoWork(object sender, DoWorkEventArgs e)
        {
            MediaKlikk mediaKlikk = new MediaKlikk();
            Dictionary<string, Channel> channels = mediaKlikk.GetChannels();

            TVGuide tVGuide = new TVGuide();
            tVGuide.Initialize(channels);
        }

        private void bgwTVGuide_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //tVGuideToolStripMenuItem.Enabled = true;
        }
        #endregion

    }

}