
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Presentation.WPF.Converters
{
    /// <summary>
    /// Class PathToImageConverter 
    /// Write your documentation here
    /// </summary>
    public class PathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;
            if (path != null)
            {
                BitmapImage image = new BitmapImage();
                using (FileStream stream = File.OpenRead(path))
                {
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit(); // load the image from the stream
                } // close the stream
                return image;
            }
            else
                return null;
        }
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
