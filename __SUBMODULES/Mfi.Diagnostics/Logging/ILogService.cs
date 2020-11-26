namespace Mfi.Diagnostics.Logging
{
    public interface ILogService
    {
        void Log(LogRecord record);

        void AddListener(ILogListener listener);
    }
}