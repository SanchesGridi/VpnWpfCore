using System.Collections.Generic;
using System.Windows;

namespace VpnWpfCore.Domain.Services
{
    public interface IViewProvider
    {
        TView GetView<TView>(DependencyObject rootView, string viewName) where TView : DependencyObject;
        IEnumerable<TView> GetViews<TView>(DependencyObject rootView, IEnumerable<string> viewNames) where TView : DependencyObject;
    }
}
