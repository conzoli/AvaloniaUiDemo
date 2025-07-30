using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FluentDesignDemo;

sealed class Program
{
    public static IHost? AppHost { get; private set; }
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        AppHost = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<Services.DialogService>();
                services.AddSingleton<Services.ToastService>();
                // Register other services and ViewModels as needed
                services.AddSingleton<ViewModels.MainWindowViewModel>();
                services.AddTransient<ViewModels.HomePageViewModel>();
                services.AddTransient<ViewModels.ButtonPageViewModel>();
                services.AddTransient<ViewModels.InputValidationViewModel>();
                services.AddTransient<ViewModels.SettingsViewModel>();

            })
            .Build();

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
