﻿using System;
using System.Data;
using System.Windows.Forms;

namespace DacPac_Exporter
{
    public partial class Configuration : Form
    {
        private DatabaseSelect databaseSelect;
        private ExportDefinition _exportDefinition;

        public Configuration(ExportDefinition ed)
        {
            InitializeComponent();
            _exportDefinition = ed;
            databaseSelect = new DatabaseSelect(ed);
        }

        private void ConfigurationForm_Close(object sender, EventArgs e)
        {
            CloseConnection();
        }

        private void DatabaseSelectButton_Click(object sender, EventArgs e)
        {
            FilePathSelectButton.Focus();
            databaseSelect.Show();
            Hide();
        }

        private void FilePathSelectButton_Click(object sender, EventArgs e)
        {
            ExportButton.Focus();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _exportDefinition.ExportDirectory = folderBrowserDialog.SelectedPath;
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            CloseConnection();

            ExportInProcess exportInProcess = new ExportInProcess(_exportDefinition);
            exportInProcess.Show();
            Hide();
        }

        private void CloseConnection()
        {
            //Если соединение не закрыто, то закрываем его
            if (_exportDefinition.Connection.State != ConnectionState.Broken
                || _exportDefinition.Connection.State != ConnectionState.Closed)
            {
                _exportDefinition.Connection.Close();
            }
        }
    }
}
