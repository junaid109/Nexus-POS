using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusPOS.Shell.Interfaces;
using NexusPOS.Application.Interfaces;
using System.Diagnostics;

namespace NexusPOS.Shell.ViewModels
{
    public partial class HelloViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        
        // We keep the logic for the Hello screen here
        [ObservableProperty]
        private string welcomeMessage = "Hello.";
        
        public HelloViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        public void StartScanning()
        {
            _navigationService.NavigateTo<ScanViewModel>(); 
        }

        [RelayCommand]
        public void FindItem()
        {
             _navigationService.NavigateTo<CustomerLookupViewModel>();
        }
        
        [RelayCommand]
        public void CallAssistance() 
        {
             _navigationService.NavigateTo<StaffAccessViewModel>();
        }
        
        [RelayCommand]
        public void ChangeVolume() { }
        
        [RelayCommand]
        public void UseOwnBag() { }
    }
}
