
using System.Reflection.Emit;

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
                string logEntry = $"[{DateTime.Now}] [{Level}] {message}";
                Console.WriteLine(logEntry);
            }
        }
    }
}

