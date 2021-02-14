
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Presentation.WPF.Converters
{
    /// <summary>
    /// A converter that takes in an RGB string such as FF00FF and converts it to a WPF brush
    /// </summary>
    public class StringRGBToBrushConverter : IValueConverter
    {
        public  object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}