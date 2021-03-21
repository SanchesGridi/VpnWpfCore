using System;
using System.Collections.Generic;
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
        public IEnumerable<TView> GetViews<TView>(DependencyObject rootView, IEnumerable<string> viewNames) where TView : DependencyObject
        {
            if (viewNames == null)
            {
                throw new ArgumentNullException("viewNames");
            }
            foreach (var viewName in viewNames)
            {
                yield return this.GetView<TView>(rootView, viewName);
            }
        }
    }
}
