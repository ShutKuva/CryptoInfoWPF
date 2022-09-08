using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptoInfoWPF.Converters
{
    public class DecimalToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value) < 0 ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5A5A")) : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#11FFA9"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
