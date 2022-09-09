using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CryptoInfoWPF.Converters
{
    public class ListOfStringsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string str in (List<string>)value)
            {
                sb.Append(str + ", ");
            }

            if (sb.Length != 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
