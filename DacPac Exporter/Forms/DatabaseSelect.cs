using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DacPac_Exporter
{
    public partial class DatabaseSelect : Form
    {
        private ExportDefinition _exportDefinition;

        public DatabaseSelect(ExportDefinition ed)
        {
            InitializeComponent();
            _exportDefinition = ed;
        }

        private void DatabaseSelect_Load(object sender, EventArgs e)
        {
            FillCheckBoxListDatabaseName();
        }

        private void DatabaseSelectOKButton_Click(object sender, EventArgs e)
        {
            GetChecked();
            ((Configuration)Application.OpenForms[1]).Show();
            Hide();
        }

        /// <summary>
        /// Метод получает список баз данных и выводит их в checkbox на форме
        /// </summary>
        private void FillCheckBoxListDatabaseName()
        {
            if (_exportDefinition.Connection != null)
            {
                string command = "select name as database_name from sys.databases where state = 0 and name not in ('master', 'tempdb', 'model', 'msdb', 'ssisdb', 'reportserver', 'ReportServerTempDB', 'mscrm_config')";
                SqlDataAdapter adapter = new SqlDataAdapter(command, _exportDefinition.Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBoxListDatabaseName.Items.Add(dt.Rows[i]["database_name"].ToString());
                }
            }
        }

        /// <summary>
        /// Метод получает отмеченные в checkbox значения и сохраняет в коллекцию
        /// </summary>
        private void GetChecked()
        {
            for (int i = 0; i < CheckBoxListDatabaseName.Items.Count; i++)
            {
                if (CheckBoxListDatabaseName.GetItemChecked(i))
                {
                    _exportDefinition.DbToExport.Add(CheckBoxListDatabaseName.Items[i].ToString());
                }
            }
        }
    }
}
