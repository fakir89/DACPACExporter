using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DacPac_Exporter
{
    public partial class ExportInProcess : Form
    {
        private bool _isLoggingCommand = false;
        private bool _parallelExtraction = false;

        private ExportDefinition _exportDefinition;
        private ProcessStartInfo processStartInfo;

        public ExportInProcess(ExportDefinition ed)
        {
            _exportDefinition = ed;
            InitializeComponent();
            InitializeProcessStartInfo();
            InitializeProgressBarProperty();
            //lblReportAboutCount.Visible = true;
            //lblReportAboutCount.Text = "Выгрузка...";
        }

        #region Инициализаторы
        /// <summary>
        /// Метод задает параметры запуска фонового процесса 
        /// </summary>
        private void InitializeProcessStartInfo()
        {
            processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = Application.StartupPath + @"\Resources\SqlPackage\SqlPackage.exe";
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(866); // 866 - DOS
            processStartInfo.StandardErrorEncoding = Encoding.GetEncoding(866);
        }

        /// <summary>
        /// Метод инциализирует свойства ProgressBar
        /// </summary>
        private void InitializeProgressBarProperty()
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Step = 1;
        }
        #endregion

        /// <summary>
        /// Метод отвечает за выгрузку dacpac утилитой SqlPackage.exe
        /// </summary>
        /// <param name="dbName">Имя выгружаемой базы данных</param>
        private void ExportDB(string dbName)
        {
            string _batch, _output, _command, _text;

            SqlConnectionStringBuilder sqlConnectionString = _exportDefinition.ConnectionString;
            sqlConnectionString.InitialCatalog = dbName;
            _batch = $"/a:Extract /SourceConnectionString:\"{sqlConnectionString}\" /TargetFile:\"{_exportDefinition.ExportDirectory}\\{sqlConnectionString.InitialCatalog}.dacpac\"";

            processStartInfo.Arguments = _batch;
            Process proc = Process.Start(processStartInfo);

            _output = "Output: " + proc.StandardOutput.ReadToEnd() + proc.StandardError.ReadToEnd();

            //Логируем то, что вывелось в консоль
            if (_isLoggingCommand == true)
            {
                _command = "Command: " + Environment.NewLine + "\"" + proc.StartInfo.FileName + "\" " + _batch + Environment.NewLine + Environment.NewLine;
                _text = _command + _output;
            }
            else
            {
                _text = _output;
            }
            Logging.WriteToLog(_text);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker.DoWork -= BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted -= BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.ProgressChanged -= BackgroundWorker_ProgressChanged;
            backgroundWorker.Dispose();

            Hide();

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
            progressBar.Value = e.ProgressPercentage;
            lblReportAboutCount.Text = $"Прогресс выполнения {e.ProgressPercentage.ToString()}%";
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;

            foreach (string dbname in _exportDefinition.DbToExport)
            {
                ExportDB(dbname);
                int percent = Convert.ToInt32((Convert.ToDouble(++counter) / Convert.ToDouble(_exportDefinition.DbToExport.Count) * 100.0));
                backgroundWorker.ReportProgress(percent);
            }
        }

        private void ExportInProgress_Shown(object sender, EventArgs e)
        {
            return;
        }

        private void ExportInProcess_Load(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}
