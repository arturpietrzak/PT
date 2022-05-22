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
        private IPurchaseModel purchaseModel;
        private ICollection<IPurchaseModelData> _purchaseData;
        public ICollection<IPurchaseModelData> purchaseData
        {
            get
            {
                return _purchaseData;
            }
            set
            {
                _purchaseData = value;
                OnPropertyChanged("purchaseData");
            }
        }

        private IEnumerable<IPurchaseModelData> _detailData;
        public IEnumerable<IPurchaseModelData> detailData
        {
            get
            {
                return _detailData;
            }
            set
            {
                _detailData = value;
                OnPropertyChanged("detailData");
            }
        }

        // for viewing details and deleting
        private String _detailId;
        public String detailId
        {
            get
            {
                return _detailId;
            }
            set
            {
                _detailId = value;
                OnPropertyChanged("detailId");
            }
        }

        public PurchasesViewModel(NavigationModel navigationModel, IPurchaseModel purchaseModel)
        {
            this.purchaseModel = purchaseModel;
            purchaseData = purchaseModel.GetAllPurchases();

            NavigateHomeCommand = new NavigateHome(navigationModel);
            CheckDetailsCommand = new RelayCommand(CheckDetails);
        }

        public ICommand NavigateHomeCommand { get; private set; }
        public ICommand CheckDetailsCommand { get; private set; }

        private void CheckDetails()
        {
            List<IPurchaseModelData> list = new List<IPurchaseModelData>();
            IPurchaseModelData v_purchaseData = purchaseModel.GetPurchaseByID(detailId);

            if (v_purchaseData == null)
            {
                detailData = list;
                return;
            }

            list.Add(v_purchaseData);
            detailData = list;
        }

    }
}