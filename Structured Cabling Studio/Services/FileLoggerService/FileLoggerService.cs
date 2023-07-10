using static System.Environment;
using static System.Globalization.CultureInfo;
using static System.IO.Path;
using static System.IO.Directory;
using static System.IO.File;

namespace StructuredCablingStudio.Services.FileLoggerService
{
	public class FileLoggerService : IFileLoggerService
	{
		private static readonly object _lock = new();

		public void Log(string fileName, string text)
		{
			Task.Run(() => WriteLog(fileName, text));
		}

		private void WriteLog(string fileName, string text)
		{
			lock (_lock)
			{
				var now = DateTime.Now;
				string logsDirectoryPath = Combine(GetCurrentDirectory(), "logs");
				CreateDirectory(logsDirectoryPath);
				string monthLogsDirectoryPath = Combine(logsDirectoryPath,
					$"{now.ToString("MM", InvariantCulture)} ({now.ToString("MMMM", InvariantCulture)}) {now.Year}");
				CreateDirectory(monthLogsDirectoryPath);
				string dayLogsDirectoryPath = Combine(monthLogsDirectoryPath,
					$"{now.Day:00} {now.ToString("MMMM", InvariantCulture)}");
				CreateDirectory(dayLogsDirectoryPath);
				AppendAllText(Combine(dayLogsDirectoryPath, fileName),
					$"{now.Day:00}.{now.Month:00}.{now.Year} {now.ToString("T", InvariantCulture)}: {text}{NewLine}");
			}
		}
	}
}
