namespace MagyarTV
{
    partial class VideoPlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tVGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaPlayer = new Vlc.DotNet.Forms.VlcControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btStop = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            this.btRecord = new System.Windows.Forms.Button();
            this.imageListM1 = new System.Windows.Forms.ImageList(this.components);
            this.imageListM2 = new System.Windows.Forms.ImageList(this.components);
            this.btDunaWorld = new System.Windows.Forms.Button();
            this.imageListDunaWorld = new System.Windows.Forms.ImageList(this.components);
            this.btDuna = new System.Windows.Forms.Button();
            this.imageDuna = new System.Windows.Forms.ImageList(this.components);
            this.btM5 = new System.Windows.Forms.Button();
            this.imageListM5 = new System.Windows.Forms.ImageList(this.components);
            this.btM4 = new System.Windows.Forms.Button();
            this.imageListM4 = new System.Windows.Forms.ImageList(this.components);
            this.btM2 = new System.Windows.Forms.Button();
            this.btM1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.bgwGetURI = new System.ComponentModel.BackgroundWorker();
            this.bgwRecording = new System.ComponentModel.BackgroundWorker();
            this.bgwTVGuide = new System.ComponentModel.BackgroundWorker();
            this.channelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopToolStripMenuItem,
            this.playToolStripMenuItem,
            this.recordToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.recordToolStripMenuItem.Text = "Record";
            this.recordToolStripMenuItem.Click += new System.EventHandler(this.recordToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.schedulerToolStripMenuItem,
            this.tVGuideToolStripMenuItem,
            this.resolutionToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // schedulerToolStripMenuItem
            // 
            this.schedulerToolStripMenuItem.Name = "schedulerToolStripMenuItem";
            this.schedulerToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.schedulerToolStripMenuItem.Text = "Scheduler";
            this.schedulerToolStripMenuItem.Click += new System.EventHandler(this.schedulerToolStripMenuItem_Click);
            // 
            // tVGuideToolStripMenuItem
            // 
            this.tVGuideToolStripMenuItem.Name = "tVGuideToolStripMenuItem";
            this.tVGuideToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.tVGuideToolStripMenuItem.Text = "TV Guide";
            this.tVGuideToolStripMenuItem.Click += new System.EventHandler(this.tVGuideToolStripMenuItem_Click);
            // 
            // resolutionToolStripMenuItem
            // 
            this.resolutionToolStripMenuItem.Name = "resolutionToolStripMenuItem";
            this.resolutionToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.resolutionToolStripMenuItem.Text = "Resolution";
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaPlayer.BackColor = System.Drawing.Color.Black;
            this.mediaPlayer.Location = new System.Drawing.Point(9, 27);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.Size = new System.Drawing.Size(683, 483);
            this.mediaPlayer.Spu = -1;
            this.mediaPlayer.TabIndex = 6;
            this.mediaPlayer.VlcLibDirectory = null;
            this.mediaPlayer.VlcMediaplayerOptions = null;
            this.mediaPlayer.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl2_VlcLibDirectoryNeeded);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Controls.Add(this.btStop);
            this.flowLayoutPanel1.Controls.Add(this.btPlay);
            this.flowLayoutPanel1.Controls.Add(this.btRecord);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(271, 525);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 75);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(10, 10);
            this.btStop.Margin = new System.Windows.Forms.Padding(10);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(60, 50);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(90, 10);
            this.btPlay.Margin = new System.Windows.Forms.Padding(10);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(60, 50);
            this.btPlay.TabIndex = 3;
            this.btPlay.Text = "PLAY";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // btRecord
            // 
            this.btRecord.Location = new System.Drawing.Point(170, 10);
            this.btRecord.Margin = new System.Windows.Forms.Padding(10);
            this.btRecord.Name = "btRecord";
            this.btRecord.Size = new System.Drawing.Size(60, 50);
            this.btRecord.TabIndex = 1;
            this.btRecord.Text = "REC";
            this.btRecord.UseVisualStyleBackColor = true;
            this.btRecord.Click += new System.EventHandler(this.btRecord_Click);
            // 
            // imageListM1
            // 
            this.imageListM1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListM1.ImageStream")));
            this.imageListM1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListM1.Images.SetKeyName(0, "m1_off.png");
            this.imageListM1.Images.SetKeyName(1, "m1_on.png");
            // 
            // imageListM2
            // 
            this.imageListM2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListM2.ImageStream")));
            this.imageListM2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListM2.Images.SetKeyName(0, "m2_off.png");
            this.imageListM2.Images.SetKeyName(1, "m2_on.png");
            // 
            // btDunaWorld
            // 
            this.btDunaWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDunaWorld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btDunaWorld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDunaWorld.ForeColor = System.Drawing.Color.Transparent;
            this.btDunaWorld.ImageIndex = 0;
            this.btDunaWorld.ImageList = this.imageListDunaWorld;
            this.btDunaWorld.Location = new System.Drawing.Point(3, 408);
            this.btDunaWorld.Name = "btDunaWorld";
            this.btDunaWorld.Size = new System.Drawing.Size(75, 75);
            this.btDunaWorld.TabIndex = 5;
            this.btDunaWorld.Text = "Duna World";
            this.btDunaWorld.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDunaWorld.UseVisualStyleBackColor = false;
            this.btDunaWorld.Click += new System.EventHandler(this.btChannel_Click);
            this.btDunaWorld.MouseLeave += new System.EventHandler(this.buttonMouseLeave);
            this.btDunaWorld.MouseHover += new System.EventHandler(this.buttonMouseHover);
            // 
            // imageListDunaWorld
            // 
            this.imageListDunaWorld.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDunaWorld.ImageStream")));
            this.imageListDunaWorld.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDunaWorld.Images.SetKeyName(0, "dunaworld_off.png");
            this.imageListDunaWorld.Images.SetKeyName(1, "dunaworld_on.png");
            // 
            // btDuna
            // 
            this.btDuna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDuna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btDuna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDuna.ForeColor = System.Drawing.Color.Transparent;
            this.btDuna.ImageIndex = 0;
            this.btDuna.ImageList = this.imageDuna;
            this.btDuna.Location = new System.Drawing.Point(3, 327);
            this.btDuna.Name = "btDuna";
            this.btDuna.Size = new System.Drawing.Size(75, 75);
            this.btDuna.TabIndex = 4;
            this.btDuna.Text = "Duna";
            this.btDuna.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDuna.UseVisualStyleBackColor = false;
            this.btDuna.Click += new System.EventHandler(this.btChannel_Click);
            this.btDuna.MouseLeave += new System.EventHandler(this.buttonMouseLeave);
            this.btDuna.MouseHover += new System.EventHandler(this.buttonMouseHover);
            // 
            // imageDuna
            // 
            this.imageDuna.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageDuna.ImageStream")));
            this.imageDuna.TransparentColor = System.Drawing.Color.Transparent;
            this.imageDuna.Images.SetKeyName(0, "duna_off.png");
            this.imageDuna.Images.SetKeyName(1, "duna_on.png");
            // 
            // btM5
            // 
            this.btM5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btM5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btM5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btM5.ForeColor = System.Drawing.Color.Transparent;
            this.btM5.ImageIndex = 0;
            this.btM5.ImageList = this.imageListM5;
            this.btM5.Location = new System.Drawing.Point(3, 246);
            this.btM5.Name = "btM5";
            this.btM5.Size = new System.Drawing.Size(75, 75);
            this.btM5.TabIndex = 3;
            this.btM5.Text = "M5";
            this.btM5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btM5.UseVisualStyleBackColor = false;
            this.btM5.Click += new System.EventHandler(this.btChannel_Click);
            this.btM5.MouseLeave += new System.EventHandler(this.buttonMouseLeave);
            this.btM5.MouseHover += new System.EventHandler(this.buttonMouseHover);
            // 
            // imageListM5
            // 
            this.imageListM5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListM5.ImageStream")));
            this.imageListM5.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListM5.Images.SetKeyName(0, "m5_off.png");
            this.imageListM5.Images.SetKeyName(1, "m5_on.png");
            // 
            // btM4
            // 
            this.btM4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btM4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btM4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btM4.ForeColor = System.Drawing.Color.Transparent;
            this.btM4.ImageIndex = 0;
            this.btM4.ImageList = this.imageListM4;
            this.btM4.Location = new System.Drawing.Point(3, 165);
            this.btM4.Name = "btM4";
            this.btM4.Size = new System.Drawing.Size(75, 75);
            this.btM4.TabIndex = 2;
            this.btM4.Text = "M4";
            this.btM4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btM4.UseVisualStyleBackColor = false;
            this.btM4.Click += new System.EventHandler(this.btChannel_Click);
            this.btM4.MouseLeave += new System.EventHandler(this.buttonMouseLeave);
            this.btM4.MouseHover += new System.EventHandler(this.buttonMouseHover);
            // 
            // imageListM4
            // 
            this.imageListM4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListM4.ImageStream")));
            this.imageListM4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListM4.Images.SetKeyName(0, "m4_off.png");
            this.imageListM4.Images.SetKeyName(1, "m4_on.png");
            // 
            // btM2
            // 
            this.btM2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btM2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btM2.ForeColor = System.Drawing.Color.Transparent;
            this.btM2.ImageIndex = 0;
            this.btM2.ImageList = this.imageListM2;
            this.btM2.Location = new System.Drawing.Point(3, 84);
            this.btM2.Name = "btM2";
            this.btM2.Size = new System.Drawing.Size(75, 75);
            this.btM2.TabIndex = 1;
            this.btM2.Text = "M2";
            this.btM2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btM2.UseVisualStyleBackColor = false;
            this.btM2.Click += new System.EventHandler(this.btChannel_Click);
            this.btM2.MouseLeave += new System.EventHandler(this.buttonMouseLeave);
            this.btM2.MouseHover += new System.EventHandler(this.buttonMouseHover);
            // 
            // btM1
            // 
            this.btM1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btM1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btM1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btM1.ForeColor = System.Drawing.Color.Transparent;
            this.btM1.ImageIndex = 0;
            this.btM1.ImageList = this.imageListM1;
            this.btM1.Location = new System.Drawing.Point(3, 3);
            this.btM1.Name = "btM1";
            this.btM1.Size = new System.Drawing.Size(75, 75);
            this.btM1.TabIndex = 0;
            this.btM1.Text = "M1";
            this.btM1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btM1.UseVisualStyleBackColor = false;
            this.btM1.Click += new System.EventHandler(this.btChannel_Click);
            this.btM1.MouseLeave += new System.EventHandler(this.buttonMouseLeave);
            this.btM1.MouseHover += new System.EventHandler(this.buttonMouseHover);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.btM1);
            this.flowLayoutPanel2.Controls.Add(this.btM2);
            this.flowLayoutPanel2.Controls.Add(this.btM4);
            this.flowLayoutPanel2.Controls.Add(this.btM5);
            this.flowLayoutPanel2.Controls.Add(this.btDuna);
            this.flowLayoutPanel2.Controls.Add(this.btDunaWorld);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(698, 27);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(82, 504);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // bgwGetURI
            // 
            this.bgwGetURI.WorkerSupportsCancellation = true;
            this.bgwGetURI.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetURI_DoWork);
            this.bgwGetURI.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGetURI_RunWorkerCompleted);
            // 
            // bgwRecording
            // 
            this.bgwRecording.WorkerSupportsCancellation = true;
            this.bgwRecording.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRecording_DoWork);
            this.bgwRecording.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRecording_RunWorkerCompleted);
            // 
            // bgwTVGuide
            // 
            this.bgwTVGuide.WorkerReportsProgress = true;
            this.bgwTVGuide.WorkerSupportsCancellation = true;
            this.bgwTVGuide.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTVGuide_DoWork);
            this.bgwTVGuide.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTVGuide_RunWorkerCompleted);
            // 
            // channelBindingSource
            // 
            this.channelBindingSource.DataSource = typeof(MagyarTV.Channel);
            // 
            // VideoPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 624);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 663);
            this.Name = "VideoPlayerForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "MagyarTV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoPlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.VideoPlayerForm_Load);
            this.Resize += new System.EventHandler(this.VideoPlayerForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.channelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private Vlc.DotNet.Forms.VlcControl mediaPlayer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Button btRecord;
        private System.Windows.Forms.ToolStripMenuItem schedulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tVGuideToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListM1;
        private System.Windows.Forms.ImageList imageListM2;
        private System.Windows.Forms.Button btDunaWorld;
        private System.Windows.Forms.Button btDuna;
        private System.Windows.Forms.Button btM5;
        private System.Windows.Forms.Button btM4;
        private System.Windows.Forms.ImageList imageListM4;
        private System.Windows.Forms.Button btM2;
        private System.Windows.Forms.Button btM1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ImageList imageListM5;
        private System.Windows.Forms.ImageList imageDuna;
        private System.Windows.Forms.ImageList imageListDunaWorld;
        private System.Windows.Forms.BindingSource channelBindingSource;
        private System.Windows.Forms.ToolStripMenuItem resolutionToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwGetURI;
        private System.ComponentModel.BackgroundWorker bgwRecording;
        private System.ComponentModel.BackgroundWorker bgwTVGuide;
    }
}

