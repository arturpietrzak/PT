using PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer
{
    class NavigateCustomers : CommandBase
    {
        private NavigationModel navigationModel;

        public NavigateCustomers(NavigationModel navigationModel)
        {
            this.navigationModel = navigationModel;
        }

        // Set NavigationModel currentModel to home view
        public override void Execute(object parameter)
        {
            navigationModel.CurrentViewModel = new CustomersViewModel(this.navigationModel);
        }
    }
}
