using Avalonia.Controls;
namespace FluentDesignDemo.Dialogs;

public abstract class DialogViewModelBase<T>
{

    public string? Title { get; set; }
    public string? Message { get; set; }
    public T? DialogResults { get; set; }

    public DialogViewModelBase() : this(string.Empty, string.Empty) { }
    public DialogViewModelBase(string title) : this(title, string.Empty) { }



    public DialogViewModelBase(string title, string message)
    {
        Title = title;
        Message = message;
    }

    public void CloseDialogWithResult(Window dialog, T result)
    {
        DialogResults = result;
        dialog.Close();
    }

}
