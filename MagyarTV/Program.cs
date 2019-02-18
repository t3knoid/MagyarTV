using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string tempFolder = Path.GetTempPath();
            string logFile = Path.Combine(tempFolder, String.Format("{0}.log", System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName));
            Logger logger = new Logger(logFile);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VideoPlayerForm() { Logger = logger });
        }
    }
}
