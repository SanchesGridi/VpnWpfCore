using Prism.Events;
using VpnWpfCore.Domain.Models;

namespace VpnWpfCore.Domain.Events
{
    public class SelectedCountryEvent : PubSubEvent<CountryModel>
    {
        public SelectedCountryEvent()
        {
        }
    }
}
