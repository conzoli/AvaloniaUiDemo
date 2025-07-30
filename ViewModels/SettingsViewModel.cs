using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using FluentDesignDemo.Services;

namespace FluentDesignDemo.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{


    private readonly ToastService _toastService;

    public SettingsViewModel(ToastService toastService)
    {
        _toastService = toastService;
    }


    [RelayCommand]
    private void Taost()
    {
        _toastService.Show("Info Toast ....");
    }

}
