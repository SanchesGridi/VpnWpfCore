using Prism.Mvvm;
using VpnWpfCore.Modules.CountryBrowser.ViewModels.Controls;
using VpnWpfCore.Modules.CountryBrowser.Views.Controls;
using VpnWpfCore.Modules.SettingsBrowser.ViewModels.Controls;
using VpnWpfCore.Modules.SettingsBrowser.Views.Controls;
using VpnWpfCore.Ui.ViewModels.Windows;
using VpnWpfCore.Ui.Views.Windows;

namespace VpnWpfCore.Ui.Infrastructure.Binders
{
    public sealed class ViewModelsBinder
    {
        public void Bind()
        {
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();

            this.BindCountryBrowserModule();
            this.BindSettingsBrowserModule();
        }

        private void BindCountryBrowserModule()
        {
            ViewModelLocationProvider.Register<CountryBrowserControl, CountryBrowserControlViewModel>();
        }
        private void BindSettingsBrowserModule()
        {
            ViewModelLocationProvider.Register<SettingsBrowserControl, SettingsBrowserControlViewModel>();
        }
    }
}
