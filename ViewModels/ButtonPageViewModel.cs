using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using FluentDesignDemo.Dialogs;

namespace FluentDesignDemo.ViewModels;

public partial class ButtonPageViewModel : ViewModelBase
{

    private readonly DialogService _dialogService;

    public ButtonPageViewModel()
    {
        _dialogService = new DialogService();
    }


    [RelayCommand]
    private async Task ClickMe()
    {

        var dialog = new YesNoDialogViewModel("Tut das hier?", "Ja oder Nein? Das ist hier die Frage");
        var result = await _dialogService.OpenDialog(dialog);


        switch (result)
        {
            case DialogResults.Yes:
                Console.WriteLine("User clicked Yes!");
                break;
            case DialogResults.No:
                Console.WriteLine("User clicked No!");
                break;
            default:
                Console.WriteLine("Dialog was closed without a selection");
                break;
        }
    }

    [RelayCommand]
    private async Task ClickDialog()
    {
        var dialog = new AlertDialogViewModel("Hallo das ist ein Alert!");
        var result = await _dialogService.OpenDialog(dialog);
    }

}
