using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace DacPac_Exporter
{
    public partial class Configuration : Form
    {
        SqlConnection _connection;
        string _connectionString;
        string _filePath;
        string _batch;
        bool _parallelExtraction = false;

        public SqlConnection connection
        {
            set
            {
                _connection = value;
            }
        }
        public string connectionString
        {
            set
            {
                _connectionString = value;
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
        }

        private void FilePathSelectButton_Click(object sender, EventArgs e)
        {
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

                Process proc = new Process();
                proc.StartInfo.FileName = "C:\\Program Files (x86)\\Microsoft SQL Server\\140\\DAC\\bin\\SqlPackage.exe"; ;
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(_connection.ConnectionString);

                foreach (string s in databaseSelect.checkedDB)
                {
                    if (s == null)
                    {
                        break;
                    }

                    stringBuilder.InitialCatalog = s;
                    _batch = "/a:Extract" +
                             " /SourceConnectionString:\"" + stringBuilder.ConnectionString + "\"" +
                             " /TargetFile:" + _filePath + "\\" + stringBuilder.InitialCatalog + ".dacpac";

                    proc.StartInfo.Arguments = _batch;
                    proc.Start();

                    if (_parallelExtraction == false)
                    {
                        proc.WaitForExit();
                    }
                }

                MessageBox.Show("DACPAC Unloading Complete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
