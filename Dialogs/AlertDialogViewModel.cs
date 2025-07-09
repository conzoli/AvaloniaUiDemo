using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

namespace FluentDesignDemo.Dialogs;

public class AlertDialogViewModel : DialogViewModelBase<string>
{

    public ICommand CloseCommand { get; }

    public AlertDialogViewModel(string message) : base("Alert", message)
    {
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        CloseCommand = new RelayCommand<Window>(Close);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
    }


    private void Close(Window window)
    {
        CloseDialogWithResult(window, string.Empty);
    }

}
