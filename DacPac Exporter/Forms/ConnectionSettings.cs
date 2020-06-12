using DacPacExporter.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DacPacExporter.Forms
{
    public partial class ConnectionSettingsForm : Form
    {
        private string server;
        private string authentificationType;
        private string login;
        private string password = null;
        private string connectionString;
        private SqlConnection connection;
        private ExportDefinition exportDefinition;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ConnectionSettingsForm"/>.
        /// </summary>
        public ConnectionSettingsForm()
        {
            this.InitializeComponent();
        }

        private void ConnectionSettingsForm_Load(object sender, EventArgs e)
        {
            this.AuthentificationTypeComboBox.SelectedItem = "Windows Authentification";
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppConfiguration.GetAppConfigSetting("Debug") == true)
                {
                    this.connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                }
                else if (this.authentificationType == "SQL Server Authentification")
                {
                    this.connectionString = $"Data Source={this.server};Initial Catalog=master;User ID={this.login};Password={this.password}";
                }
                else
                {
                    this.connectionString = $"Data Source ={this.server}; Initial Catalog = master; Integrated Security = True";
                }

                this.connection = new SqlConnection(this.connectionString);
                this.connection.Open();
                this.Hide();

                if (this.password != null)
                {
                    this.exportDefinition = new ExportDefinition(this.connection, this.password);
                }
                else
                {
                    this.exportDefinition = new ExportDefinition(this.connection);
                }

                Configuration configurationForm = new Configuration(this.exportDefinition);
                configurationForm.Show();
            }
            catch (Exception ex)
            {
                this.CloseConnection();

                // Логируем ошибки.
                Logging.WriteToLog(ex.Message);
                MessageBox.Show(new Form { TopMost = true }, ex.Message, "DACPAC Exporter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void AuthentificationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.authentificationType = this.AuthentificationTypeComboBox.SelectedItem.ToString();

            if (this.authentificationType == "SQL Server Authentification")
            {
                this.UserNameLabel.Show();
                this.UserNameTextBox.Show();
                this.PasswordLabel.Show();
                this.PasswordTextBox.Show();
            }
            else if (this.authentificationType == "Windows Authentification")
            {
                this.UserNameLabel.Hide();
                this.UserNameTextBox.Hide();
                this.PasswordLabel.Hide();
                this.PasswordTextBox.Hide();
            }
        }

        private void ServerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.server = this.ServerNameComboBox.SelectedText;
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.login = this.UserNameTextBox.Text;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            this.password = this.PasswordTextBox.Text;
        }

        private void CloseConnection()
        {
            if (this.connection != null)
            {
                // Если соединение не закрыто, то закрываем его.
                if (this.connection.State != ConnectionState.Broken
                    || this.connection.State != ConnectionState.Closed)
                {
                    this.connection.Close();
                }
            }
        }
    }
}