using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.IO;

namespace DacPac_Exporter
{
    public partial class Configuration : Form
    {
        private SqlConnection _connection;
        private string _connectionString;
        private string _password;
        private string _filePath;
        private string _batch;
        private bool _parallelExtraction = false;
        private string _text;
        private string _output;
        private string _command;
        private string _newLine = "\r\n";
        private bool _isLoggingCommand = false;

        public SqlConnection Connection
        {
            set
            {
                _connection = value;
            }
        }
        public string ConnectionString
        {
            set
            {
                _connectionString = value;
            }
        }
        public string Password
        {
            set
            {
                _password = value;
            }
        }

        DatabaseSelect databaseSelect = new DatabaseSelect();

        public Configuration()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
        }

        private void ConfigurationForm_Close(object sender, EventArgs e)
        {
            CloseConnection();
        }

        private void DatabaseSelectButton_Click(object sender, EventArgs e)
        {
            databaseSelect.connection = _connection;

            Hide();
            databaseSelect.Show();
            FilePathSelectButton.Focus();
        }

        private void FilePathSelectButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _filePath = folderBrowserDialog1.SelectedPath;
            }
            ExportButton.Focus();
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

                Process proc = new Process();
                proc.StartInfo.FileName = Application.StartupPath + "\\SqlPackage\\SqlPackage.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;

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

                    proc.StartInfo.Arguments = _batch;
                    proc.Start();

                    _output = "Output: " + proc.StandardOutput.ReadToEnd() + proc.StandardError.ReadToEnd();

                    //Логируем то, что вывелось в консоль
                    if (_isLoggingCommand == true)
                    {
                        _command = "Command: " + _newLine + "\"" + proc.StartInfo.FileName + "\" " + _batch + _newLine + _newLine;
                        _text = _command + _output;
                    }
                    else
                    {
                        _text = _output;
                    }

                        Logging.WriteToLog(_text);

                    if (_parallelExtraction == false)
                    {
                        proc.WaitForExit();
                    }
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
