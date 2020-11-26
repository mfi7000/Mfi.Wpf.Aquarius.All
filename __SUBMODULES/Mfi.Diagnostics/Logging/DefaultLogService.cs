using System;
using System.Collections.Generic;
using Mfi.Diagnostics.Logging.Listeners;

namespace Mfi.Diagnostics.Logging
{
    public class DefaultLogService : ILogService
    {
        private List<ILogListener> _listeners = new List<ILogListener>();
        private object _listenersLock = new object();

        public DefaultLogService()
        {
#if DEBUG
            _listeners.Add(new DebugLogListener());
#endif
        }

        public void Log(LogRecord record)
        {
            lock (_listenersLock)
            {
                _listeners.ForEach(l => l.Log(record));
            }
        }

        public void AddListener(ILogListener listener)
        {
            if (listener == null) throw new ArgumentNullException(nameof(listener));

            lock (_listenersLock)
            {
                _listeners.Add(listener);
            }
        }
    }
}