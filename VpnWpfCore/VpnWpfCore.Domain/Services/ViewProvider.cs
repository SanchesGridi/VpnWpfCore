using System;
using System.Windows;

namespace VpnWpfCore.Domain.Services
{
    public sealed class ViewProvider : IViewProvider
    {
        public TView GetView<TView>(DependencyObject rootView, string viewName) where TView : DependencyObject
        {
            if (rootView == null)
            {
                throw new ArgumentNullException("rootView");
            }
            if (viewName == null)
            {
                throw new ArgumentNullException("viewName");
            }

            try
            {
                var childView = (TView)LogicalTreeHelper.FindLogicalNode(rootView, viewName);

                return childView;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
