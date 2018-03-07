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

namespace DacPac_Exporter
{
    public partial class DatabaseSelect : Form
    {
        string[] checkedDB = new string[1000];
        int j = 0;

        SqlConnection _connection;
        ConfigurationForm f2;

        public SqlConnection connection
        {
            set
            {
                _connection = value;
            }
        }


        public DatabaseSelect(ConfigurationForm f2)
        {
            InitializeComponent();
            this.f2 = f2;
        }

        private void DatabaseSelect_Load(object sender, EventArgs e)
        {
            FillCheckBoxListDatabaseName();
        }

        private void DatabaseSelectOKButton_Click(object sender, EventArgs e)
        {
            GetChecked();
            Close();
            f2.Show();
        }

        void FillCheckBoxListDatabaseName()
        {
            string command = "select name as database_name from sys.databases";
            SqlDataAdapter adapter = new SqlDataAdapter(command, _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBoxListDatabaseName.Items.Add(dt.Rows[i]["database_name"].ToString());
            }
        }

        void GetChecked()
        {
            for (int i = 0; i < CheckBoxListDatabaseName.Items.Count; i++)
            {
                if (CheckBoxListDatabaseName.GetItemChecked(i))
                {
                    checkedDB[j++] = CheckBoxListDatabaseName.Items[i].ToString();
                }
            }
        }
    }
}
