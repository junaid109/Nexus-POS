using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NexusPOS.Application.Interfaces;
using NexusPOS.Infrastructure.Services;
using NexusPOS.Shell.Interfaces;
using NexusPOS.Shell.Services;
using NexusPOS.Shell.ViewModels;
using System;
using System.Windows;

namespace NexusPOS.Shell
{
    public partial class App : System.Windows.Application
    {
        public new static App Current => (App)System.Windows.Application.Current;
        public IServiceProvider Services { get; }

        public App()
        {
            InitializeComponent();
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Services
            services.AddSingleton<IScannerService, MockScannerService>();
            services.AddSingleton<IClubcardService, MockClubcardService>();
            
            // Navigation Setup
            services.AddSingleton<INavigationService>(provider => 
                new NavigationService(
                    viewModelFactory: type => (ObservableObject)provider.GetRequiredService(type),
                    setCurrentViewModel: viewModel => 
                    {
                        var mainViewModel = provider.GetRequiredService<MainViewModel>();
                        mainViewModel.CurrentViewModel = viewModel;
                    }
                ));

            // ViewModels
            services.AddSingleton<MainViewModel>(); // Main Shell must be Singleton
            services.AddTransient<HelloViewModel>();
            services.AddTransient<StaffAccessViewModel>();
            services.AddTransient<CustomerLookupViewModel>();
            services.AddTransient<StaffDashboardViewModel>();
            services.AddTransient<CustomerOverviewViewModel>();
            services.AddTransient<ScanViewModel>();

            // Views
            services.AddTransient<MainWindow>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = Services.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }
    }
}
