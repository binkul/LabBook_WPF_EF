using System;
using System.Globalization;
using System.Windows.Data;

namespace LabBook_WPF_EF.Converters
{
    internal class NaviCurrentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long number = System.Convert.ToInt64(value);
            number++;
            return number;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
