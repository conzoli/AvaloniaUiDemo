using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using Avalonia;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentDesignDemo.Models;

namespace FluentDesignDemo.Services;

public partial class ToastService : ObservableObject
{
    private readonly Timer _cleanupTimer;
    [ObservableProperty]
    private ObservableCollection<Toast> _toasts = new();

    // Make constructor public for DI
    public ToastService()
    {
        _cleanupTimer = new Timer(1000) { AutoReset = true };
        _cleanupTimer.Elapsed += CleanupElapsedToasts;
        _cleanupTimer.Start();
    }

    public void Show(string message, ToastType type = ToastType.Normal)
    {
        var toast = new Toast
        {
            Message = message,
            Type = type,
            CreatedAt = DateTime.Now,
            Background = type switch
            {
                ToastType.Success => "#FF4CAF50",
                ToastType.Warning => "#FFFFC107",
                ToastType.Error => "#FFF44336",
                _ => "#FF424242"
            },
            Icon = GetIcon(type)

        };

        Toasts.Add(toast);
    }

    private void CleanupElapsedToasts(object? sender, ElapsedEventArgs e)
    {
        var now = DateTime.Now;
        var toastsToRemove = Toasts.Where(t => (now - t.CreatedAt) > t.Duration).ToList();

        foreach (var toast in toastsToRemove)
        {
            Toasts.Remove(toast);
        }
    }

    private StreamGeometry? GetIcon(ToastType type)
    {
        if (Application.Current == null || Application.Current.Resources == null)
        {
            Console.WriteLine("Application.Current or Resources are not initialized.");
            return null;
        }

        string iconKey = type switch
        {
            ToastType.Success => "SuccessRegular",
            ToastType.Warning => "WarningRegular",
            ToastType.Error => "ErrorRegular",
            _ => "InfoRegular"
        };

        if (!Application.Current.Resources.TryGetValue(iconKey, out var icon))
        {
            Console.WriteLine($"Resource key '{iconKey}' not found in Application.Current.Resources.");
            return null;
        }

        if (icon is StreamGeometry streamGeometry)
        {
            return streamGeometry;
        }
        else
        {
            Console.WriteLine($"Resource '{iconKey}' is not of type StreamGeometry. It is of type {icon!.GetType()}.");
            return null;
        }
    }

    public void ShowSuccess(string message) => Show(message, ToastType.Success);
    public void ShowWarning(string message) => Show(message, ToastType.Warning);
    public void ShowError(string message) => Show(message, ToastType.Error);
}
