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
using Utilities;

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

        public Logger Logger { get; internal set; }

        public VideoPlayerForm()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void vlcControl2_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void VideoPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    break;
                case CloseReason.FormOwnerClosing:
                    break;
                case CloseReason.MdiFormClosing:
                    break;
                case CloseReason.None:
                    break;
                case CloseReason.WindowsShutDown:
                    break;
                case CloseReason.TaskManagerClosing:
                    break;
                case CloseReason.UserClosing:
                    var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        e.Cancel = false;
                        StopPlaying();
                        Logger.Info("Exiting.");
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    break;
                default:
                    break;
            }
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
        #endregion

        #region Menu Handlers
        private void schedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> channelList = new List<string>();
            foreach (KeyValuePair<string, Channel> ch in channels)
            {
                channelList.Add(ch.Value.Name);
            }
            ScheduleRecordingForm scheduleRecording = new ScheduleRecordingForm() { Channels = channelList };
            scheduleRecording.Show();
            ScheduleItem scheduleItem = scheduleRecording.ScheduleItem;
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Play(currentChannel);
        }
        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Record();
        }
        #endregion

        #region Media Controls
        private void btStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void btPlay_Click(object sender, EventArgs e)
        {
            Play(currentChannel);
        }
        private void btRecord_Click(object sender, EventArgs e)
        {
            Record();
        }
        private void btChannel_Click(object sender, EventArgs e)
        {
            var channelButton = (Button)sender;
            Play(channels[channelButton.Text]);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Helper methods
        private void Record()
        {
            recordingWorker = new BackgroundWorker();
            recordingWorker.DoWork += new DoWorkEventHandler(Record_Worker); // This does the job ...
            recordingWorker.WorkerSupportsCancellation = true; // This allows cancellation.
            recordingWorker.RunWorkerAsync(currentChannel);
        }
        private void Stop()
        {
            if (currentChannel.IsRecording)
            {
                StopRecording();
            }
            else
            {
                StopPlaying();
            }
        }
        private void StopRecording()
        {
            var result = MessageBox.Show("Are you sure you want to stop recording?", "Stop Recording", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Logger.Info(String.Format("Stopped recording channel {0}.", currentChannel.Name));
                recordingWorker.CancelAsync(); // Stops recording thread
            }
        }
        private void StopPlaying()
        {
            currentChannel.IsPlaying = false;
            Logger.Info(String.Format("Stopping channel {0}.", currentChannel.Name));
            mediaPlayer.Stop();
        }
        private void Play(Channel channel)
        {
            currentChannel = channel;
            if (currentChannel.IsRecording)
            {
                recordingWorker.CancelAsync(); // Stops recording thread
            }
            currentChannel.IsPlaying = false;
            mediaPlayer.Stop();
            currentChannel.IsPlaying = true;
            currentChannel.StreamInfo = new VideoMetadata() { Title = currentChannel.Name };

            Logger.Info(String.Format("Playing channel {0}.", currentChannel.Name));
            mediaPlayer.Play(new Uri(currentChannel.URI.TrimEnd('\r', '\n')));
        }
        #endregion

        #region Background worker
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
                    var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
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
                        Logger.Info(String.Format("Recording channel {0} to {1}.", currentChannel.Name, destination));
                        if (backgroundWorker != null)
                        {
                            while (!backgroundWorker.CancellationPending)
                            {
                                // Update
                            }
                            if (backgroundWorker.CancellationPending)
                            {
                                Logger.Info(String.Format("Canelled recording channel {0}.", currentChannel.Name));
                                btRecord.ForeColor = Color.Black;
                                e.Cancel = true;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to start recording");
                Logger.Error(ex);
                MessageBox.Show(String.Format("Failed to start recording. {0}", ex.Message));
            }
        }
        #endregion
    }
}
