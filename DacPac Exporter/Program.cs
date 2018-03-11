using System;
using System.Windows.Forms;
using System.Configuration;

namespace DacPac_Exporter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectionSettingsForm());
        }
    }

    class WrongAppSettingValueException : Exception
    {
        string _message;

        public override string Message
        {
            get
            {
                return _message;
            }
        }

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
