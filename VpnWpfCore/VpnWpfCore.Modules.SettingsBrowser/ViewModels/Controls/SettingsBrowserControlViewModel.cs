using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using VpnWpfCore.Domain.Enums;
using VpnWpfCore.Domain.Events;
using VpnWpfCore.Domain.ViewModels;

namespace VpnWpfCore.Modules.SettingsBrowser.ViewModels.Controls
{
    public sealed class SettingsBrowserControlViewModel : ContainerOwnerViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public DelegateCommand ClearConsoleCommand { get; }

        public SettingsBrowserControlViewModel()
        {
            _eventAggregator = _container.Resolve<IEventAggregator>();

            ClearConsoleCommand = new DelegateCommand(() => _eventAggregator.GetEvent<SettingsEvent>().Publish(SettingsOperation.ClearConsole));
        }
    }
}
