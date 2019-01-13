namespace MagyarTV
{
    partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btRewind = new System.Windows.Forms.Button();
            this.btFastFwd = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btRecord = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btM1 = new System.Windows.Forms.Button();
            this.btM2 = new System.Windows.Forms.Button();
            this.btDuna = new System.Windows.Forms.Button();
            this.btDunaWorld = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rewindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaPlayer = new Vlc.DotNet.Forms.VlcControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btRewind);
            this.flowLayoutPanel1.Controls.Add(this.btFastFwd);
            this.flowLayoutPanel1.Controls.Add(this.btStop);
            this.flowLayoutPanel1.Controls.Add(this.btPlay);
            this.flowLayoutPanel1.Controls.Add(this.btPause);
            this.flowLayoutPanel1.Controls.Add(this.btRecord);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(71, 420);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(438, 69);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btRewind
            // 
            this.btRewind.Location = new System.Drawing.Point(10, 10);
            this.btRewind.Margin = new System.Windows.Forms.Padding(10);
            this.btRewind.Name = "btRewind";
            this.btRewind.Size = new System.Drawing.Size(50, 50);
            this.btRewind.TabIndex = 0;
            this.btRewind.Text = "REW";
            this.btRewind.UseVisualStyleBackColor = true;
            // 
            // btFastFwd
            // 
            this.btFastFwd.Location = new System.Drawing.Point(80, 10);
            this.btFastFwd.Margin = new System.Windows.Forms.Padding(10);
            this.btFastFwd.Name = "btFastFwd";
            this.btFastFwd.Size = new System.Drawing.Size(50, 50);
            this.btFastFwd.TabIndex = 1;
            this.btFastFwd.Text = "F.FWD";
            this.btFastFwd.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(150, 10);
            this.btStop.Margin = new System.Windows.Forms.Padding(10);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(50, 50);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(220, 10);
            this.btPlay.Margin = new System.Windows.Forms.Padding(10);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(50, 50);
            this.btPlay.TabIndex = 3;
            this.btPlay.Text = "PLAY";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(290, 10);
            this.btPause.Margin = new System.Windows.Forms.Padding(10);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(50, 50);
            this.btPause.TabIndex = 4;
            this.btPause.Text = "PAUSE";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btRecord
            // 
            this.btRecord.Location = new System.Drawing.Point(360, 10);
            this.btRecord.Margin = new System.Windows.Forms.Padding(10);
            this.btRecord.Name = "btRecord";
            this.btRecord.Size = new System.Drawing.Size(50, 50);
            this.btRecord.TabIndex = 1;
            this.btRecord.Text = "REC";
            this.btRecord.UseVisualStyleBackColor = true;
            this.btRecord.Click += new System.EventHandler(this.btRecord_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btM1);
            this.flowLayoutPanel2.Controls.Add(this.btM2);
            this.flowLayoutPanel2.Controls.Add(this.btDuna);
            this.flowLayoutPanel2.Controls.Add(this.btDunaWorld);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(503, 44);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(82, 360);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btM1
            // 
            this.btM1.Location = new System.Drawing.Point(3, 3);
            this.btM1.Name = "btM1";
            this.btM1.Size = new System.Drawing.Size(75, 23);
            this.btM1.TabIndex = 0;
            this.btM1.Text = "M1";
            this.btM1.UseVisualStyleBackColor = true;
            // 
            // btM2
            // 
            this.btM2.Location = new System.Drawing.Point(3, 32);
            this.btM2.Name = "btM2";
            this.btM2.Size = new System.Drawing.Size(75, 23);
            this.btM2.TabIndex = 1;
            this.btM2.Text = "M2";
            this.btM2.UseVisualStyleBackColor = true;
            // 
            // btDuna
            // 
            this.btDuna.Location = new System.Drawing.Point(3, 61);
            this.btDuna.Name = "btDuna";
            this.btDuna.Size = new System.Drawing.Size(75, 23);
            this.btDuna.TabIndex = 2;
            this.btDuna.Text = "Duna";
            this.btDuna.UseVisualStyleBackColor = true;
            // 
            // btDunaWorld
            // 
            this.btDunaWorld.Location = new System.Drawing.Point(3, 90);
            this.btDunaWorld.Name = "btDunaWorld";
            this.btDunaWorld.Size = new System.Drawing.Size(75, 23);
            this.btDunaWorld.TabIndex = 3;
            this.btDunaWorld.Text = "Duna World";
            this.btDunaWorld.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(597, 24);
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rewindToolStripMenuItem,
            this.fastForwardToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.playToolStripMenuItem,
            this.recordToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // rewindToolStripMenuItem
            // 
            this.rewindToolStripMenuItem.Name = "rewindToolStripMenuItem";
            this.rewindToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.rewindToolStripMenuItem.Text = "Rewind";
            // 
            // fastForwardToolStripMenuItem
            // 
            this.fastForwardToolStripMenuItem.Name = "fastForwardToolStripMenuItem";
            this.fastForwardToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fastForwardToolStripMenuItem.Text = "Fast Forward";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.recordToolStripMenuItem.Text = "Record";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.BackColor = System.Drawing.Color.Black;
            this.mediaPlayer.Location = new System.Drawing.Point(12, 44);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.Size = new System.Drawing.Size(476, 360);
            this.mediaPlayer.Spu = -1;
            this.mediaPlayer.TabIndex = 4;
            this.mediaPlayer.VlcLibDirectory = null;
            this.mediaPlayer.VlcMediaplayerOptions = null;
            this.mediaPlayer.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl2_VlcLibDirectoryNeeded);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 521);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btRewind;
        private System.Windows.Forms.Button btFastFwd;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Button btRecord;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btM1;
        private System.Windows.Forms.Button btM2;
        private System.Windows.Forms.Button btDuna;
        private System.Windows.Forms.Button btDunaWorld;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private Vlc.DotNet.Forms.VlcControl mediaPlayer;
        private System.Windows.Forms.Button btPause;
    }
}

