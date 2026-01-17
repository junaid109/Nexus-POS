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
             // TODO: Go to Scan ViewModel (Phase 2)
             System.Diagnostics.Debug.WriteLine("Navigate to Scan (Phase 2)");
        }
    }
}
