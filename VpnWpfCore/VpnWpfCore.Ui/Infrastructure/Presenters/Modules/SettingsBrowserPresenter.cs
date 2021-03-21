using Prism.Modularity;
using Prism.Regions;
using VpnWpfCore.Modules.SettingsBrowser;
using VpnWpfCore.Ui.Infrastructure.Helpers;
using VpnWpfCore.Ui.Infrastructure.Presenters.Modules.Base;

namespace VpnWpfCore.Ui.Infrastructure.Presenters.Modules
{
    public sealed class SettingsBrowserPresenter : ModulePresenter<SettingsBrowserModule>
    {
        public SettingsBrowserPresenter(IRegionManager regionManager, IModuleManager moduleManager) : base(regionManager, moduleManager)
        {
        }

        protected override string GetRegionName()
        {
            return RegionNames.SettingsRegion;
        }
        protected override int GetViewIndex()
        {
            const int index = 0;
            return index;
        }
    }
}
