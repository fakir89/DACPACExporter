using DacPacExporter.Properties;
using System.Collections.Specialized;

namespace DacPacExporter.Classes
{
    /// <summary>
    /// Менеджер для работы с данными о введенных адресах серверов.
    /// </summary>
    internal class CachedServersManager
    {
        private static CachedServersManager cachedServersManager;
        private readonly StringCollection cachedServers;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CachedServersManager"/>.
        /// </summary>
        private CachedServersManager()
        {
            if (Settings.Default.CachedServers == null)
            {
                Settings.Default.CachedServers = new StringCollection();
                Settings.Default.Save();
            }

            this.cachedServers = Settings.Default.CachedServers;
        }

        /// <summary>
        /// Получить экзмепляр менеджера.
        /// </summary>
        /// <returns>Экзмепляр менеджера.</returns>
        public static CachedServersManager GetInstance()
        {
            if (cachedServersManager == null)
            {
                cachedServersManager = new CachedServersManager();
            }

            return cachedServersManager;
        }

        /// <summary>
        /// Кеширует адрес сервера.
        /// </summary>
        /// <param name="serverName">Имя сервера.</param>
        public void Save(string serverName)
        {
            if (!this.cachedServers.Contains(serverName))
            {
                this.cachedServers.Add(serverName);
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Возвращает массив введенных адресов.
        /// </summary>
        /// <returns>Массив введенных адресов.</returns>
        public string[] Get()
        {
            string[] items = new string[this.cachedServers.Count];

            if (this.cachedServers.Count > 0)
            {
                this.cachedServers.CopyTo(items, 0);
            }

            return items;
        }
    }
}