using System;
using System.Globalization;
using System.Windows.Data;

namespace CryptoInfoWPF.Converters
{
    public class DecimalToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value).ToString("0.##");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return decimal.Parse((string)value);
        }
    }
}
