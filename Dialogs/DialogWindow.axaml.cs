using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes;

namespace FluentDesignDemo.Dialogs;

public partial class DialogWindow : Window, IDialogWindow
{
    public DialogWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    public bool? DialogResult { get; set; }
    public new object? DataContext
    {
        get => base.DataContext;
        set => base.DataContext = value;
    }

    // For interface compatibility
    object IDialogWindow.DataContext
    {
        get => base.DataContext!;
        set => base.DataContext = value;
    }

    public async Task<bool?> ShowDialogAsync(Window? owner = null)
    {
        if (owner == null)
        {
            owner = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
                ? desktop.MainWindow
                : null;
        }
        return owner != null ? await base.ShowDialog<bool?>(owner) : null;
    }

    // For interface compatibility
    public bool? ShowDialog()
    {
        var owner = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
        return owner != null ? base.ShowDialog<bool?>(owner).GetAwaiter().GetResult() : null;
    }
}