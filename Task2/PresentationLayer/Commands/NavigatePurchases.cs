using PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    class NavigatePurchases : CommandBase
    {
        private NavigationModel navigationModel;
        private IPurchaseService purchaseService;

        public NavigatePurchases(NavigationModel navigationModel)
        {
            this.navigationModel = navigationModel;
            this.purchaseService = IPurchaseService.CreateAPI();
        }

        // Set NavigationModel currentModel to home view
        public override void Execute(object parameter)
        {
            navigationModel.CurrentViewModel = new PurchasesViewModel(this.navigationModel, new PurchaseModel(purchaseService));
        }
    }
}
