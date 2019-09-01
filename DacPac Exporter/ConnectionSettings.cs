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
        
        private string _server;
        private string _authentificationType;
        private string _login;
        private string _password;
        private string _connectionString;
        private bool _debug = false;
        private SqlConnection connection;

        private void ConnectionSettingsForm_Load(object sender, EventArgs e)
        {
            AuthentificationTypeComboBox.SelectedItem = "Windows Authentification";
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_authentificationType == "SQL Server Authentification")
                {
                    _connectionString = $"Data Source={_server};Initial Catalog=master;User ID={_login};Password={_password}";
                }
                else
                {
                    _connectionString = $"Data Source ={_server}; Initial Catalog = master; Integrated Security = True";
                }

                if (!bool.TryParse(ConfigurationManager.AppSettings.Get("Debug"), out _debug))
                {
                    throw new WrongAppSettingValueException("\"Debug\"");
                }

                if (_debug == true)
                {
                    _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                }

                connection = new SqlConnection(_connectionString);

                connection.Open();
                Hide();

                Configuration configurationForm = new Configuration(connection, _password);
                configurationForm.Show();

            }
            catch (Exception ex)
            {
                CloseConnection();

                //Логируем ошибки
                Logging.WriteToLog(ex.Message);
                MessageBox.Show(new Form { TopMost = true }, ex.Message, "DACPAC Exporter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthentificationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _authentificationType = AuthentificationTypeComboBox.SelectedItem.ToString();

            if (_authentificationType == "SQL Server Authentification")
            {
                UserNameLabel.Show();
                UserNameTextBox.Show();
                PasswordLabel.Show();
                PasswordTextBox.Show();
            }
            else if (_authentificationType == "Windows Authentification")
            {
                UserNameLabel.Hide();
                UserNameTextBox.Hide();
                PasswordLabel.Hide();
                PasswordTextBox.Hide();
            }
        }

        private void ServerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _server = ServerNameTextBox.Text;
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _login = UserNameTextBox.Text;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            _password = PasswordTextBox.Text;
        }

        private void CloseConnection()
        {
            if (connection != null)
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
}
