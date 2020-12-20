namespace Mfi.Diagnostics.Logging
{
    public interface ILogSource
    {
        public string SourceId { get; set; }

        public void Log(string message, LogLevel logLevel);
    }
}