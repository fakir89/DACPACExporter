using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DacPac_Exporter
{
    internal static class Logging
    {
        static string _path = Application.StartupPath + @"\log.txt";
        static string _appentText;
        static string _delimiterString;

        public static void WriteToLog(string text)
        {
            _delimiterString = new string('=', 50);
            _appentText = Environment.NewLine + DateTime.Now + " " + _delimiterString + " " + Environment.NewLine + text;
            File.AppendAllText(_path, _appentText, Encoding.UTF8);
        }
    }
}
