using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusPOS.Application.Interfaces;
using System.Diagnostics;

namespace NexusPOS.Shell.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IScannerService _scannerService;

        [ObservableProperty]
        private string welcomeMessage = "Hello.";

        public MainViewModel(IScannerService scannerService)
        {
            _scannerService = scannerService;
            _scannerService.BarcodeScanned += ScannerService_BarcodeScanned;
            _scannerService.Start();
        }

        private void ScannerService_BarcodeScanned(object? sender, string barcode)
        {
             // Marshaling to UI thread is handled by the platform usually, but in WPF we need Dispatcher.
             // Since this is a ViewModel, simpler to use App.Current.Dispatcher or a robust UI thread service.
             System.Windows.Application.Current.Dispatcher.Invoke(() => 
             {
                 WelcomeMessage = $"Scanned: {barcode}";
                 Debug.WriteLine($"Barcode scanned: {barcode}");
             });
        }

        [RelayCommand]
        public void StartScanning()
        {
            Debug.WriteLine("Start Scanning Clicked");
        }

        [RelayCommand]
        public void FindItem()
        {
             Debug.WriteLine("Find Item Clicked");
        }
        
        [RelayCommand]
        public void CallAssistance() { }
        
        [RelayCommand]
        public void ChangeVolume() { }
        
        [RelayCommand]
        public void UseOwnBag() { }
    }
}
