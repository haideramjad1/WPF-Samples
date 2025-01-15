using System;
using System.Globalization;
using System.Windows;

namespace WPFSample.Resources
{
    public class StringToVisibilityConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the input value (Text) is null or empty
            if (string.IsNullOrWhiteSpace(value as string))
            {
                return Visibility.Visible; // Show the placeholder
            }
            return Visibility.Collapsed; // Hide the placeholder
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
