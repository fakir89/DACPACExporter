namespace DacPac_Exporter
{
    partial class ExportInProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportInProcess));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblReportAboutCount = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(50, 100);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(500, 30);
            this.progressBar.TabIndex = 0;
            // 
            // lblReportAboutCount
            // 
            this.lblReportAboutCount.Location = new System.Drawing.Point(50, 30);
            this.lblReportAboutCount.Margin = new System.Windows.Forms.Padding(3);
            this.lblReportAboutCount.Name = "lblReportAboutCount";
            this.lblReportAboutCount.Size = new System.Drawing.Size(500, 40);
            this.lblReportAboutCount.TabIndex = 1;
            this.lblReportAboutCount.Text = "Выгрузка... ";
            this.lblReportAboutCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReportAboutCount.UseCompatibleTextRendering = true;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // ExportInProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 160);
            this.Controls.Add(this.lblReportAboutCount);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportInProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportInProcess";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ExportInProcess_Load);
            this.Shown += new System.EventHandler(this.ExportInProgress_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblReportAboutCount;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}