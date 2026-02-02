using CommunityToolkit.Mvvm.ComponentModel;
using NexusPOS.Application.Interfaces;
using NexusPOS.Shell.Interfaces;
using System.Diagnostics;

namespace NexusPOS.Shell.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IScannerService _scannerService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableObject currentViewModel;

        public MainViewModel(IScannerService scannerService, INavigationService navigationService, HelloViewModel helloViewModel)
        {
            _scannerService = scannerService;
            _navigationService = navigationService;
            
            // Set initial view
            currentViewModel = helloViewModel; // Initialize backing field
            OnPropertyChanged(nameof(CurrentViewModel)); // Explicitly notify just in case

            _scannerService.BarcodeScanned += ScannerService_BarcodeScanned;
            _scannerService.Start();
        }

        private void ScannerService_BarcodeScanned(object? sender, string barcode)
        {
             System.Windows.Application.Current.Dispatcher.Invoke(() => 
             {
                 // Global barcode handling (e.g. if on Hello screen, maybe start transaction?)
                 Debug.WriteLine($"Global Scanner Hook: {barcode}");
                 
                 // If we were on Hello screen, we could auto-navigate to Scan screen here.
             });
        }
    }
}
