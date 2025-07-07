using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using FluentDesignDemo.ViewModels;

namespace FluentDesignDemo.Dialogs;

public class YesNoDialogViewModel : DialogViewModelBase<DialogResults>
{


    public ICommand YesCommand { get; }
    public ICommand NoCommand { get; }

    public YesNoDialogViewModel(string message, string title) : base(message, title)
    {
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        YesCommand = new RelayCommand<Window>(Yes);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        NoCommand = new RelayCommand<Window>(No);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
    }

    private void Yes(Window window)
    {
        CloseDialogWithResult(window, DialogResults.Yes);
    }

    private void No(Window window)
    {
        CloseDialogWithResult(window, DialogResults.No);
    }
}


