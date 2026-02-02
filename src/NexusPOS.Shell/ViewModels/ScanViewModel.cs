using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusPOS.Application.Interfaces;
using NexusPOS.Shell.Interfaces;
using NexusPOS.Shell.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NexusPOS.Shell.ViewModels
{
    public partial class ScanViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IScannerService _scannerService;

        [ObservableProperty]
        private ObservableCollection<BasketItem> basketItems = new();

        [ObservableProperty]
        private decimal basketTotal;

        public ScanViewModel(INavigationService navigationService, IScannerService scannerService)
        {
            _navigationService = navigationService;
            _scannerService = scannerService;
            
            // Subscribe to global scanner if this view is active
            // NOTE: meaningful scanner logic needs to be managed carefully 
            // so we don't scan while on other screens.
            // For now, we assume this VM is transient or we handle subscription in OnActivated.
        }

        [RelayCommand]
        public void Pay()
        {
            // TODO: Navigate to Payment (Phase 3)
            System.Diagnostics.Debug.WriteLine("Navigate to Payment");
        }

        [RelayCommand]
        public void VoidItem(BasketItem item)
        {
            if (BasketItems.Contains(item))
            {
                BasketItems.Remove(item);
                RecalculateTotal();
            }
        }

        // Simulates adding an item (to be called by scanner logic later)
        public void AddItem(string sku)
        {
            // Mock lookup
            var item = new BasketItem(sku, $"Product {sku}", 1.99m);
            BasketItems.Add(item);
            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            BasketTotal = BasketItems.Sum(i => i.Price * i.Quantity);
        }
    }
}
