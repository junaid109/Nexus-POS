using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusPOS.Shell.Interfaces;
using NexusPOS.Shell.ViewModels;

namespace NexusPOS.Shell.ViewModels
{
    public partial class CustomerLookupViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string customerIdentifier;

        public CustomerLookupViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        public void Search()
        {
             // Mock success
             _navigationService.NavigateTo<CustomerOverviewViewModel>();
        }

        [RelayCommand]
        public void GoBack()
        {
            _navigationService.NavigateTo<HelloViewModel>();
        }
    }
}
