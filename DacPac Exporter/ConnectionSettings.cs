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
        string server;
        string authentificationType;
        string login;
        string password;
        string connectionString;

        public ConnectionSettingsForm()
        {
            InitializeComponent();
          
        }

        private void ConnectionSettingsForm_Load(object sender, EventArgs e)
        {
            AuthentificationTypeComboBox.SelectedItem = "Windows Authentification";
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            //debug start
            server = "sup01sql15";
            //debug end

            if (authentificationType == "SQL Server Authentification")
            {
                connectionString = $"Server={server}; Database=master; User ID={login};Password={password}";
            }
            else
            {
                connectionString = $"Server={server}; Database=master; Trusted_Connection=True;";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                    //MessageBox.Show("Подключение прошло успешно!");
                    Hide();
                    DatabaseSelect dataBaseSelectForm = new DatabaseSelect(connection);
                    dataBaseSelectForm.Show();
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
