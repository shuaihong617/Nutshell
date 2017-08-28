using System;
using System.Globalization;
using System.Windows.Data;

namespace YunLu.EMP.PMRS.Presentation.Resources.Converters
{
        public class IntToBoolConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        var b = (int)value;
                        return b == 1;
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}