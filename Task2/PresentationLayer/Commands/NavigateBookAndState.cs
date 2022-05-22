using PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    class NavigateBookAndState : CommandBase
    {
        private NavigationModel navigationModel;
        private IBookService bookService;
        private IStateService stateService;
        private IPurchaseService purchaseService;

        public NavigateBookAndState(NavigationModel navigationModel)
        {
            this.navigationModel = navigationModel;
            this.bookService = IBookService.CreateAPI();
            this.stateService = IStateService.CreateAPI();
            this.purchaseService = IPurchaseService.CreateAPI();
        }

        // Set NavigationModel currentModel to home view
        public override void Execute(object parameter)
        {
            navigationModel.CurrentViewModel = new BookAndStateViewModel(this.navigationModel, new BookModel(bookService), new StateModel(stateService), new PurchaseModel(purchaseService));
        }
    }
}
