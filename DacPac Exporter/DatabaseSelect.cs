using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DacPac_Exporter
{
    public partial class DatabaseSelect : Form
    {
        public string[] checkedDB = new string[1000];
        public SqlConnection Connection { get; set; }

        public DatabaseSelect()
        {
            InitializeComponent();
        }

        private void DatabaseSelect_Load(object sender, EventArgs e)
        {
            FillCheckBoxListDatabaseName();
        }

        private void DatabaseSelectOKButton_Click(object sender, EventArgs e)
        {
            GetChecked();
            Hide();
            ((Configuration)Application.OpenForms[1]).Show();
        }

        /// <summary>
        /// Метод получает список баз данных и выводит их в checkbox на форме
        /// </summary>
        private void FillCheckBoxListDatabaseName()
        {
            if (Connection != null)
            {
                string command = "select name as database_name from sys.databases where state = 0 and name not in ('master', 'tempdb', 'model', 'msdb', 'ssisdb', 'reportserver', 'ReportServerTempDB', 'mscrm_config')";
                SqlDataAdapter adapter = new SqlDataAdapter(command, Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBoxListDatabaseName.Items.Add(dt.Rows[i]["database_name"].ToString());
                }
            }
        }

        /// <summary>
        /// Метод получает отмеченные в checkbox значения и сохраняет в массив
        /// </summary>
        private void GetChecked()
        {
            int j = 0;

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
