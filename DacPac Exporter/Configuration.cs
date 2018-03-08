using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace DacPac_Exporter
{
    public partial class Configuration : Form
    {
        SqlConnection _connection;
        string _connectionString;
        string _filePath;
        string _sqlPackagePath = "C:\\Program Files (x86)\\Microsoft SQL Server\\140\\DAC\\bin\\SqlPackage.exe";
        string _batch;

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

        public Configuration()
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
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;

            _batch = "/C " +
                     " \"" + _sqlPackagePath + "\"" +
                     " /a:Extract" +
                     " /SourceConnectionString:\"" + _connection.ConnectionString + "\"" +
                     " /TargetFile:" +
                     _filePath + "\\TestA1.dacpac"; 
            proc.StartInfo.Arguments = _batch;
            proc.Start();


            StreamReader streamReader = proc.StandardOutput;
            string output = streamReader.ReadToEnd();

            MessageBox.Show(output);
        }

        
    }
}
