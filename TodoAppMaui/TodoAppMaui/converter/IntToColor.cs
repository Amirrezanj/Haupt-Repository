﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.converter
{
    public class IntToColor : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string text = (string)value;

            if (string.IsNullOrEmpty(text)) return Colors.Red;
            else if (text.Length <= 5|| text.Length>=15) return Colors.Red;
            //else if (text.Length >= 8) return Colors.Green;
            return Colors.Transparent;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
