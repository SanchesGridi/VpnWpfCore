using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using VpnWpfCore.Domain.Events;
using VpnWpfCore.Domain.Models;
using VpnWpfCore.Domain.ViewModels;
using VpnWpfCore.Modules.CountryBrowser.StubStorage;

namespace VpnWpfCore.Modules.CountryBrowser.ViewModels.Controls
{
    public class CountryBrowserControlViewModel : ContainerOwnerViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRepository<CountryModel> _repository;

        private ObservableCollection<CountryModel> _countriesCollection;

        public ObservableCollection<CountryModel> CountriesCollection
        {
            get => _countriesCollection ??= new ObservableCollection<CountryModel>(_repository.GetEntries());
            set => this.SetProperty(ref _countriesCollection, value);
        }
        public DelegateCommand<CountryModel> SelectCountryCommand { get; }
        public DelegateCommand SelectionChangedCommand { get; }
        public DelegateCommand DragMoveCommand { get; }

        public CountryBrowserControlViewModel()
        {
            _eventAggregator = _container.Resolve<IEventAggregator>();
            _repository = _container.Resolve<IRepository<CountryModel>>();

            SelectCountryCommand = new DelegateCommand<CountryModel>(
                x => _eventAggregator.GetEvent<SelectedCountryEvent>().Publish(x),
                x => x != null
            );
            SelectionChangedCommand = new DelegateCommand(() => SelectCountryCommand.RaiseCanExecuteChanged());
            DragMoveCommand = new DelegateCommand(() => _mainWindow.DragMove());
        }
    }
}
