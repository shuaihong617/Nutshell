using System;
using System.Globalization;
using System.Windows.Data;

namespace Nutshell.Speech.Microsoft.WPFUI.Resources.Converters
{
        public class SynthesizerStateToEnableConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        var b = (SynthesizerState) value;
                        return b == SynthesizerState.空闲;
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                        throw new NotImplementedException();
                }
        }
}
