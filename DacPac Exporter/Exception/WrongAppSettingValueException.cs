using System;

namespace DacPac_Exporter
{
    class WrongAppSettingValueException : Exception
    {
        private string _message;
        public override string Message { get => _message; }

        public WrongAppSettingValueException()
        {
            _message = "Wrong AppSetting Value";
        }
        public WrongAppSettingValueException(string key)
        {
            _message = $"Wrong AppSetting Value for Key {key}";
        }
    }
}
