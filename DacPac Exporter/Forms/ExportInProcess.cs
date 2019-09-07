using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DacPac_Exporter
{
    public partial class ExportInProcess : Form
    {
        private bool _isLoggingCommand = false;
        private bool _parallelExtraction = false;

        private ExportDefinition _exportDefinition;
        ProcessStartInfo processStartInfo;
        private string _output;
        private string _command;
        private string _text;

        public ExportInProcess(ExportDefinition ed)
        {
            InitializeComponent();
            _exportDefinition = ed;
            processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = Application.StartupPath + "\\SqlPackage\\SqlPackage.exe";
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(866); // 866 - DOS
            processStartInfo.StandardErrorEncoding = Encoding.GetEncoding(866);
        }

        private void ExportInPorocess_Load(object sender, EventArgs e)
        {
            try
            {
                if (!bool.TryParse(ConfigurationManager.AppSettings.Get("Parallel Extraction"), out _parallelExtraction))
                {
                    throw new WrongAppSettingValueException("\"Parallel Extraction\"");
                }

                Thread t = new Thread(new ThreadStart(ExportDB));
                t.Start();

                MessageBox.Show(new Form { TopMost = true }, "DACPAC Unloading Complete", "DACPAC Exporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logging.WriteToLog(ex.Message);
                MessageBox.Show(new Form { TopMost = true }, ex.Message, "DACPAC Exporter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Метод отвечает за выгрузку dacpac утилитой SqlPackage.exe
        /// </summary>
        private void ExportDB()
        {
            foreach (string dbName in _exportDefinition.DbToExport)
            {
                _exportDefinition.ConnectionString.InitialCatalog = dbName;
                string _batch = $"/a:Extract /SourceConnectionString:\"{_exportDefinition.ConnectionString.ConnectionString}\" /TargetFile:\"{_exportDefinition.ExportDirectory}\\{_exportDefinition.ConnectionString.InitialCatalog}.dacpac\"";

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

                if (_parallelExtraction == false)
                    proc.WaitForExit();
            }
        }

    }
}
