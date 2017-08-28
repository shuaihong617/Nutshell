using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace YunLu.EMP.PMRS.Presentation.Resources.Converters
{
        public class IntToBackgroundConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        var b = (int)value;
                        return b < 1 ? Brushes.Red:Brushes.LawnGreen;
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}