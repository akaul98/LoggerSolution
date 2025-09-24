
using System.Reflection.Emit;
using System.Xml.Linq;



namespace LoggerStdClass
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _lazy = new(() => new Logger());
        public static Logger Instance => _lazy.Value;
        private Logger() { }
        
        public void LogError(LogLevelEnum Level,string message)
        {
            {
                string filePath = "C:\\Users\\AdarshKaul\\source\\repos\\LoggerSolution\\LoggerStdClass\\Logger.config";
                XDocument doc = XDocument.Load(filePath);
                string value = doc.Root.Element("AllowedLevels").Value;
                string logEntry = $"[{DateTime.Now}] [{Level}] {message},[{value}]";
                Console.WriteLine(logEntry);
            }
        }
    }
}



