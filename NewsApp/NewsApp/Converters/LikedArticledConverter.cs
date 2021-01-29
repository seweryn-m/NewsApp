using System;
using System.Globalization;
using Xamarin.Forms;

namespace NewsApp.Converters
{
    public class LikedArticledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isLiked = (bool)value;

            if (!isLiked)
                return Color.White;

            return Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
