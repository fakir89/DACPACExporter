namespace DacPac_Exporter
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.DatabaseSelectButton = new System.Windows.Forms.Button();
            this.FilePathSelectButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ExportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DatabaseSelectButton
            // 
            this.DatabaseSelectButton.Location = new System.Drawing.Point(128, 64);
            this.DatabaseSelectButton.Name = "DatabaseSelectButton";
            this.DatabaseSelectButton.Size = new System.Drawing.Size(250, 35);
            this.DatabaseSelectButton.TabIndex = 0;
            this.DatabaseSelectButton.Text = "SELECT DATABASES";
            this.DatabaseSelectButton.UseVisualStyleBackColor = true;
            this.DatabaseSelectButton.Click += new System.EventHandler(this.DatabaseSelectButton_Click);
            // 
            // FilePathSelectButton
            // 
            this.FilePathSelectButton.Location = new System.Drawing.Point(128, 130);
            this.FilePathSelectButton.Name = "FilePathSelectButton";
            this.FilePathSelectButton.Size = new System.Drawing.Size(250, 35);
            this.FilePathSelectButton.TabIndex = 1;
            this.FilePathSelectButton.Text = "FOLDER TO EXPORT";
            this.FilePathSelectButton.UseVisualStyleBackColor = true;
            this.FilePathSelectButton.Click += new System.EventHandler(this.FilePathSelectButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(128, 233);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(250, 35);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "EXPORT";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 303);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.FilePathSelectButton);
            this.Controls.Add(this.DatabaseSelectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.Text = "DACPAC Exporter";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button FilePathSelectButton;
        private System.Windows.Forms.Button DatabaseSelectButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button ExportButton;
    }
}