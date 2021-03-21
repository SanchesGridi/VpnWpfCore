using Prism.Ioc;
using VpnWpfCore.Domain.Services;

namespace VpnWpfCore.Ui.Infrastructure.Binders
{
    public sealed class DependencyBinder
    {
        public void Bind(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IViewProvider, ViewProvider>();
            containerRegistry.RegisterSingleton<IStringResourceProvider, StringResourceProvider>();
        }
    }
}
