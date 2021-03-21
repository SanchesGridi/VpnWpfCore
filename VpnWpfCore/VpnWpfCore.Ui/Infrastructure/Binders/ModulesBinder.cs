using Prism.Modularity;
using VpnWpfCore.Modules.CountryBrowser;
using VpnWpfCore.Modules.SettingsBrowser;

namespace VpnWpfCore.Ui.Infrastructure.Binders
{
    public sealed class ModulesBinder
    {
        public void Bind(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CountryBrowserModule>(InitializationMode.OnDemand);
            moduleCatalog.AddModule<SettingsBrowserModule>(InitializationMode.OnDemand);
        }
    }
}
