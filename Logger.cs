using System;
using System.IO;

namespace ConsoleApp2
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _lazy =
            new Lazy<Logger>(() => new Logger());

        public static Logger Instance => _lazy.Value;

        private readonly string _logPath;

        private Logger()
        {
            
            _logPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "app.log");
        }
        public void Warn(string message) => Write("WARN", message);
        public void Error(string message) => Write("ERROR", message);

        public void Error(string message, Exception ex)
            => Write("ERROR", $"{message} | {ex.GetType().Name}: {ex.Message}");

        private void Write(string level, string message)
        {
            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";

            Console.WriteLine(line);

            try
            {
                File.AppendAllText(_logPath, line + Environment.NewLine);
            }
            catch (IOException)
            {
                
            }
        }
    }
}