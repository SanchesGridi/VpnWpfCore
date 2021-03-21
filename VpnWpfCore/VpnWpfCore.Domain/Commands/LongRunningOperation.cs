using System;
using System.Windows.Threading;

namespace VpnWpfCore.Domain.Commands
{
    public sealed class LongRunningOperation
    {
        private readonly bool _ignoreTimer;
        private readonly TimeSpan _interval;
        private readonly DispatcherPriority _priority;
        private readonly Action _timerTickCallback;
        private readonly Dispatcher _dispatcher;

        private DispatcherTimer _timer;

        public static LongRunningOperation NotSet
        {
            get => new LongRunningOperation(true);
        }
        public LongRunningOperation(TimeSpan interval, DispatcherPriority priority, Action timerTickCallback, Dispatcher dispatcher) : this(false)
        {
            _interval = interval;
            _priority = priority;
            _timerTickCallback = timerTickCallback;
            _dispatcher = dispatcher;
        }

        private LongRunningOperation(bool ignoreTimer)
        {
            _ignoreTimer = ignoreTimer;
        }

        public void InitAndStartTimer()
        {
            if (_ignoreTimer)
            {
                throw new InvalidOperationException("Instance was created via [NotSet] property!");
            }
            else
            {
                _timer = new DispatcherTimer(
                   interval: _interval,
                   priority: _priority,
                   callback: (os, ea) => _timerTickCallback.Invoke(),
                   dispatcher: _dispatcher
               );
            }
        }
        public DispatcherTimer GetRunningTimer()
        {
            return _timer ?? throw new InvalidOperationException("Timer equals null! Invoke [InitAndStartTimer] method");
        }
        public bool ShouldIgnoreTimer()
        {
            return _ignoreTimer;
        }
    }
}
