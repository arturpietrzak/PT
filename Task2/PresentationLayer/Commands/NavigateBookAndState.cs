using PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer
{
    class NavigateBookAndState : CommandBase
    {
        private NavigationModel navigationModel;

        public NavigateBookAndState(NavigationModel navigationModel)
        {
            this.navigationModel = navigationModel;
        }

        // Set NavigationModel currentModel to home view
        public override void Execute(object parameter)
        {
            navigationModel.CurrentViewModel = new BookAndStateViewModel(this.navigationModel);
        }
    }
}
