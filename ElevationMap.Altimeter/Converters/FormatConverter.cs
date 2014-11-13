using System;
using System.Globalization;
using System.Windows.Data;

namespace NV.ElevationMap.Altimeter.Converters
{
    public class FormatConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return parameter != null 
                        ? string.Format(parameter.ToString(), value)
                        : value;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}