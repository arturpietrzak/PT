using PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    class NavigateCustomers : CommandBase
    {
        private NavigationModel navigationModel;
        private ICustomerService customerService;
        private IPurchaseService purchaseService;

        public NavigateCustomers(NavigationModel navigationModel)
        {
            this.navigationModel = navigationModel;

            this.customerService = ICustomerService.CreateAPI();
            this.purchaseService = IPurchaseService.CreateAPI();
        }

        public override void Execute(object parameter)
        {
            navigationModel.CurrentViewModel = new CustomersViewModel(this.navigationModel, new CustomerModel(customerService), new PurchaseModel(purchaseService));
        }
    }
}
