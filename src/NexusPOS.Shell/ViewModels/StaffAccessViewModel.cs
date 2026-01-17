using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusPOS.Shell.Interfaces;
using NexusPOS.Shell.ViewModels;

namespace NexusPOS.Shell.ViewModels
{
    public partial class StaffAccessViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string staffId;

        [ObservableProperty]
        private string pinCode;

        [ObservableProperty]
        private string errorMessage;

        public StaffAccessViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        public void Login()
        {
            if (StaffId == "admin" && PinCode == "1234")
            {
                 _navigationService.NavigateTo<StaffDashboardViewModel>();
            }
            else
            {
                ErrorMessage = "Invalid Staff ID or PIN";
            }
        }

        [RelayCommand]
        public void Cancel()
        {
            _navigationService.NavigateTo<HelloViewModel>();
        }
    }
}
