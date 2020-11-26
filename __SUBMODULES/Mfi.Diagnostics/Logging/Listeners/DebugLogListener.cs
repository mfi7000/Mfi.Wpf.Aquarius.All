using System.Diagnostics;

namespace Mfi.Diagnostics.Logging.Listeners
{
    public class DebugLogListener : ILogListener
    {
        public void Log(LogRecord record)
        {
            Debug.WriteLine(record);
        }
    }
}