using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace VpnWpfCore.Domain.Models
{
    public abstract class NotificationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.Read(PropertyChanged)?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void SetProperty<TAny>(ref TAny field, TAny value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            this.OnPropertyChanged(propertyName);
        }

        private TClass Read<TClass>(TClass @class) where TClass : class
        {
            return Volatile.Read(ref @class);
        }
    }
}
