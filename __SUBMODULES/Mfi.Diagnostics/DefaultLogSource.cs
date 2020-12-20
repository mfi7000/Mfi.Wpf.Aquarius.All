using System;
using System.Threading;
using Mfi.Diagnostics.Logging;

namespace Mfi.Diagnostics
{
    public class DefaultLogSource : ILogSource
    {
        private ILogService _logService;

        public DefaultLogSource(ILogService logService, string sourceId)
        {
            _logService = logService;
            SourceId = sourceId;
        }

        public string SourceId { get; set; }

        public void Log(string message, LogLevel logLevel)
        {
            var record = new LogRecord(DateTime.Now, 
                                       logLevel,
                                       message,
                                       SourceId,
                                       Thread.CurrentThread.ManagedThreadId,
                                       null);

            _logService.Log(record);
        }
    }
}