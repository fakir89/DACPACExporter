using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                //dmib debug start
                connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //dmib debug end
                connection = new SqlConnection(connectionString);

                connection.Open();
                Hide();

                Configuration configurationForm = new Configuration();
                configurationForm.connection = connection;
                configurationForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
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

    }
}
