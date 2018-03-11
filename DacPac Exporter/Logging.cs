using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DacPac_Exporter
{
    class Logging
    {
        static string _path = Application.StartupPath + @"\log.txt";
        string _appentText;
        char _delimiter = '=';
        short numOfRepeat = 50;
        string _delimiterString;
        string newLine = "\r\n";

        public void WriteToLog(string text)
        {
            _delimiterString = GetDelemiterString(_delimiter);
            _appentText = newLine + DateTime.Now + " " + _delimiterString + " " + newLine + text;

            File.AppendAllText(_path, _appentText, Encoding.UTF8);
        }

        private string GetDelemiterString(char delimiter)
        {
            string s = "";

            for (short i = 0; i < numOfRepeat; i++)
            {
                s += delimiter;
            }
            return s;
        }

    }
}
