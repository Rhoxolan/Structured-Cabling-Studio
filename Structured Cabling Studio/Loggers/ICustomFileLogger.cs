namespace StructuredCablingStudio.Loggers
{
	public interface ICustomFileLogger
	{
		void Log(string path, string message);
	}
}