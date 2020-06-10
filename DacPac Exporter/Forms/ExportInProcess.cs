using DacPacExporter.Classes;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace DacPacExporter.Forms
{
    /// <summary>
    /// Форма для отображения процесса выгрузки.
    /// </summary>
    public partial class ExportInProcess : Form
    {
        private ExportDefinition exportDefinition;
        private ProcessStartInfo processStartInfo;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ExportInProcess"/>.
        /// </summary>
        /// <param name="exportDefinition">Параметры экспорта.</param>
        public ExportInProcess(ExportDefinition exportDefinition)
        {
            this.exportDefinition = exportDefinition;
            this.InitializeComponent();
            this.InitializeProcessStartInfo();
            this.InitializeProgressBarProperty();
        }

        /// <summary>
        /// Задает параметры запуска фонового процесса.
        /// </summary>
        private void InitializeProcessStartInfo()
        {
            this.processStartInfo = new ProcessStartInfo
            {
                FileName = Application.StartupPath + @"\Resources\SqlPackage\SqlPackage.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.GetEncoding(866), // 866 - DOS
                StandardErrorEncoding = Encoding.GetEncoding(866),
            };
        }

        /// <summary>
        /// Метод инциализирует свойства ProgressBar.
        /// </summary>
        private void InitializeProgressBarProperty()
        {
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Step = 1;
        }

        /// <summary>
        /// Выгружает DACPAC утилитой SqlPackage.exe.
        /// </summary>
        /// <param name="dbName">Имя выгружаемой базы данных.</param>
        private void ExportDB(string dbName)
        {
            if (this.backgroundWorker.CancellationPending == true)
            {
                return;
            }

            string batch, output, command, text;

            this.exportDefinition.ConnectionString.InitialCatalog = dbName;
            batch = $"/a:Extract /SourceConnectionString:\"{this.exportDefinition.ConnectionString}\"" +
                $" /TargetFile:\"{this.exportDefinition.ExportDirectory}\\{this.exportDefinition.ConnectionString.InitialCatalog}_{DateTime.Now:yyyyMMdd_HHmmssms}.dacpac\"";

            this.processStartInfo.Arguments = batch;
            Process proc = Process.Start(this.processStartInfo);

            output = "Output: " + proc.StandardOutput.ReadToEnd() + proc.StandardError.ReadToEnd();

            // Логируем то, что вывелось в консоль.
            if (AppConfiguration.GetAppConfigSetting("LogCommand"))
            {
                string password = this.exportDefinition.ConnectionString.Password;

                command = "Command: " + Environment.NewLine + "\"" + proc.StartInfo.FileName + "\" "
                    + batch.Replace($"{password}", $"{new string('*', password.Length)}")
                    + Environment.NewLine + Environment.NewLine;

                text = command + output;
            }
            else
            {
                text = output;
            }

            Logging.WriteToLog(text);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.backgroundWorker.DoWork -= this.BackgroundWorker_DoWork;
            this.backgroundWorker.RunWorkerCompleted -= this.BackgroundWorker_RunWorkerCompleted;
            this.backgroundWorker.ProgressChanged -= this.BackgroundWorker_ProgressChanged;
            this.backgroundWorker.Dispose();

            this.Hide();

            if (e.Error == null)
            {
                MessageBox.Show(new Form { TopMost = true }, "DACPAC Unloading Complete", "DACPAC Exporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Logging.WriteToLog(e.Error.Message);
                MessageBox.Show(new Form { TopMost = true }, e.Error.Message, "DACPAC Exporter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Exit();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            this.lblReportAboutCount.Text = $"Progress {e.ProgressPercentage}%";
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            this.Text = $"{this.Text} ({this.exportDefinition.ConnectionString.DataSource})";

            foreach (string dbname in this.exportDefinition.DbToExport)
            {
                this.ExportDB(dbname);
                int percent = Convert.ToInt32(Convert.ToDouble(++counter) / Convert.ToDouble(this.exportDefinition.DbToExport.Count) * 100.0);
                this.backgroundWorker.ReportProgress(percent);
            }
        }

        private void ExportInProcess_Load(object sender, EventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync();
        }

        private void ExportInProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.backgroundWorker.CancelAsync();
        }
    }
}