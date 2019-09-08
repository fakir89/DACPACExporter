using System;

namespace DacPac_Exporter
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.DatabaseSelectButton = new System.Windows.Forms.Button();
            this.FilePathSelectButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ExportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DatabaseSelectButton
            // 
            this.DatabaseSelectButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DatabaseSelectButton.Location = new System.Drawing.Point(66, 58);
            this.DatabaseSelectButton.Name = "DatabaseSelectButton";
            this.DatabaseSelectButton.Size = new System.Drawing.Size(250, 35);
            this.DatabaseSelectButton.TabIndex = 0;
            this.DatabaseSelectButton.Text = "SELECT DATABASES";
            this.DatabaseSelectButton.UseVisualStyleBackColor = true;
            this.DatabaseSelectButton.Click += new System.EventHandler(this.DatabaseSelectButton_Click);
            // 
            // FilePathSelectButton
            // 
            this.FilePathSelectButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilePathSelectButton.Location = new System.Drawing.Point(66, 115);
            this.FilePathSelectButton.Name = "FilePathSelectButton";
            this.FilePathSelectButton.Size = new System.Drawing.Size(250, 35);
            this.FilePathSelectButton.TabIndex = 1;
            this.FilePathSelectButton.Text = "FOLDER TO EXPORT";
            this.FilePathSelectButton.UseVisualStyleBackColor = true;
            this.FilePathSelectButton.Click += new System.EventHandler(this.FilePathSelectButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExportButton.Location = new System.Drawing.Point(66, 230);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(250, 35);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "EXPORT";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 303);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.FilePathSelectButton);
            this.Controls.Add(this.DatabaseSelectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DACPAC Exporter";
            this.ResumeLayout(false);

        }

#endregion
        private System.Windows.Forms.Button FilePathSelectButton;
        private System.Windows.Forms.Button DatabaseSelectButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button ExportButton;
    }
}