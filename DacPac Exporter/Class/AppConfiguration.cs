using System.Configuration;

namespace DacPac_Exporter
{
    internal static class AppConfiguration
    {
        /// <summary>
        /// Метод возвращает значение соответствующего ключа из AppConfig
        /// </summary>
        /// <param name="appConfigKey">Имя ключа</param>
        /// <returns></returns>
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
