using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using VpnWpfCore.Domain.Commands;
using VpnWpfCore.Domain.Events;
using VpnWpfCore.Domain.Models;
using VpnWpfCore.Domain.Services;
using VpnWpfCore.Domain.ViewModels;
using VpnWpfCore.Ui.Infrastructure.Presenters.Modules;

namespace VpnWpfCore.Ui.ViewModels.Windows
{
    public class MainWindowViewModel : ContainerOwnerViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IViewProvider _viewProvider;
        private readonly IRegionManager _regionManager;
        private readonly IModuleManager _moduleManager;
        private readonly CountryBrowserPresenter _countryBrowserPresenter;
        private readonly SettingsBrowserPresenter _settingsBrowserPresenter;

        private NotificationModel _notificationModel;
        private ObservableCollection<NotificationModel> _consoleMessages;

        public NotificationModel NotificationModel
        {
            get => _notificationModel ??= new MessageModel { Message = "Country not selected", MessageBrush = Brushes.Firebrick };
            set => this.SetProperty(ref _notificationModel, value);
        }
        public ObservableCollection<NotificationModel> ConsoleMessages
        {
            get => _consoleMessages ??= new ObservableCollection<NotificationModel>();
            set => this.SetProperty(ref _consoleMessages, value);
        }
        public DelegateCommand DragMoveCommand { get; }
        public DelegateCommand CloseAppCommand { get; }
        public DelegateCommand GoToCountryRegionCommand { get; }
        public DelegateCommand GoToSettingsRegionCommand { get; }
        public DelegateCommand AddWarningMessageCommand { get; }
        public LongRunningCommand ConnectCommand { get; }

        public MainWindowViewModel()
        {
            _eventAggregator = _container.Resolve<IEventAggregator>();
            _eventAggregator.GetEvent<SelectedCountryEvent>().Subscribe(this.SubscribeInvoke);
            _eventAggregator.GetEvent<SettingsEvent>().Subscribe(x => ConsoleMessages.Clear());

            _viewProvider = _container.Resolve<IViewProvider>();
            _regionManager = _container.Resolve<IRegionManager>();
            _moduleManager = _container.Resolve<IModuleManager>();
            _countryBrowserPresenter = new CountryBrowserPresenter(_regionManager, _moduleManager);
            _settingsBrowserPresenter = new SettingsBrowserPresenter(_regionManager, _moduleManager);

            DragMoveCommand = new DelegateCommand(() => _mainWindow.DragMove());
            CloseAppCommand = new DelegateCommand(() => _application.Shutdown(0));
            GoToCountryRegionCommand = new DelegateCommand(() => _countryBrowserPresenter.SwitchView());
            GoToSettingsRegionCommand = new DelegateCommand(() => _settingsBrowserPresenter.SwitchView());
            AddWarningMessageCommand = new DelegateCommand(this.AddWarningMessageCommandExecute);

            ConnectCommand = new LongRunningCommand(
                this.ConnectCommandExecute,
                this.ConnectCommandExecuteCanexecute,
                new LongRunningOperation(
                    interval: TimeSpan.Parse("0:0:2.5"),
                    priority: DispatcherPriority.DataBind,
                    timerTickCallback: this.TimerTickCallback,
                    dispatcher: _application.Dispatcher
            )).ObservesProperty(() => NotificationModel);
        }

        private void SubscribeInvoke(CountryModel model)
        {
            NotificationModel = model;

            ConsoleMessages.Add(new DetailModel
            {
                DateTime = DateTime.Now,
                Message = "New location selected: ",
                Country = model.Name
            });
        }
        private void AddWarningMessageCommandExecute()
        {
            var button = _viewProvider.GetView<Button>(_mainWindow, "Connect_Button");

            if (!button.IsEnabled && !ConnectCommand.IsExecuting)
            {
                ConsoleMessages.Add(new MessageModel
                { 
                    Message = "Please select country first!",
                    MessageBrush = Brushes.Firebrick
                });
            }
        }

        private void ConnectCommandExecute()
        {
            ConsoleMessages.Add(new MessageModel
            {
                Message = $"Connecting to location: {(NotificationModel as CountryModel).Name}",
                MessageBrush = Brushes.GreenYellow
            });
        }
        private bool ConnectCommandExecuteCanexecute()
        {
            return NotificationModel is CountryModel;
        }
        private async void TimerTickCallback()
        {
            for (var i = 0; i < 20; i++)
            {
                ConsoleMessages.Add(new MessageModel
                {
                    Message = "..............................",
                    MessageBrush = Brushes.GreenYellow
                });

                await Task.Delay(100);
            }

            ConsoleMessages.Add(new MessageModel
            {
                Message = "Connection complete succeeded",
                MessageBrush = Brushes.DarkViolet
            });

            ConnectCommand.Operation.GetRunningTimer().Stop();
            ConnectCommand.SetExecuteState(false);
        }
    }
}
