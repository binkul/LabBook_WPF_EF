﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LabBook_WPF_EF.Converters
{
    internal class CurrencyToBoldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return FontWeights.Bold;

            var num = value.ToString();

            if (num == "1" || num == "0")
                return FontWeights.Bold;
            else
                return FontWeights.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
