using Prism.Events;
using VpnWpfCore.Domain.Enums;

namespace VpnWpfCore.Domain.Events
{
    public class SettingsEvent : PubSubEvent<SettingsOperation>
    {
        public SettingsEvent()
        {
        }
    }
}
