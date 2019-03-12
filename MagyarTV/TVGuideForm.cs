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
    }

}


