using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.API;

namespace PresentationLayer.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateBookAndStateCommand { get; }
        public ICommand NavigateCustomersCommand { get; }
        public ICommand NavigateEventsCommand { get; }

        public HomeViewModel(NavigationModel navigationModel)
        {
            NavigateHomeCommand = new NavigateHome(navigationModel);
            NavigateBookAndStateCommand = new NavigateBookAndState(navigationModel);
            NavigateCustomersCommand = new NavigateCustomers(navigationModel);
            NavigateEventsCommand = new NavigatePurchases(navigationModel);
        }
    }
}