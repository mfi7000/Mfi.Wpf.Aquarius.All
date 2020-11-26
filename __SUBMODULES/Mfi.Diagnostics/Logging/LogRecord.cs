using System;

namespace Mfi.Diagnostics.Logging
{
    public class LogRecord
    {
        public DateTime Timestamp { get; private set; }

        public LogLevel LogLevel { get; private set; }

        public string Message { get; private set; }
        
        public string SourceId { get; private set; }
        
        public Int32 ManagedThreadId { get; private set; }

        public string Tag { get; private set; }

        public LogRecord(DateTime timestamp, LogLevel logLevel, string message, string sourceId, int managedThreadId, string tag)
        {
            Timestamp = timestamp;
            LogLevel = logLevel;
            Message = message;
            SourceId = sourceId;
            ManagedThreadId = managedThreadId;
            Tag = tag;
        }

        public override string ToString()
        {
            return $"[{Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff")}] [{LogLevel.ToString().PadRight(10)}] [{ManagedThreadId:D5}] {Message}";
        }
    }
}