using System;
using System.Globalization;
using System.Windows.Data;

namespace Nutshell.Resources.Converters.Presentation.Hardware.Vision
{
        public class CameraRendererStateConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        return (bool)value ? "运行" : "停止";
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}
