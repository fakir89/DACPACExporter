using System.Collections.Generic;
using System.Data.SqlClient;

namespace DacPac_Exporter
{
    interface IExportable
    {
        SqlConnection Connection { get; }
        SqlConnectionStringBuilder ConnectionString { get; }
        List<string> DbToExport { get; }
        string ExportDirectory { get; }
    }

    /// <summary>
    /// Класс содержит информацию о параметрах выгрузки файлов
    /// </summary>
    public class ExportDefinition : IExportable
    {
        /// <summary>
        /// SqlConnection
        /// </summary>
        public SqlConnection Connection { get; }
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public SqlConnectionStringBuilder ConnectionString { get; }

        /// <summary>
        /// Список имен баз для выгрузки
        /// </summary>
        public List<string> DbToExport { get; set; }

        /// <summary>
        /// Директория, куда будут сохранены файлы
        /// </summary>
        public string ExportDirectory { get; set; }

        public ExportDefinition(SqlConnection connection)
        {
            Connection = connection;
            ConnectionString = new SqlConnectionStringBuilder(connection.ConnectionString);
            DbToExport = new List<string>();
        }
        public ExportDefinition(SqlConnection connection, string password)
        {
            Connection = connection;
            ConnectionString = new SqlConnectionStringBuilder(connection.ConnectionString) { Password = password };
            DbToExport = new List<string>();
        }
    }
}
