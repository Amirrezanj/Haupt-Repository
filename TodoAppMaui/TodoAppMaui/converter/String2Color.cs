using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.converter
{
    class String2Color : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string text = (string)value;
            
            if (text.Length < 2 || text.Length > 25)
            {
                return Colors.Red;
            }
            else
            {
                return Colors.Transparent;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
