using System.Windows;
using Prism.Mvvm;

namespace VpnWpfCore.Domain
{
    public abstract class BaseViewModel : BindableBase
    {
        protected readonly Application _application;
        protected readonly Window _mainWindow;

        public BaseViewModel()
        {
            _application = Application.Current;
            _mainWindow = _application.MainWindow;
        }
    }
}
