using DacPacExporter.Classes.Exceptions;
using System.Configuration;

namespace DacPacExporter.Classes
{
    /// <summary>
    /// Конфигурация приложения.
    /// </summary>
    internal static class AppConfiguration
    {
        /// <summary>
        /// Получает значение соответствующего ключа из AppConfig.
        /// </summary>
        /// <param name="appConfigKey">Имя ключа.</param>
        /// <returns>Значение ключа.</returns>
        public static bool GetAppConfigSetting(string appConfigKey)
        {
            bool appConfigValue;

            if (!bool.TryParse(ConfigurationManager.AppSettings.Get(appConfigKey), out appConfigValue))
            {
                throw new WrongAppSettingValueException($"\"{appConfigValue}\"");
            }
            else
            {
                return appConfigValue;
            }
        }
    }
}