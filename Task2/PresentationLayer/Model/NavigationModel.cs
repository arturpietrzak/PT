using PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;


namespace PresentationLayer.API
{
    // Class used to store current ViewModel to switch between views
    public class NavigationModel
    {
        public event Action CurrentViewModelChanged;
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel {     
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
