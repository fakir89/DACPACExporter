using DacPacExporter.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DacPacExporter.Forms
{
    public partial class DatabaseSelect : Form
    {
        private readonly ExportDefinition exportDefinition;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DatabaseSelect"/>.
        /// </summary>
        /// <param name="ed">Параметры экспорта.</param>
        public DatabaseSelect(ExportDefinition ed)
        {
            this.InitializeComponent();
            this.exportDefinition = ed;
        }

        private void DatabaseSelect_Load(object sender, EventArgs e)
        {
            this.FillCheckBoxListDatabaseName();
        }

        private void DatabaseSelectOKButton_Click(object sender, EventArgs e)
        {
            this.GetChecked();
            ((Configuration)Application.OpenForms[1]).Show();
            this.Hide();
        }

        /// <summary>
        /// Метод получает список баз данных и выводит их в checkbox на форме.
        /// </summary>
        private void FillCheckBoxListDatabaseName()
        {
            if (this.exportDefinition.Connection != null)
            {
                string command = "select name as database_name from sys.databases where state = 0 and name not in ('master', 'tempdb', 'model', 'msdb', 'ssisdb', 'reportserver', 'ReportServerTempDB', 'mscrm_config')";
                SqlDataAdapter adapter = new SqlDataAdapter(command, this.exportDefinition.Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.CheckBoxListDatabaseName.Items.Add(dt.Rows[i]["database_name"].ToString());
                }
            }
        }

        /// <summary>
        /// Получает отмеченные в checkbox значения и сохраняет в коллекцию.
        /// </summary>
        private void GetChecked()
        {
            for (int i = 0; i < this.CheckBoxListDatabaseName.Items.Count; i++)
            {
                if (this.CheckBoxListDatabaseName.GetItemChecked(i))
                {
                    this.exportDefinition.DbToExport.Add(this.CheckBoxListDatabaseName.Items[i].ToString());
                }
            }
        }
    }
}