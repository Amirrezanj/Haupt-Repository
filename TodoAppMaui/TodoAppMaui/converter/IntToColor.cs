using System;
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

            if (string.IsNullOrEmpty(text)) return Colors.White;
            else if (text.Length >= 4) return Colors.Red;
            else if (text.Length >= 8) return Colors.Green;
            return Colors.White;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
