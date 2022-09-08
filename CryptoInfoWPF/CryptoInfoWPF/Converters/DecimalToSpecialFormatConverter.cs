using System;
using System.Globalization;
using System.Windows.Data;

namespace CryptoInfoWPF.Converters
{
    public class DecimalToSpecialFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value) > 0 ? "+" + ((decimal)value).ToString("0.##") : "-" + ((decimal)value).ToString("#.##");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
