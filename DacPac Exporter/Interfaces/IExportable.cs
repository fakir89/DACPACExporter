using System.Collections.Generic;
using System.Data.SqlClient;

namespace DacPacExporter.Interfaces
{
    /// <summary>
    /// Параметры выгрузки файлов.
    /// </summary>
    internal interface IExportable
    {
        /// <summary>
        /// Получает подключение к базе данных.
        /// </summary>
        SqlConnection Connection { get; }

        /// <summary>
        /// Получает строку подключения.
        /// </summary>
        SqlConnectionStringBuilder ConnectionString { get; }

        /// <summary>
        /// Получает или задает список названий баз данных для выгрузки.
        /// </summary>
        List<string> DbToExport { get; set; }

        /// <summary>
        /// Получает или задает каталог для выгрузки DACPAC файлов.
        /// </summary>
        string ExportDirectory { get; set; }
    }
}