using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentDesignDemo.Models;
using FluentDesignDemo.Services;
using FluentDesignDemo.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FluentDesignDemo.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ToastService _toastService;
    private readonly DialogService _dialogService;
    private readonly IServiceProvider _serviceProvider;

    public MainWindowViewModel(ToastService toastService, DialogService dialogService, IServiceProvider serviceProvider)
    {
        _toastService = toastService;
        _dialogService = dialogService;
        _serviceProvider = serviceProvider;
        _currentPage = _serviceProvider.GetService(typeof(HomePageViewModel)) as ViewModelBase ?? new HomePageViewModel();
    }

    public ObservableCollection<Toast> Toasts => _toastService.Toasts;

    [ObservableProperty]
    private bool _isPaneOpen = true;


    [ObservableProperty]
    private ViewModelBase _currentPage;


    [ObservableProperty]
    private ListItemTemplate? _selectedListItem;


    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;
        var instance = _serviceProvider.GetService(value.ModelType) as ViewModelBase;
        if (instance is null) return;
        CurrentPage = instance;
    }


    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomePageViewModel), "HomeRegular"),
        new ListItemTemplate(typeof(ButtonPageViewModel),"CursorHoverRegular"),
        new ListItemTemplate(typeof(InputValidationViewModel),"InputValidationRegular"),
    };



    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }


    [RelayCommand]
    private void ShowSettingsContol()
    {
        var SettingsViewModel = _serviceProvider.GetService<SettingsViewModel>();

        if (SettingsViewModel is null)
        {
            return;
        }

        CurrentPage = SettingsViewModel;

    
    }

}

public class ListItemTemplate
{
    public ListItemTemplate(Type type, string iconKey)
    {

        ModelType = type;
        Label = type.Name.Replace("PageViewModel", "");

        Application.Current!.TryFindResource(iconKey, out var res);

        ListItemIcon = (StreamGeometry)res!;

    }

    public string Label { get; }
    public Type ModelType { get; }

    public StreamGeometry ListItemIcon { get; }
}
