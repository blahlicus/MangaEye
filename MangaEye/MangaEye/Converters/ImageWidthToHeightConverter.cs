using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MangaEye
{
    public class ImageWidthToHeightConverter : IMultiValueConverter
    {


        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is Bitmap bmp && values[1] is double width)
            {
                double actualWidth = bmp.Size.Width;
                double actualHeight = bmp.Size.Height;

                double height = width / actualWidth * actualHeight;
                return height;
            }

            return 100;
        }
    }
}
