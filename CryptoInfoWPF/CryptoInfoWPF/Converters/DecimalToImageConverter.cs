using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CryptoInfoWPF.Converters
{
    public class DecimalToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value) > 0 ? new BitmapImage(new Uri("pack://application:,,,/Images/Increase.png")) : new BitmapImage(new Uri("pack://application:,,,/Images/Decrease.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
