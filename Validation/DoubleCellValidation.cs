﻿using System.Globalization;
using System.Windows.Controls;

namespace LabBook_WPF_EF.Validation
{
    public class DoubleCellValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value.ToString();

            if (input == string.Empty)
                return new ValidationResult(true, null);
            else if (!double.TryParse(input, out _))
                return new ValidationResult(false, "Wprowadzona wartość nie jest liczbą!");

            return new ValidationResult(true, null);
        }
    }
}
