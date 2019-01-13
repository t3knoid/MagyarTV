using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;

namespace MagyarTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            mediaPlayer.Play(new Uri("https://c402-node61-cdn.connectmedia.hu/1101/aa593f5f6f87c393ef784aaee8bc249c/5c3ab9c5/02.m3u8"));
        }

        private void vlcControl2_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btRecord_Click(object sender, EventArgs e)
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var libDirectory =
              new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            var destination = Path.Combine(currentDirectory, "record.ts");

            /// New definition of mediaPlayer
            using (var mediaPlayer1 = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory))
            {

                var mediaOptions = new[]
                {
                    ":sout=#file{dst=" + destination + "}",
                    ":sout-keep"
                };

                mediaPlayer1.SetMedia(new Uri("https://c402-node61-cdn.connectmedia.hu/1101/aa593f5f6f87c393ef784aaee8bc249c/5c3ab9c5/02.m3u8"),
                    mediaOptions);

                mediaPlayer1.Play();
                // Need a timer to keep recording
                MessageBox.Show("Recording");
            }
        }
    }
}
