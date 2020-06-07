using DacPacExporter.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace DacPacExporter.Forms
{
    /// <summary>
    /// Конфигурация приложения.
    /// </summary>
    public partial class Configuration : Form
    {
        private readonly ExportDefinition exportDefinition;
        private DatabaseSelect databaseSelect;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Configuration"/>.
        /// </summary>
        /// <param name="ed">Параметры экспорта.</param>
        public Configuration(ExportDefinition ed)
        {
            this.InitializeComponent();
            this.exportDefinition = ed;
            this.databaseSelect = new DatabaseSelect(ed);
        }

        private void ConfigurationForm_Close(object sender, EventArgs e)
        {
            this.CloseConnection();
        }

        private void DatabaseSelectButton_Click(object sender, EventArgs e)
        {
            this.FilePathSelectButton.Focus();
            this.databaseSelect.Show();
            this.Hide();
        }

        private void FilePathSelectButton_Click(object sender, EventArgs e)
        {
            this.ExportButton.Focus();

            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.exportDefinition.ExportDirectory = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            this.CloseConnection();

            ExportInProcess exportInProcess = new ExportInProcess(this.exportDefinition);
            exportInProcess.Show();
            this.Hide();
        }

        private void CloseConnection()
        {
            // Если соединение не закрыто, то закрываем его
            if (this.exportDefinition.Connection.State != ConnectionState.Broken
                || this.exportDefinition.Connection.State != ConnectionState.Closed)
            {
                this.exportDefinition.Connection.Close();
            }
        }
    }
}