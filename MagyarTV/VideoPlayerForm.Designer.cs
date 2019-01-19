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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaPlayer = new Vlc.DotNet.Forms.VlcControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btStop = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            this.btRecord = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btM1 = new System.Windows.Forms.Button();
            this.btM2 = new System.Windows.Forms.Button();
            this.btM4 = new System.Windows.Forms.Button();
            this.btM5 = new System.Windows.Forms.Button();
            this.btDuna = new System.Windows.Forms.Button();
            this.btDunaWorld = new System.Windows.Forms.Button();
            this.schedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recordToolStripMenuItem.Text = "Record";
            this.recordToolStripMenuItem.Click += new System.EventHandler(this.recordToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.schedulerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaPlayer.BackColor = System.Drawing.Color.Black;
            this.mediaPlayer.Location = new System.Drawing.Point(12, 27);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.Size = new System.Drawing.Size(480, 360);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 393);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(498, 27);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(82, 360);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // btM1
            // 
            this.btM1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btM1.Location = new System.Drawing.Point(3, 3);
            this.btM1.Name = "btM1";
            this.btM1.Size = new System.Drawing.Size(75, 23);
            this.btM1.TabIndex = 0;
            this.btM1.Text = "M1";
            this.btM1.UseVisualStyleBackColor = true;
            this.btM1.Click += new System.EventHandler(this.btChannel_Click);
            // 
            // btM2
            // 
            this.btM2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btM2.Location = new System.Drawing.Point(3, 32);
            this.btM2.Name = "btM2";
            this.btM2.Size = new System.Drawing.Size(75, 23);
            this.btM2.TabIndex = 1;
            this.btM2.Text = "M2";
            this.btM2.UseVisualStyleBackColor = true;
            this.btM2.Click += new System.EventHandler(this.btChannel_Click);
            // 
            // btM4
            // 
            this.btM4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btM4.Location = new System.Drawing.Point(3, 61);
            this.btM4.Name = "btM4";
            this.btM4.Size = new System.Drawing.Size(75, 23);
            this.btM4.TabIndex = 4;
            this.btM4.Text = "M4";
            this.btM4.UseVisualStyleBackColor = true;
            this.btM4.Click += new System.EventHandler(this.btChannel_Click);
            // 
            // btM5
            // 
            this.btM5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btM5.Location = new System.Drawing.Point(3, 90);
            this.btM5.Name = "btM5";
            this.btM5.Size = new System.Drawing.Size(75, 23);
            this.btM5.TabIndex = 5;
            this.btM5.Text = "M5";
            this.btM5.UseVisualStyleBackColor = true;
            this.btM5.Click += new System.EventHandler(this.btChannel_Click);
            // 
            // btDuna
            // 
            this.btDuna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDuna.Location = new System.Drawing.Point(3, 119);
            this.btDuna.Name = "btDuna";
            this.btDuna.Size = new System.Drawing.Size(75, 23);
            this.btDuna.TabIndex = 2;
            this.btDuna.Text = "Duna";
            this.btDuna.UseVisualStyleBackColor = true;
            this.btDuna.Click += new System.EventHandler(this.btChannel_Click);
            // 
            // btDunaWorld
            // 
            this.btDunaWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDunaWorld.Location = new System.Drawing.Point(3, 148);
            this.btDunaWorld.Name = "btDunaWorld";
            this.btDunaWorld.Size = new System.Drawing.Size(75, 23);
            this.btDunaWorld.TabIndex = 3;
            this.btDunaWorld.Text = "Duna World";
            this.btDunaWorld.UseVisualStyleBackColor = true;
            this.btDunaWorld.Click += new System.EventHandler(this.btChannel_Click);
            // 
            // schedulerToolStripMenuItem
            // 
            this.schedulerToolStripMenuItem.Name = "schedulerToolStripMenuItem";
            this.schedulerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schedulerToolStripMenuItem.Text = "Scheduler";
            this.schedulerToolStripMenuItem.Click += new System.EventHandler(this.schedulerToolStripMenuItem_Click);
            // 
            // VideoPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 469);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VideoPlayerForm";
            this.Text = "MagyarTV";
            this.Load += new System.EventHandler(this.VideoPlayerForm_Load);
            this.Resize += new System.EventHandler(this.VideoPlayerForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btM1;
        private System.Windows.Forms.Button btM2;
        private System.Windows.Forms.Button btM4;
        private System.Windows.Forms.Button btM5;
        private System.Windows.Forms.Button btDuna;
        private System.Windows.Forms.Button btDunaWorld;
        private System.Windows.Forms.ToolStripMenuItem schedulerToolStripMenuItem;
    }
}

