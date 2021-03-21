using System.Windows;
using System.Windows.Controls;
using VpnWpfCore.Domain.Models;

namespace VpnWpfCore.Ui.Infrastructure.TemplateSelectors
{
    public sealed class ConsoleTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DetailTemplate { get; set; }
        public DataTemplate MessageTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var type = item.GetType();

            if (type == typeof(DetailModel))
            {
                return DetailTemplate;
            }
            else if (type == typeof(MessageModel))
            {
                return MessageTemplate;
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
        }
    }
}
