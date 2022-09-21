using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LabBook_WPF_EF.Converters
{
    internal class PriceNullToBoldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return FontWeights.Normal;

            double density = 0d;
            string num = value.ToString();

            _ = double.TryParse(num, out density);

            return density > 0 ? FontWeights.Normal : FontWeights.Bold;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
