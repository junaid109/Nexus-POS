using CommunityToolkit.Mvvm.ComponentModel;

namespace NexusPOS.Shell.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo<T>() where T : ObservableObject;
    }
}
