using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DacPacExporter.Classes
{
    /// <summary>
    /// Логирование.
    /// </summary>
    internal static class Logging
    {
        private static readonly string Path = Application.StartupPath + @"\log.txt";

        /// <summary>
        /// Записывает сообщение в лог.
        /// </summary>
        /// <param name="text">Текст сообщения.</param>
        public static void WriteToLog(string text)
        {
            string delimiterString = new string('=', 50);
            string appentText = Environment.NewLine + DateTime.Now + " " + delimiterString + " " + Environment.NewLine + text;
            File.AppendAllText(Path, appentText, Encoding.UTF8);
        }
    }
}