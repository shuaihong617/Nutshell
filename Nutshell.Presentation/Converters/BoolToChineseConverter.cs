using System;
using System.Globalization;
using System.Windows.Data;

namespace Nutshell.Presentation.Converters
{
        public class BoolToChineseConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        var b = (bool) value;
                        return b ? "是" : "否";
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}
