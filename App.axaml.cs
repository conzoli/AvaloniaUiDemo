using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using FluentDesignDemo.ViewModels;
using FluentDesignDemo.Views;

namespace FluentDesignDemo;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();
            var mainWindowViewModel = (MainWindowViewModel?)Program.AppHost?.Services.GetService(typeof(MainWindowViewModel));
            // Inject IServiceProvider into MainWindowViewModel
            if (mainWindowViewModel != null)
            {
                var serviceProviderProp = typeof(MainWindowViewModel).GetField("_serviceProvider", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                serviceProviderProp?.SetValue(mainWindowViewModel, Program.AppHost?.Services);
            }
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel,
            };
        }
        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}