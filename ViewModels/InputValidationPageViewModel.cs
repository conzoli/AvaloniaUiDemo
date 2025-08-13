using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FluentDesignDemo.ViewModels;

public partial class InputValidationPageViewModel : ViewModelBase
{

    [ObservableProperty]
    [MinLength(3, ErrorMessage = "Muss mind. 3 Zeichen lang sein!")]
    private string _firstname = string.Empty;


    [ObservableProperty]
    [MinLength(3, ErrorMessage = "Muss mind. 3 Zeichen lang sein!")]
    private string _lastname = string.Empty;


    [ObservableProperty]
    [Required(ErrorMessage = "E-Mail-Adresses ist ein Pflichtfeld!")]
    [EmailAddress(ErrorMessage = "Keine gueltige E-Mail_Adresse!")]
    private string email = string.Empty;




    [ObservableProperty]
    private string _errMsg = string.Empty;


    [RelayCommand]
    private void SendButton()
    {

        ValidateAllProperties();

        if (HasErrors)
        {

            string msg = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));

            ErrMsg = msg;

        }
        else
        {
            ErrMsg = string.Empty;
        }


    }
    
}