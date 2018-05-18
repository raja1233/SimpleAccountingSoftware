

namespace SDN.Common.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;

    public class ByteArrayToBitmapImageConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var rawImageData = value as byte[];
            if (rawImageData == null)
                return null;

            var bitmapImage = new System.Windows.Media.Imaging.BitmapImage();
            using (var stream = new MemoryStream(rawImageData))
            {
                bitmapImage.BeginInit();
                bitmapImage.CreateOptions = System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat;
                bitmapImage.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.Default;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
