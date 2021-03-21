using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using VpnWpfCore.Modules.SettingsBrowser.Views.Controls;

namespace VpnWpfCore.Modules.SettingsBrowser
{
    public class SettingsBrowserModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider
                .Resolve<IRegionManager>()
                .RegisterViewWithRegion("SettingsRegion", typeof(SettingsBrowserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}