using System;
using System.Globalization;
using Avalonia.Data.Converters;
using FluentDesignDemo.Models;

namespace FluentDesignDemo.Converters;

public class ToastTypeToClassConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ToastType toastType)
        {
            return $"toast {toastType.ToString().ToLowerInvariant()}";
        }
        return "toast normal";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
