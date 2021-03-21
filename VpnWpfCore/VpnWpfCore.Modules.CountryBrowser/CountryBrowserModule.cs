using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using VpnWpfCore.Domain.Models;
using VpnWpfCore.Modules.CountryBrowser.StubStorage;
using VpnWpfCore.Modules.CountryBrowser.Views.Controls;

namespace VpnWpfCore.Modules.CountryBrowser
{
    public class CountryBrowserModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider
               .Resolve<IRegionManager>()
               .RegisterViewWithRegion("CountryRegion", typeof(CountryBrowserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IRepository<CountryModel>, CountryRepository>();
        }
    }
}