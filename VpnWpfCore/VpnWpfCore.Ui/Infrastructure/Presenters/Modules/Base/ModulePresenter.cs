using System.Linq;
using Prism.Modularity;
using Prism.Regions;

namespace VpnWpfCore.Ui.Infrastructure.Presenters.Modules.Base
{
    public abstract class ModulePresenter<TModule> where TModule : IModule
    {
        protected readonly IRegionManager _regionManager;
        protected readonly IModuleManager _moduleManager;

        protected IRegion _moduleRegion;
        protected object _moduleView;
        protected bool _isModuleLoaded;
        protected bool _isModuleViewVisible;

        public ModulePresenter(IRegionManager regionManager, IModuleManager moduleManager)
        {
            _regionManager = regionManager;
            _moduleManager = moduleManager;
        }

        public virtual void SwitchView()
        {
            if (!_isModuleLoaded)
            {
                this.OnFirstSwitch();
            }
            else
            {
                if (_isModuleViewVisible)
                {
                    _moduleRegion.Remove(_moduleView);
                }
                else
                {
                    _moduleRegion.Add(_moduleView);
                }

                _isModuleViewVisible = !_isModuleViewVisible;
            }
        }

        protected virtual void OnFirstSwitch()
        {
            _moduleManager.LoadModule<TModule>();

            _moduleRegion = _regionManager.Regions[this.GetRegionName()];
            _moduleView = _moduleRegion.Views.ElementAt(this.GetViewIndex());

            _isModuleLoaded = true;
            _isModuleViewVisible = true;
        }

        protected abstract string GetRegionName();
        protected abstract int GetViewIndex();
    }
}
