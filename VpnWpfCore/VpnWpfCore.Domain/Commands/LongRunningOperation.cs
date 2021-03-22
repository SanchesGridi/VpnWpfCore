using System;
using System.Windows.Threading;

namespace VpnWpfCore.Domain.Commands
{
    public sealed class LongRunningOperation
    {
        private readonly TimeSpan _interval;
        private readonly DispatcherPriority _priority;
        private readonly Action _timerTickCallback;
        private readonly Dispatcher _dispatcher;

        private DispatcherTimer _timer;

        public LongRunningOperation(TimeSpan interval, DispatcherPriority priority, Action timerTickCallback, Dispatcher dispatcher)
        {
            _interval = interval;
            _priority = priority;
            _timerTickCallback = timerTickCallback;
            _dispatcher = dispatcher;
        }

        public void InitAndStartTimer()
        {
            _timer = new DispatcherTimer(
               interval: _interval,
               priority: _priority,
               callback: (os, ea) => _timerTickCallback.Invoke(),
               dispatcher: _dispatcher
           );
        }
        public DispatcherTimer GetRunningTimer()
        {
            return _timer ?? throw new InvalidOperationException("Timer equals null! Invoke [InitAndStartTimer] method");
        }
    }
}
