using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace YunLu.EMP.PMRS.Presentation.Resources.Converters
{
        public class StringToFileNameConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        var filePath = (string)value;
                        if (string.IsNullOrEmpty(filePath))
                        {
                                return string.Empty;
                        }

                        if(!File.Exists(filePath))
                        {
                                return string.Empty;
                        }

                        return Path.GetFileNameWithoutExtension(filePath);
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}