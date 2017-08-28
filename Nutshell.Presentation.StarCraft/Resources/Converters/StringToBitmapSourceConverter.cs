using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace YunLu.EMP.PMRS.Presentation.Resources.Converters
{
        public class StringToBitmapSourceConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        var filePath = (string)value;
                        if (string.IsNullOrEmpty(filePath))
                        {
                                return null;
                        }

                        if (!File.Exists(filePath))
                        {
                                return null;
                        }

                        return new BitmapImage(new Uri(filePath, UriKind.Absolute));
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}