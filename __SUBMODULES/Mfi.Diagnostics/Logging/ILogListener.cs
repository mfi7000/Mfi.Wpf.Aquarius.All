namespace Mfi.Diagnostics.Logging
{
    public interface ILogListener
    {
        void Log(LogRecord record);
    }
}