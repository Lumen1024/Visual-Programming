using System;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace AvaloniaApplication.Models;

public class PathConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (value is string path)
        {
            return new Bitmap(path); // Преобразует путь файла в изображение Bitmap
        }
        return AvaloniaProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}