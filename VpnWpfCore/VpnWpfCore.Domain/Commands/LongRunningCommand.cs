using System;
using System.Linq.Expressions;
using Prism.Commands;

namespace VpnWpfCore.Domain.Commands
{
    public sealed class LongRunningCommand : DelegateCommand
    {
        private readonly LongRunningOperation _operation;

        private bool _isExecuting;

        public LongRunningOperation Operation => _operation;
        public bool IsExecuting => _isExecuting;

        public LongRunningCommand(Action executeMethod) : this(executeMethod, () => true)
        {
        }
        public LongRunningCommand(Action executeMethod, Func<bool> canExecuteMethod) : this(executeMethod, canExecuteMethod, LongRunningOperation.NotSet)
        {
        }
        public LongRunningCommand(Action executeMethod, Func<bool> canExecuteMethod, LongRunningOperation operation) : base(executeMethod, canExecuteMethod)
        {
            _operation = operation ?? throw new ArgumentNullException("operation");
        }

        public new LongRunningCommand ObservesProperty<T>(Expression<Func<T>> propertyExpression)
        {
            return (LongRunningCommand)base.ObservesProperty(propertyExpression);
        }
        public void SetExecuteState(bool executing)
        {
            _isExecuting = executing;
            base.RaiseCanExecuteChanged();
        }

        protected override void Execute(object parameter)
        {
            this.SetExecuteState(true);

            base.Execute(parameter);

            if (_operation.ShouldIgnoreTimer())
            {
                this.SetExecuteState(false);
            }
            else
            {
                _operation.InitAndStartTimer();
            }
        }
        protected override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter) && !_isExecuting;
        }
    }
}
