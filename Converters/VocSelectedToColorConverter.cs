using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LabBook_WPF_EF.Converters
{
    public class VocSelectedToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Brushes.Yellow;

            string num = value.ToString();

            _ = double.TryParse(num, out double price);

            return price > 0 ? Brushes.White : Brushes.Yellow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
