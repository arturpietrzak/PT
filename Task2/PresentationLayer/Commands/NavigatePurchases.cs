using PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    class NavigatePurchases : CommandBase
    {
        private NavigationModel navigationModel;

        public NavigatePurchases(NavigationModel navigationModel)
        {
            this.navigationModel = navigationModel;
        }

        // Set NavigationModel currentModel to home view
        public override void Execute(object parameter)
        {
            navigationModel.CurrentViewModel = new PurchasesViewModel(this.navigationModel);
        }
    }
}
