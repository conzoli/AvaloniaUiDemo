using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.Controls.ApplicationLifetimes;
using FluentDesignDemo.Dialogs;

namespace FluentDesignDemo.Services;

public class DialogService : IDialogService
{
    public async Task<T> OpenDialog<T>(DialogViewModelBase<T> viewModel)
    {
        var dialogWindow = new DialogWindow
        {
            DataContext = viewModel
        };

        dialogWindow.Title = viewModel.Title;

        // Show dialog and wait for result
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop 
            ? desktop.MainWindow
            : null;

        if (mainWindow != null)
        {
            await dialogWindow.ShowDialog<bool?>(mainWindow);
        }

#pragma warning disable CS8603 // Possible null reference return.
        return viewModel.DialogResults;
#pragma warning restore CS8603 // Possible null reference return.
    }
}

