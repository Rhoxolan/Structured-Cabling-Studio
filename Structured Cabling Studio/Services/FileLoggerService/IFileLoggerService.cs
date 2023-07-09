namespace StructuredCablingStudio.Services.FileLoggerService
{
    public interface IFileLoggerService
    {
        void Log(string path, string message);
    }
}