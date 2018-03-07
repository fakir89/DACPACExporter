namespace DacPac_Exporter
{
    partial class DatabaseSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseSelect));
            this.CheckBoxListDatabaseName = new System.Windows.Forms.CheckedListBox();
            this.DatabaseSelectExportButton = new System.Windows.Forms.Button();
            this.ChooseDatabasesToExportLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckBoxListDatabaseName
            // 
            this.CheckBoxListDatabaseName.CheckOnClick = true;
            this.CheckBoxListDatabaseName.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckBoxListDatabaseName.FormattingEnabled = true;
            this.CheckBoxListDatabaseName.Location = new System.Drawing.Point(12, 67);
            this.CheckBoxListDatabaseName.Name = "CheckBoxListDatabaseName";
            this.CheckBoxListDatabaseName.Size = new System.Drawing.Size(460, 613);
            this.CheckBoxListDatabaseName.Sorted = true;
            this.CheckBoxListDatabaseName.TabIndex = 1;
            // 
            // DatabaseSelectExportButton
            // 
            this.DatabaseSelectExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseSelectExportButton.AutoSize = true;
            this.DatabaseSelectExportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DatabaseSelectExportButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DatabaseSelectExportButton.Location = new System.Drawing.Point(290, 692);
            this.DatabaseSelectExportButton.MaximumSize = new System.Drawing.Size(180, 40);
            this.DatabaseSelectExportButton.MinimumSize = new System.Drawing.Size(180, 40);
            this.DatabaseSelectExportButton.Name = "DatabaseSelectExportButton";
            this.DatabaseSelectExportButton.Size = new System.Drawing.Size(180, 40);
            this.DatabaseSelectExportButton.TabIndex = 2;
            this.DatabaseSelectExportButton.Text = "Export";
            this.DatabaseSelectExportButton.UseVisualStyleBackColor = true;
            this.DatabaseSelectExportButton.Click += new System.EventHandler(this.DatabaseSelectExportButton_Click);
            // 
            // ChooseDatabasesToExportLabel
            // 
            this.ChooseDatabasesToExportLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseDatabasesToExportLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseDatabasesToExportLabel.Location = new System.Drawing.Point(12, 18);
            this.ChooseDatabasesToExportLabel.Name = "ChooseDatabasesToExportLabel";
            this.ChooseDatabasesToExportLabel.Size = new System.Drawing.Size(458, 35);
            this.ChooseDatabasesToExportLabel.TabIndex = 10;
            this.ChooseDatabasesToExportLabel.Text = "Choose databases to export";
            this.ChooseDatabasesToExportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DatabaseSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(482, 753);
            this.Controls.Add(this.ChooseDatabasesToExportLabel);
            this.Controls.Add(this.DatabaseSelectExportButton);
            this.Controls.Add(this.CheckBoxListDatabaseName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 800);
            this.Name = "DatabaseSelect";
            this.Text = "DACPAC Exporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox CheckBoxListDatabaseName;
        private System.Windows.Forms.Button DatabaseSelectExportButton;
        private System.Windows.Forms.Label ChooseDatabasesToExportLabel;
    }
}