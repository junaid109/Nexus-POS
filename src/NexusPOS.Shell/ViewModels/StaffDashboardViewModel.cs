using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusPOS.Shell.Interfaces;
using NexusPOS.Shell.ViewModels;

namespace NexusPOS.Shell.ViewModels
{
    public partial class StaffDashboardViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public StaffDashboardViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        public void Logout()
        {
            _navigationService.NavigateTo<HelloViewModel>();
        }
        
        [RelayCommand]
        public void OpenAdminPanel()
        {
            // Future Phase 4
        }
    }
}
