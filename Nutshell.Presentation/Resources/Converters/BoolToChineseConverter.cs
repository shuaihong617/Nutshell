using System;
using System.Globalization;
using System.Windows.Data;

namespace Nutshell.Presentation.Resources.Converters
{
        public class BoolToChineseConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        return value != null && (bool)value ? "是" : "否";
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}