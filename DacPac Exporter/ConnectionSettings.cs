using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace DacPac_Exporter
{
    public partial class ConnectionSettingsForm : Form
    {

        public ConnectionSettingsForm()
        {
            InitializeComponent();
        }
        
        string server;
        string authentificationType;
        string login;
        string password;
        string connectionString;
        SqlConnection connection;

        private void ConnectionSettingsForm_Load(object sender, EventArgs e)
        {
            AuthentificationTypeComboBox.SelectedItem = "Windows Authentification";
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (authentificationType == "SQL Server Authentification")
                {
                    connectionString = $"Data Source={server};Initial Catalog=master;User ID={login};Password={password}";
                }
                else
                {
                    connectionString = $"Data Source ={server}; Initial Catalog = master; Integrated Security = True";
                }

                if (ConfigurationManager.AppSettings.Get("Debug") == "true")
                {
                    connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                }

                connection = new SqlConnection(connectionString);

                connection.Open();
                Hide();

                Configuration configurationForm = new Configuration();
                configurationForm.connection = connection;
                configurationForm.Show();

            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void AuthentificationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            authentificationType = AuthentificationTypeComboBox.SelectedItem.ToString();

            if (authentificationType == "SQL Server Authentification")
            {
                UserNameLabel.Show();
                UserNameTextBox.Show();
                PasswordLabel.Show();
                PasswordTextBox.Show();
            }
            else if (authentificationType == "Windows Authentification")
            {
                UserNameLabel.Hide();
                UserNameTextBox.Hide();
                PasswordLabel.Hide();
                PasswordTextBox.Hide();
            }
        }

        private void ServerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            server = ServerNameTextBox.Text;
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            login = UserNameTextBox.Text;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            password = PasswordTextBox.Text;
        }

        private void CloseConnection()
        {
            //Если соединение не закрыто, то закрываем его
            if (connection.State != ConnectionState.Broken
                || connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
