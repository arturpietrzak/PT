using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayer.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private NavigationModel navigationModel;
        public ViewModelBase CurrentViewModel => navigationModel.CurrentViewModel;
        public MainViewModel(NavigationModel navigationModel)
        {
            this.navigationModel = navigationModel;
            this.navigationModel.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
