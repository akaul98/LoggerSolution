using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LoggerStdClass
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _lazy = new(() => new Logger());
        public static Logger Instance => _lazy.Value;
        private Logger() { }

        public void LogError(LogLevelEnum level, string message)
        {
            // 1. Load allowed levels from config
            string configPath = "C:\\Users\\AdarshKaul\\source\\repos\\LoggerSolution\\LoggerStdClass\\Logger.config";
            XDocument doc = XDocument.Load(configPath);
            string allowedLevel = doc.Root.Element("AllowedLevels").Value;
            string[] allowedLevels = allowedLevel.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(x => x.Trim())
                                                 .ToArray();

            if (!allowedLevels.Contains(level.ToString(), StringComparer.OrdinalIgnoreCase))
                return;

            // 2. Create log entry
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";

            // 3. Write to console
            Console.WriteLine(logEntry);

            // 4. Write to file using StreamWriter in append mode
            string logFilePath = FolderFileOperations.GetLogFilePath();
            using (StreamWriter sw = new StreamWriter(logFilePath, append: true))
            {
                sw.WriteLine(logEntry);
            }
        }
    }
}
