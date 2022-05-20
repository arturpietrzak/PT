using PresentationLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
    internal class PurchasesViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        private IPurchaseModelData _purchases { get; }

        public PurchasesViewModel(NavigationModel navigationModel, IPurchaseModelData purchases)
        {
            NavigateHomeCommand = new NavigateHome(navigationModel);
            _purchases = purchases;
        }
    }
}