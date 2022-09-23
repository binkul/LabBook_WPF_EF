using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LabBook_WPF_EF.Converters
{
    internal class CurrencyToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Brushes.Red;

            var num = value.ToString();

            if (num == "1" || num == "0")
                return Brushes.Red;
            else
                return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
