using System;
using System.Globalization;
using System.Windows.Data;

namespace Nutshell.Presentation.Resources.Converters
{
        public class BoolToOnlineConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        return value != null && (bool)value ? "在线" : "离线";
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}