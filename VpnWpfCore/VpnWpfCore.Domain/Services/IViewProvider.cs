using System.Windows;

namespace VpnWpfCore.Domain.Services
{
    public interface IViewProvider
    {
        TView GetView<TView>(DependencyObject rootView, string viewName) where TView : DependencyObject;
    }
}
