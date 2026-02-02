using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusPOS.Shell.Interfaces;
using NexusPOS.Shell.ViewModels;

namespace NexusPOS.Shell.ViewModels
{
    public partial class CustomerOverviewViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string customerName = "Guest";

        [ObservableProperty]
        private int pointsBalance = 0;

        public CustomerOverviewViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        public void StartShopping()
        {
             _navigationService.NavigateTo<ScanViewModel>();
        }
    }
}
