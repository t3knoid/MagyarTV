using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logger = Utilities.Logger;

namespace MagyarTV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Logger logger = new Logger(Path.Combine(Path.GetTempPath(), String.Format("{0}.log",System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VideoPlayerForm() { Logger = logger });
        }
    }
}
