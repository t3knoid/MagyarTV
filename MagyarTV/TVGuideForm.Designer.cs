namespace MagyarTV
{
    partial class TVGuideForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btUpdate = new System.Windows.Forms.Button();
            this.bgwTVGuide = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(504, 492);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(75, 23);
            this.btUpdate.TabIndex = 0;
            this.btUpdate.Text = "&Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // TVGuideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btUpdate);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TVGuideForm";
            this.Text = "TVGuide";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TVGuideForm_FormClosing);
            this.Load += new System.EventHandler(this.TVGuideForm_Load);
            this.ResumeLayout(false);
            // 
            // bgwTVGuide
            // 
            this.bgwTVGuide.WorkerReportsProgress = true;
            this.bgwTVGuide.WorkerSupportsCancellation = true;
            this.bgwTVGuide.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTVGuide_DoWork);
            this.bgwTVGuide.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTVGuide_RunWorkerCompleted);
        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btUpdate;
        private System.ComponentModel.BackgroundWorker bgwTVGuide;

    }
}