using DacPacExporter.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DacPacExporter.Classes
{
    /// <summary>
    /// Параметры экспорта.
    /// </summary>
    public class ExportDefinition : IExportable
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ExportDefinition"/>.
        /// </summary>
        /// <param name="connection">Подключение к базе данных.</param>
        public ExportDefinition(SqlConnection connection)
        {
            this.Connection = connection;
            this.ConnectionString = new SqlConnectionStringBuilder(connection.ConnectionString);
            this.DbToExport = new List<string>();
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ExportDefinition"/>.
        /// </summary>
        /// <param name="connection">Подключение к базе данных.</param>
        /// <param name="password">Пароль.</param>
        public ExportDefinition(SqlConnection connection, string password)
        {
            this.Connection = connection;
            this.ConnectionString = new SqlConnectionStringBuilder(connection.ConnectionString) { Password = password };
            this.DbToExport = new List<string>();
        }

        /// <summary>
        /// Получает подключение к базе данных.
        /// </summary>
        public SqlConnection Connection { get; }

        /// <summary>
        /// Получает строку подключения.
        /// </summary>
        public SqlConnectionStringBuilder ConnectionString { get; }

        /// <summary>
        /// Получает или задает список названий баз данных для выгрузки.
        /// </summary>
        public List<string> DbToExport { get; set; }

        /// <summary>
        /// Получает или задает каталог для выгрузки DACPAC файлов.
        /// </summary>
        public string ExportDirectory { get; set; }
    }
}