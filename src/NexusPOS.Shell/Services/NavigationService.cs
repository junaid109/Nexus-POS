using CommunityToolkit.Mvvm.ComponentModel;
using NexusPOS.Shell.Interfaces;
using System;

namespace NexusPOS.Shell.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Func<Type, ObservableObject> _viewModelFactory;
        private readonly Action<ObservableObject> _setCurrentViewModel;

        public NavigationService(Func<Type, ObservableObject> viewModelFactory, Action<ObservableObject> setCurrentViewModel)
        {
            _viewModelFactory = viewModelFactory;
            _setCurrentViewModel = setCurrentViewModel;
        }

        public void NavigateTo<T>() where T : ObservableObject
        {
            var viewModel = _viewModelFactory(typeof(T));
            _setCurrentViewModel(viewModel);
        }
    }
}
