using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using VpnWpfCore.Ui.Infrastructure.Binders;
using VpnWpfCore.Ui.Views.Windows;

namespace VpnWpfCore.Ui
{
    public sealed partial class App : Prism.DryIoc.PrismApplication
    {
        private readonly ViewModelsBinder _viewModelsBinder;
        private readonly DependencyBinder _dependencyBinder;
        private readonly ModulesBinder _modulesBinder;

        public App()
        {
            _viewModelsBinder = new ViewModelsBinder();
            _dependencyBinder = new DependencyBinder();
            _modulesBinder = new ModulesBinder();
        }

        // virtual
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            _viewModelsBinder.Bind();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            _modulesBinder.Bind(moduleCatalog);
        }

        // abstract
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _dependencyBinder.Bind(containerRegistry);
        }
    }
}
