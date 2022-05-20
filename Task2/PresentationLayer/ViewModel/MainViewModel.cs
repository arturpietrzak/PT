using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("dsadasd\n\n\n\n");
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
