using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Text;

namespace DacPac_Exporter
{
    public partial class Configuration : Form
    {
        private SqlConnection _connection;
        private string _password;
        private string _filePath;
        private string _batch;
        private bool _parallelExtraction = false;
        private string _text;
        private string _output;
        private string _command;
        private bool _isLoggingCommand = false;
        private DatabaseSelect databaseSelect;

        public Configuration(SqlConnection sqlConnection, string password)
        {
            InitializeComponent();

            _connection = sqlConnection;
            _password = password;
            databaseSelect = new DatabaseSelect() {Connection = sqlConnection};
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
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _filePath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                CloseConnection();

                if (!bool.TryParse(ConfigurationManager.AppSettings.Get("Parallel Extraction"), out _parallelExtraction))
                {
                    throw new WrongAppSettingValueException("\"Parallel Extraction\"");
                }
                
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = Application.StartupPath + "\\SqlPackage\\SqlPackage.exe";
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(866); // 866 - DOS
                processStartInfo.StandardErrorEncoding = Encoding.GetEncoding(866); 

                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(_connection.ConnectionString);

                if (_password != null)
                {
                    stringBuilder.Password = _password;
                }

                foreach (string s in databaseSelect.checkedDB)
                {
                    if (s == null)
                    {
                        break;
                    }

                    stringBuilder.InitialCatalog = s;
                    _batch = "/a:Extract" +
                             " /SourceConnectionString:\"" + stringBuilder.ConnectionString + "\"" +
                             " /TargetFile:\"" + _filePath + "\\" + stringBuilder.InitialCatalog + ".dacpac\"";

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

        private void CloseConnection()
        {
            //Если соединение не закрыто, то закрываем его
            if (_connection.State != ConnectionState.Broken
                || _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }
    }
}
