﻿using System;
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
using CefSharp.WinForms;
using System.Net;

namespace MagyarTV
{
    public partial class VideoPlayerForm : Form
    {
        Channel currentChannel;
        Button currentChannelButton;
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
                        Stop();
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
            MediaKlikk mediaKlikk = new MediaKlikk();
            channels = mediaKlikk.GetChannels();
            currentChannel = channels["M1"];
            currentChannelButton = btM1;
        }
        #endregion

        #region Menu Handlers
        private void schedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordingSchedulesForm recordingSchedulesForm = new RecordingSchedulesForm();
            recordingSchedulesForm.ShowDialog();
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Play();
        }
        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChannel.IsPlaying)
            {
                Record();
            }
        }
        private void tVGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string urlstring = String.Format("http://tv.animare.hu/default.aspx?t={0}", today);

            TVGuide tVGuide = new TVGuide() { Url = urlstring };
            tVGuide.Show();
        }

        #endregion

        #region Media Controls
        private void btStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void btPlay_Click(object sender, EventArgs e)
        {
            if (!currentChannel.IsPlaying)
            {
                currentChannelButton.Select();
                currentChannelButton.PerformClick();
            }
        }
        private void btRecord_Click(object sender, EventArgs e)
        {
            if (currentChannel.IsPlaying)
            {
                Record();
            }
        }
        private void btChannel_Click(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            Logger.Info(string.Format("Selected {0} channel to play.", selectedButton.Text));
            selectedButton.MouseLeave -= new System.EventHandler(this.buttonMouseLeave); // Temporarily stop mouseleave event handler
            selectedButton.ImageIndex = 1;
            if (!currentChannel.IsPlaying || (selectedButton.Text != currentChannelButton.Text))
            {
                if (currentChannel.IsRecording)
                {
                    var result = MessageBox.Show("Are you sure you want to stop recording?", "Stop Recording", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        StopRecording();
                        StopPlaying();
                        currentChannelButton = selectedButton;
                        currentChannel = channels[selectedButton.Text];
                        Play();
                    }
                    else
                    {
                        currentChannelButton.Select();
                    }

                }
                else
                {
                    StopPlaying();
                    currentChannelButton = (Button)sender;
                    currentChannel = channels[currentChannelButton.Text];
                    Play();
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Helper methods
        private void Record()
        {
            if (!currentChannel.IsRecording)
            {
                recordingWorker = new BackgroundWorker();
                recordingWorker.DoWork += new DoWorkEventHandler(Record_Worker); // This does the job ...
                recordingWorker.WorkerSupportsCancellation = true; // This allows cancellation.
                recordingWorker.RunWorkerAsync(currentChannel);
                //btRecord.Enabled = false;
                this.recordToolStripMenuItem.Enabled = false;
            }
        }
        private void Stop()
        {
            if (currentChannel.IsRecording)
            {
                var result = MessageBox.Show("Are you sure you want to stop recording?", "Stop Recording", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    StopRecording();
                    StopPlaying();
                }
            }
            else
            {
                StopPlaying();
            }
        }

        private void StopRecording()
        {
            Logger.Info(String.Format("Stopped recording channel {0}.", currentChannel.Name));
            recordingWorker.CancelAsync(); // Stops recording thread
            btRecord.ForeColor = Color.Black;
            currentChannel.IsRecording = false;
            //btRecord.Enabled = true;
            this.recordToolStripMenuItem.Enabled = true;
        }

        private void StopPlaying()
        {
            currentChannel.IsPlaying = false;
            Logger.Info(String.Format("Stopping channel {0}.", currentChannel.Name));
            mediaPlayer.Stop();
            currentChannelButton.ForeColor = Color.Transparent;
            currentChannelButton.ImageIndex = 0;
            currentChannelButton.FlatAppearance.BorderColor = Color.White;
            //this.btPlay.Enabled = true;
            this.playToolStripMenuItem.Enabled = true;
        }
        private void Play()
        {
            currentChannel.IsPlaying = true;
            currentChannel.StreamInfo = new VideoMetadata() { Title = currentChannel.Name };
            string error = String.Empty;
            Logger.Info(String.Format("Playing channel {0}.", currentChannel.Name));
            try
            {
                MediaKlikk mediaKlikk = new MediaKlikk();
                Uri url = new Uri(mediaKlikk.GetChannelURI(currentChannel.IndexFeed).TrimEnd('\r', '\n')); // Gets the m3u8 URL.
                error = mediaKlikk.StandardError.ToString();
                Logger.Info(string.Format("URI={0}", url));

                // Parse out all streams from the m3u8 
                WebResponse response = null;
                StreamReader reader = null;

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    response = request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    Dictionary<string, Streams> streams = new Dictionary<string, Streams>();
                    
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("#EXT-X-STREAM-INF"))  // #EXT-X-STREAM-INF:PROGRAM-ID=1,BANDWIDTH=468677,CODECS="avc1.42c00d,mp4a.40.2",RESOLUTION=320x180
                        {
                            string[] properties = line.Split(':')[1].Split(',');   // PROGRAM-ID=1,BANDWIDTH=468677,CODECS="avc1.42c00d,mp4a.40.2",RESOLUTION=320x180
                            string programid = Array.Find(properties, s => s.StartsWith("PROGRAM-ID=")).Split('=')[1]; // 1
                            string bandwidth = Array.Find(properties, s => s.StartsWith("BANDWIDTH=")).Split('=')[1]; // 468677
                            string codecs = Array.Find(properties, s => s.StartsWith("CODECS=")).Split('=')[1]; // "avc1.42c00d,mp4a.40.2"
                            string resolution = Array.Find(properties, s => s.StartsWith("RESOLUTION=")).Split('=')[1]; // 320x180                          
                            string page = reader.ReadLine();      // 05.m3u8
                            Uri uri = new Uri(url, ".");
                            streams.Add(resolution, new Streams()
                            {
                                ProgramID = programid,
                                Bandwidth = bandwidth,
                                Codecs = codecs,
                                Resolution = resolution,
                                Uri = new Uri(uri,page),
                            } );
                        }
                    }
                }
                catch (Exception ex)
                {
                    // handle error
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                    if (response != null)
                        response.Close();
                }

                // At this point the streams dictionary contains all the streams in order of lowest to highest

                mediaPlayer.Play(url);
                currentChannelButton.ForeColor = Color.LightGreen;
                currentChannelButton.ImageIndex = 1;
                this.playToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Failed playing channel {0}. {1}.", currentChannel.Name, error));
                Logger.Error(ex);
                Stop();
                MessageBox.Show(String.Format("Error playing {0}. {1}. {2}", currentChannel.Name, error, ex.Message));
            }
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
                    var destinationDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "MagyarTV");
                    if (!File.Exists(destinationDir))
                    {
                        try
                        {
                            Directory.CreateDirectory(destinationDir);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex);
                        }
                        
                    }
                    var destination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "MagyarTV", channel.StreamInfo.Title + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".ts");
                    /// New definition of mediaPlayer
                    using (var mediaRecorder = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory))
                    {
                        var mediaOptions = new[]
                        {
                            ":sout=#file{dst=" + destination + "}",
                            ":sout-keep"
                        };
                        currentChannel.IsRecording = true;
                        MediaKlikk mediaKlikk = new MediaKlikk();
                        mediaRecorder.SetMedia(new Uri(mediaKlikk.GetChannelURI(currentChannel.IndexFeed)), mediaOptions);
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

        private void buttonMouseHover(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            selectedButton.ImageIndex = 1;
        }

        private void buttonMouseLeave(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            selectedButton.ImageIndex = 0;
        }
    }
}
