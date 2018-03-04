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

        public DatabaseSelect(SqlConnection connection)
        {
            InitializeComponent();
            FillCheckBoxListDatabaseName(connection);
            
        }

        void FillCheckBoxListDatabaseName(SqlConnection connection)
        {
            string command = "select name as database_name from sys.databases";
            SqlDataAdapter adapter = new SqlDataAdapter(command, connection);
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

        private void DatabaseSelectExportButton_Click(object sender, EventArgs e)
        {
            GetChecked();
        }
    }
}
