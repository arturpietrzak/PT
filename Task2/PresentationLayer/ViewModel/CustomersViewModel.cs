using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.API;
using ServiceLayer.API;

namespace PresentationLayer.ViewModel
{
    internal class CustomersViewModel : ViewModelBase
    {
        private ICustomerModelData _customersData { get; }

        public CustomersViewModel(NavigationModel navigationModel, ICustomerModelData customers)
        {
            NavigateHomeCommand = new NavigateHome(navigationModel);
            _customersData = customers;

        }

        public ICommand NavigateHomeCommand { get; }
        public ICommand AddCustomerCommand { get; }
    }
}