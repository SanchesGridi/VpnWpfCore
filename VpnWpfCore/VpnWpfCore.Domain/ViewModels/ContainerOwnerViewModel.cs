using Prism.Ioc;
using VpnWpfCore.Domain.Extensions;

namespace VpnWpfCore.Domain.ViewModels
{
    public abstract class ContainerOwnerViewModel : BaseViewModel
    {
        protected readonly IContainerExtension _container;

        public ContainerOwnerViewModel()
        {
            _container = _application.GetContainer();
        }
    }
}
