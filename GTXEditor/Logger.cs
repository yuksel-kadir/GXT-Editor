using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTXEditor
{
    public class Logger
    {
        //A more modern and thread-safe way to implement a Singleton in C#
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());
        private readonly StringBuilder logBuilder = new StringBuilder();
        private Logger() { }

        public static Logger Instance => instance.Value;

        private string GetLogMessage(string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            logBuilder.AppendLine($"{DateTime.Now}: {formattedMessage}");
            return logBuilder.ToString();
        }

        public void PrintLogMessage(TextBox logBox, string message, params object[] args)
        {
            string logMessage = this.GetLogMessage(message, args);
            logBox.Text = logMessage;
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }
    }
}
