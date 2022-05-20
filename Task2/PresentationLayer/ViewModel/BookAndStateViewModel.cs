using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer;

namespace PresentationLayer.ViewModel
{
    internal class BookAndStateViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        public BookAndStateViewModel(NavigationModel navigationModel)
        {
            NavigateHomeCommand = new NavigateHome(navigationModel);
        }
    }
}