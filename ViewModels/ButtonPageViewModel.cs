using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using FluentDesignDemo.Dialogs;
using FluentDesignDemo.Services;

namespace FluentDesignDemo.ViewModels;

public partial class ButtonPageViewModel : ViewModelBase
{

    private readonly DialogService _dialogService;
    private readonly ToastService _toastService;

    public ButtonPageViewModel()
    {
        _dialogService = new DialogService();
        _toastService = ToastService.Instance;
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
                _toastService.ShowSuccess("You clicked YES");
                break;
            case DialogResults.No:
                Console.WriteLine("User clicked No!");
                _toastService.ShowError("You clikced NO");
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


    [RelayCommand]
    private void ShowInfoToast()
    {
        _toastService.Show("Info Toast ....");
    }

    [RelayCommand]
    private void ShowSuccessToast()
    {
        _toastService.ShowSuccess("Success Toast ...");
    }

    [RelayCommand]
    private void ShowWaringToast()
    {
        _toastService.ShowWarning("Warning Toast ....");
    }

    [RelayCommand]
    private void ShowErrorToast()
    {
        _toastService.ShowError("Something went wrong!");
    }

}
