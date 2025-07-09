using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentDesignDemo.Models;

namespace FluentDesignDemo.Services;

public partial class ToastService : ObservableObject
{
    private static readonly Lazy<ToastService> _instance = new(() => new ToastService());
    public static ToastService Instance => _instance.Value;

    private readonly Timer _cleanupTimer;
    [ObservableProperty]
    private ObservableCollection<Toast> _toasts = new();

    private ToastService()
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
            }
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

    public void ShowSuccess(string message) => Show(message, ToastType.Success);
    public void ShowWarning(string message) => Show(message, ToastType.Warning);
    public void ShowError(string message) => Show(message, ToastType.Error);
}
