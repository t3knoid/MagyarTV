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
using System.Diagnostics;

namespace MagyarTV
{
    public partial class VideoPlayerForm : Form
    {
        Channel currentChannel;
        Recording currentRecording = new Recording();
        Dictionary<string, Channel> channels = new Dictionary<string, Channel>();

        BackgroundWorker recordingWorker;
        public BackgroundWorker RecordingWorker
        {
            get
            {
                return recordingWorker;
            }
        }

        public VideoPlayerForm()
        {
            InitializeComponent();
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            currentChannel.IsPlaying = true;
            currentChannel.StreamInfo = new VideoMetadata() { Title = currentChannel.Name };
            mediaPlayer.Play(new Uri(currentChannel.URI.TrimEnd('\r', '\n')));
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
            if (currentChannel.IsRecording)
            {
                recordingWorker.CancelAsync(); // Stops recording thread
            }
            currentChannel.IsPlaying = false;
            mediaPlayer.Stop();
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btRecord_Click(object sender, EventArgs e)
        {
            recordingWorker = new BackgroundWorker();
            recordingWorker.DoWork += new DoWorkEventHandler(Record_Worker); // This does the job ...
            recordingWorker.WorkerSupportsCancellation = true; // This allows cancellation.
            recordingWorker.RunWorkerAsync(currentChannel);
        }

        private void Record_Worker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            Channel channel = (Channel)e.Argument;
            VideoMetadata videoMetadata = new VideoMetadata();
            try
            {
                // Check if current channel is playing before trying to record
                if (currentChannel.IsPlaying)
                {
                    var currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    var libDirectory =
                      new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

                    var destination = Path.Combine(currentDirectory, channel.StreamInfo.Title + ".ts");

                    /// New definition of mediaPlayer
                    using (var mediaRecorder = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory))
                    {

                        var mediaOptions = new[]
                        {
                            ":sout=#file{dst=" + destination + "}",
                            ":sout-keep"
                        };

                        currentChannel.IsRecording = true;
                        mediaRecorder.SetMedia(new Uri(channel.URI), mediaOptions);
                        btRecord.ForeColor = Color.Red;
                        mediaRecorder.Play();
                        currentRecording.Channel = channel;
                        if (backgroundWorker != null)
                        {
                            while (!backgroundWorker.CancellationPending)
                            {
                                // Update
                            }
                            if (backgroundWorker.CancellationPending)
                            {
                                btRecord.ForeColor = Color.Black;
                                e.Cancel = true;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Failed to start recording. {0}", ex.Message));
            }
        }

        private void btChannel_Click(object sender, EventArgs e)
        {
            var channelName = (Button)sender;
            currentChannel = channels[channelName.Text];
            if (currentChannel.IsRecording)
            {
                recordingWorker.CancelAsync(); // Stops recording thread
            }
            currentChannel.IsPlaying = false;
            mediaPlayer.Stop();
            currentChannel.IsPlaying = true;
            currentChannel.StreamInfo = new VideoMetadata() { Title = currentChannel.Name };
            mediaPlayer.Play(new Uri(currentChannel.URI.TrimEnd('\r', '\n')));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChannel.IsRecording)
            {
                recordingWorker.CancelAsync(); // Stops recording thread
            }
            currentChannel.IsPlaying = false;
            mediaPlayer.Stop();
            Application.Exit();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChannel.IsRecording)
            {
                recordingWorker.CancelAsync(); // Stops recording thread
            }
            currentChannel.IsPlaying = false;
            mediaPlayer.Stop();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //currentChannel.URI = GetChannelURI(currentChannel);
            currentChannel.IsPlaying = true;
            currentChannel.StreamInfo = new VideoMetadata() { Title = "Test video title" };
            mediaPlayer.Play(new Uri(currentChannel.URI.TrimEnd('\r', '\n')));
        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recordingWorker = new BackgroundWorker();
            recordingWorker.DoWork += new DoWorkEventHandler(Record_Worker); // This does the job ...
            recordingWorker.WorkerSupportsCancellation = true; // This allows cancellation.
            recordingWorker.RunWorkerAsync(currentChannel);
        }

        private void VideoPlayerForm_Resize(object sender, EventArgs e)
        {
            // Keep the video control center on the mediaPlayer when resized
            this.flowLayoutPanel1.Location = new System.Drawing.Point((this.mediaPlayer.Width / 2) - (this.flowLayoutPanel1.Width / 2) + 12, this.mediaPlayer.Bottom + 6);
        }

        private void VideoPlayerForm_Load(object sender, EventArgs e)
        {
            // Center control buttons
            this.flowLayoutPanel1.Location = new System.Drawing.Point((this.mediaPlayer.Width / 2) - (this.flowLayoutPanel1.Width / 2) + 12, this.mediaPlayer.Bottom + 6);

            // Get channels
            channels = Channels.GetChannels();
            currentChannel = channels["M1"];
        }

        private void schedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            List<string> channelList = new List<string>();
            foreach (KeyValuePair<string, Channel> ch in channels)
            {
                channelList.Add(ch.Value.Name);
            }
            ScheduleRecordingForm scheduleRecording = new ScheduleRecordingForm() { Channels = channelList };
            scheduleRecording.Show();
        }
    }
}
