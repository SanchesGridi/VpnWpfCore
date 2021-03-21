using Prism.Modularity;
using Prism.Regions;
using VpnWpfCore.Modules.CountryBrowser;
using VpnWpfCore.Ui.Infrastructure.Helpers;
using VpnWpfCore.Ui.Infrastructure.Presenters.Modules.Base;

namespace VpnWpfCore.Ui.Infrastructure.Presenters.Modules
{
    public sealed class CountryBrowserPresenter : ModulePresenter<CountryBrowserModule>
    {
        public CountryBrowserPresenter(IRegionManager regionManager, IModuleManager moduleManager) : base(regionManager, moduleManager)
        {
        }

        protected override string GetRegionName()
        {
            return RegionNames.CountryRegion;
        }
        protected override int GetViewIndex()
        {
            const int index = 0;
            return index;
        }
    }
}
