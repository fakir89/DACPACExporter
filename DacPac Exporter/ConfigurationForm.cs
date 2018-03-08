﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DacPac_Exporter
{
    public partial class ConfigurationForm : Form
    {
        SqlConnection _connection;
        string _filePath;

        public SqlConnection connection
        {
            set
            {
                _connection = value;
            }
        }

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            
        }

        private void DatabaseSelectButton_Click(object sender, EventArgs e)
        {
            DatabaseSelect databaseSelect = new DatabaseSelect();
            databaseSelect.connection = _connection;

            Hide();
            databaseSelect.Show();
  
        }

        private void FilePathSelectButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _filePath = folderBrowserDialog1.SelectedPath;
            }
            //MessageBox.Show(_filePath);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {

        }
    }
}
