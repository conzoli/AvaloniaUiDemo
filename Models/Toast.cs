using System;
using Avalonia.Media;

namespace FluentDesignDemo.Models;

public class Toast
{
    public string Message { get; set; } = string.Empty;
    public ToastType Type { get; set; }
    public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(3);
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Background { get; set; } = "#FF424242";

    public StreamGeometry? Icon { get; set; }
}

public enum ToastType
{
    Normal,
    Success,
    Warning,
    Error
}
