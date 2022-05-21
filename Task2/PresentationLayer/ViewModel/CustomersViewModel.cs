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
        private ICustomerService service;
        private ICollection<ICustomerData> _customerData;
        public ICollection<ICustomerData> customerData
        {
            get
            {
                return _customerData;
            }
            set
            {
                _customerData = value;
                OnPropertyChanged("customerData");
            }
        }
        private ICollection<IPurchaseData> _purchases;
        public ICollection<IPurchaseData> purchases
        {
            get
            {
                return _purchases;
            }
            set
            {
                _purchases = value;
                OnPropertyChanged("purchases");
            }
        }

        public CustomersViewModel(NavigationModel navigationModel)
        {
            service = ICustomerService.CreateAPI();
            customerData = service.GetAllCustomers();
            purchases = IPurchaseService.CreateAPI().GetAllPurchasesByCustomer(-999);

            NavigateHomeCommand = new NavigateHome(navigationModel);
            AddCustomerCommand = new RelayCommand(AddCustomer);
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
            RefreshCustomersCommand = new RelayCommand(RefreshCustomers);
            CheckPurchasesCommand = new RelayCommand(CheckPurchases);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);

        }

        private int _id;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;

                OnPropertyChanged("id");
            }
        }

        private int _selectedId;
        public int selectedId
        {
            get
            {
                return _selectedId;
            }
            set
            {
                _selectedId = value;

                OnPropertyChanged("selectedId");
            }
        }

        private String _name;
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        private String _surname;
        public String surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged("surname");
            }
        }

        public ICommand NavigateHomeCommand { get; private set; }
        public ICommand AddCustomerCommand { get; private set; }
        public ICommand UpdateCustomerCommand { get; private set; }
        public ICommand RefreshCustomersCommand { get; private set; }
        public ICommand CheckPurchasesCommand { get; private set; }
        public ICommand DeleteCustomerCommand { get; private set; }

        private void AddCustomer()
        {
            bool added = service.AddCustomer(id, name, surname);

            if (added)
            {
                RefreshCustomersCommand.Execute(this);
            } else
            {
                // TODO message if error 
            }

        }

        private void UpdateCustomer()
        {
            bool updated = service.UpdateCustomer(id, name, surname);

            if (updated)
            {
                RefreshCustomersCommand.Execute(this);
            }
            else
            {
                // TODO message if error 
            }
        }

        private void RefreshCustomers()
        {
            customerData = service.GetAllCustomers();
        }

        private void CheckPurchases()
        {
            purchases = IPurchaseService.CreateAPI().GetAllPurchasesByCustomer(selectedId);
        }

        private void DeleteCustomer()
        {
            bool deleted = service.DeleteCustomer(selectedId);

            if (deleted)
            {
                RefreshCustomersCommand.Execute(this);
            }
            else
            {
                // TODO message if error 
            }

        }
    }
}