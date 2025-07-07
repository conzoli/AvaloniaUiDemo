using System.Threading.Tasks;

namespace FluentDesignDemo.Dialogs;

public interface IDialogService
{
    Task<T> OpenDialog<T>(DialogViewModelBase<T> viewModel);
}
