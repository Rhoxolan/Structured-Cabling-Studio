using static System.Environment;
using static System.Globalization.CultureInfo;
using static System.IO.Path;
using static System.IO.Directory;

namespace StructuredCablingStudio.Services.FileLoggerService
{
    public class FileLoggerService : IFileLoggerService
    {
        private static readonly object _lock = new();

        public void Log(string filePath, string text)
        {
            lock (_lock)
            {
                var now = DateTime.Now;
                string logsDirectoryPath = Combine(GetCurrentDirectory(), "logs");
                if (!Directory.Exists(logsDirectoryPath))
                {
                    CreateDirectory(logsDirectoryPath);
                }
                string monthLogsDirectoryPath = Combine(logsDirectoryPath, $"{now.ToString("MMMM", InvariantCulture)} {now.Year}");
                if (!Directory.Exists(monthLogsDirectoryPath))
                {
                    CreateDirectory(monthLogsDirectoryPath);
                }
                string dayLogsDirectoryPath = Combine(monthLogsDirectoryPath, $"{now.Day} {now.ToString("MMMM", InvariantCulture)}");
                if (!Directory.Exists(dayLogsDirectoryPath))
                {
                    CreateDirectory(dayLogsDirectoryPath);
                }
                File.AppendAllText(Combine(dayLogsDirectoryPath, filePath),
                    $"{now.Day:00}.{now.Month:00}.{now.Year} {now.ToString("T", InvariantCulture)}: {text}{NewLine}");
            }
        }
    }
}
