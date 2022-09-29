using System;
using System.Globalization;
using System.Windows.Data;

namespace LabBook_WPF_EF.Converters
{
    public class DateTimeConverterOneWay : IValueConverter
    {
        private const string _format = "dd-MM-yyyy";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "-";

            DateTime date = (DateTime)value;
            return date.ToString(_format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
