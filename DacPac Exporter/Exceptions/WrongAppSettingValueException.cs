using System;

namespace DacPacExporter.Exceptions
{
    /// <summary>
    /// Исключение "Не верное значение настройки приложения".
    /// </summary>
    internal class WrongAppSettingValueException : Exception
    {
        private string message;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WrongAppSettingValueException"/>.
        /// </summary>
        public WrongAppSettingValueException()
        {
            this.message = "Wrong AppSetting Value";
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WrongAppSettingValueException"/>.
        /// </summary>
        /// <param name="key">Ключ настройки.</param>
        public WrongAppSettingValueException(string key)
        {
            this.message = $"Wrong AppSetting Value for Key '{key}'";
        }

        /// <inheritdoc/>
        public override string Message { get => this.message; }
    }
}