using System;
using System.Globalization;
using Avalonia.Data.Converters;
using FluentDesignDemo.Models;

namespace FluentDesignDemo.Converters;

public class ToastTypeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ToastType toastType && parameter is string typeStr)
        {
            return toastType.ToString().Equals(typeStr, StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
