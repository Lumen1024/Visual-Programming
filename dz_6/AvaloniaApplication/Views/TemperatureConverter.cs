using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace AvaloniaApplication.Views;

public class TemperatureConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not int intValue) return value;
        
        var sign = intValue >= 0 ? "+" : "-";
        var stringValue = intValue.ToString("0", CultureInfo.InvariantCulture);
        Console.WriteLine($"{sign}{stringValue}°");
        return $"{sign}{stringValue}°";

    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}