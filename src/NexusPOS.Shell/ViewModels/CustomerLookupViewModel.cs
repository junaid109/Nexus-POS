using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusPOS.Shell.Interfaces;
using NexusPOS.Shell.ViewModels;
using NexusPOS.Application.Interfaces;
using System.Threading.Tasks;

namespace NexusPOS.Shell.ViewModels
{
    public partial class CustomerLookupViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IClubcardService _clubcardService;
        private readonly CustomerOverviewViewModel _overviewViewModel; // Hack for passing data, better to use a shared state service or messaging

        [ObservableProperty]
        private string customerIdentifier;

        [ObservableProperty]
        private string errorMessage;

        public CustomerLookupViewModel(INavigationService navigationService, IClubcardService clubcardService, CustomerOverviewViewModel overviewViewModel)
        {
            _navigationService = navigationService;
            _clubcardService = clubcardService;
            _overviewViewModel = overviewViewModel;
        }

        [RelayCommand]
        public async Task Search()
        {
             ErrorMessage = "Searching...";
             var customer = await _clubcardService.GetCustomerAsync(CustomerIdentifier);
             
             if (customer != null)
             {
                 _overviewViewModel.CustomerName = customer.Name;
                 _overviewViewModel.PointsBalance = customer.PointsBalance;
                 _navigationService.NavigateTo<CustomerOverviewViewModel>();
                 ErrorMessage = "";
             }
             else
             {
                 ErrorMessage = "Customer not found.";
             }
        }

        [RelayCommand]
        public void GoBack()
        {
            _navigationService.NavigateTo<HelloViewModel>();
        }
    }
}
