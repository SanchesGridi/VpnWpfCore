using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VpnWpfCore.Domain.Models
{
    public sealed class CountryModel : NotificationModel
    {
        private string _name;
        private ImageSource _flagSource;

        public string Name
        {
            get => _name;
            set => this.SetProperty(ref _name, value, "Name");
        }
        public ImageSource FlagSource
        {
            get => _flagSource;
            private set => this.SetProperty(ref _flagSource, value, "FlagSource");
        }

        public CountryModel(string imagePath, PixelFormat pixelFormat)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmapImage.EndInit();

            var formatConvertedBitmap = new FormatConvertedBitmap();
            formatConvertedBitmap.BeginInit();
            formatConvertedBitmap.Source = bitmapImage;
            formatConvertedBitmap.DestinationFormat = pixelFormat;
            formatConvertedBitmap.EndInit();

            FlagSource = formatConvertedBitmap;
        }
    }
}
