using System.Windows.Media;

namespace VpnWpfCore.Domain.Models
{
    public sealed class MessageModel : NotificationModel
    {
        private string _message;
        private Brush _messageBrush;

        public string Message
        {
            get => _message;
            set => this.SetProperty(ref _message, value, "Message");
        }
        public Brush MessageBrush
        {
            get { return _messageBrush; }
            set => this.SetProperty(ref _messageBrush, value, "MessageBrush");
        }
    }
}
