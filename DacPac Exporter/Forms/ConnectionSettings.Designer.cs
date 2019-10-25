namespace DacPac_Exporter
{
    partial class ConnectionSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSettingsForm));
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.ServerNameLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.AuthentificationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.AuthentificationTypeLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerNameTextBox.Location = new System.Drawing.Point(178, 63);
            this.ServerNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(165, 20);
            this.ServerNameTextBox.TabIndex = 0;
            this.ServerNameTextBox.TextChanged += new System.EventHandler(this.ServerNameTextBox_TextChanged);
            // 
            // ServerNameLabel
            // 
            this.ServerNameLabel.AutoSize = true;
            this.ServerNameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerNameLabel.Location = new System.Drawing.Point(25, 67);
            this.ServerNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ServerNameLabel.Name = "ServerNameLabel";
            this.ServerNameLabel.Size = new System.Drawing.Size(94, 16);
            this.ServerNameLabel.TabIndex = 1;
            this.ServerNameLabel.Text = "Server Name:";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLabel.Location = new System.Drawing.Point(25, 117);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(82, 16);
            this.UserNameLabel.TabIndex = 3;
            this.UserNameLabel.Text = "User Name:";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTextBox.Location = new System.Drawing.Point(178, 117);
            this.UserNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(165, 20);
            this.UserNameTextBox.TabIndex = 3;
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            // 
            // AuthentificationTypeComboBox
            // 
            this.AuthentificationTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthentificationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AuthentificationTypeComboBox.FormattingEnabled = true;
            this.AuthentificationTypeComboBox.Items.AddRange(new object[] {
            "SQL Server Authentification",
            "Windows Authentification"});
            this.AuthentificationTypeComboBox.Location = new System.Drawing.Point(178, 88);
            this.AuthentificationTypeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AuthentificationTypeComboBox.Name = "AuthentificationTypeComboBox";
            this.AuthentificationTypeComboBox.Size = new System.Drawing.Size(165, 21);
            this.AuthentificationTypeComboBox.TabIndex = 2;
            this.AuthentificationTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.AuthentificationTypeComboBox_SelectedIndexChanged);
            // 
            // AuthentificationTypeLabel
            // 
            this.AuthentificationTypeLabel.AutoSize = true;
            this.AuthentificationTypeLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuthentificationTypeLabel.Location = new System.Drawing.Point(25, 93);
            this.AuthentificationTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AuthentificationTypeLabel.Name = "AuthentificationTypeLabel";
            this.AuthentificationTypeLabel.Size = new System.Drawing.Size(145, 16);
            this.AuthentificationTypeLabel.TabIndex = 5;
            this.AuthentificationTypeLabel.Text = "Authentification Type:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordLabel.Location = new System.Drawing.Point(25, 142);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(75, 16);
            this.PasswordLabel.TabIndex = 7;
            this.PasswordLabel.Text = "Password:";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Location = new System.Drawing.Point(178, 142);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(165, 20);
            this.PasswordTextBox.TabIndex = 4;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConnectButton.Location = new System.Drawing.Point(27, 180);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(315, 28);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Connection Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectionSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(363, 251);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.AuthentificationTypeLabel);
            this.Controls.Add(this.AuthentificationTypeComboBox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.ServerNameLabel);
            this.Controls.Add(this.ServerNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(379, 292);
            this.MinimumSize = new System.Drawing.Size(379, 292);
            this.Name = "ConnectionSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DACPAC Exporter";
            this.Load += new System.EventHandler(this.ConnectionSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerNameTextBox;
        private System.Windows.Forms.Label ServerNameLabel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.ComboBox AuthentificationTypeComboBox;
        private System.Windows.Forms.Label AuthentificationTypeLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label1;
    }

}

