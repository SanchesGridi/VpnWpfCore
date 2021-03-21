using System;
using System.Text;

namespace VpnWpfCore.Domain.Models
{
    public sealed class DetailModel : NotificationModel
    {
        private DateTime _dateTime;
        private string _message;
        private string _country;

        public DateTime DateTime
        {
            get => _dateTime;
            set => this.SetProperty(ref _dateTime, value, "DateTime");
        }
        public string Message
        {
            get => _message;
            set => this.SetProperty(ref _message, value, "Message");
        }
        public string Country
        {
            get => _country;
            set => this.SetProperty(ref _country, value, "Country");
        }
        public string TimeString
        {
            get => new StringBuilder(_dateTime.ToShortDateString()).Append(" ").Append(_dateTime.ToString("T")).ToString();
        }
    }
}
