using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.API;

namespace PresentationLayer.ViewModel
{
    internal class BookAndStateViewModel : ViewModelBase
    {
        private IBookModel bookModel;
        private IStateModel stateModel;
        private IPurchaseModel purchaseModel;

        private ICollection<IBookModelData> _bookData;
        public ICollection<IBookModelData> bookData
        {
            get
            {
                return _bookData;
            }
            set
            {
                _bookData = value;
                OnPropertyChanged("bookData");
            }
        }

        private ICollection<IStateModelData> _stateData;
        public ICollection<IStateModelData> stateData
        {
            get
            {
                return _stateData;
            }
            set
            {
                _stateData = value;
                OnPropertyChanged("stateData");
            }
        }

        // for new book
        private int _newId;
        public int newId
        {
            get
            {
                return _newId;
            }
            set
            {
                _newId = value;

                OnPropertyChanged("newId");
            }
        }

        private String _newName;
        public String newName
        {
            get
            {
                return _newName;
            }
            set
            {
                _newName = value;

                OnPropertyChanged("newName");
            }
        }

        private int _newPages;
        public int newPages
        {
            get
            {
                return _newPages;
            }
            set
            {
                _newPages = value;

                OnPropertyChanged("newPages");
            }
        }

        private double _newPrice;
        public double newPrice
        {
            get
            {
                return _newPrice;
            }
            set
            {
                _newPrice = value;

                OnPropertyChanged("newPrice");
            }
        }

        // for viewing details and deleting
        private int _detailId;
        public int detailId
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

        // for purchase
        private int _purchaseBookId;
        public int purchaseBookId
        {
            get
            {
                return _purchaseBookId;
            }
            set
            {
                _purchaseBookId = value;

                OnPropertyChanged("purchaseBookId");
            }
        }

        private int _purchaseCustomerId;
        public int purchaseCustomerId
        {
            get
            {
                return _purchaseCustomerId;
            }
            set
            {
                _purchaseCustomerId = value;

                OnPropertyChanged("purchaseCustomerId");
            }
        }
        // for updating amount in state of a specified book
        private int _updateAmountId;
        public int updateAmountId
        {
            get
            {
                return _updateAmountId;
            }
            set
            {
                _updateAmountId = value;

                OnPropertyChanged("updateAmountId");
            }
        }
        private int _updateAmount;
        public int updateAmount
        {
            get
            {
                return _updateAmount;
            }
            set
            {
                _updateAmount = value;

                OnPropertyChanged("updateAmount");
            }
        }

        // Constructor
        public BookAndStateViewModel(NavigationModel navigationModel, IBookModel bookModel, IStateModel stateModel, IPurchaseModel purchaseModel)
        {
            this.bookModel = bookModel;
            this.stateModel = stateModel;
            this.purchaseModel = purchaseModel;

            bookData = bookModel.GetAllBooks();
            stateData = new List<IStateModelData>();

            NavigateHomeCommand = new NavigateHome(navigationModel);
            AddBookCommand = new RelayCommand(AddBook);
            UpdateBookCommand = new RelayCommand(UpdateBook);
            RefreshBooksCommand = new RelayCommand(RefreshBooks);
            CheckDetailsCommand = new RelayCommand(CheckDetails);
            PurchaseBookCommand = new RelayCommand(PurchaseBook);
            DeleteBookCommand = new RelayCommand(DeleteBook);
            UpdateAmountCommand = new RelayCommand(UpdateAmount);
        }


        // Commands
        public ICommand NavigateHomeCommand { get; private set; }
        public ICommand AddBookCommand { get; private set; }
        public ICommand UpdateBookCommand { get; private set; }
        public ICommand RefreshBooksCommand { get; private set; }
        public ICommand CheckDetailsCommand { get; private set; }
        public ICommand PurchaseBookCommand { get; private set; }
        public ICommand DeleteBookCommand { get; private set; }
        public ICommand UpdateAmountCommand { get; private set; }

        // Functions for commands
        private void AddBook()
        {
            bool added = bookModel.Service.AddBook(newId, newName, newPages, newPrice);

            if (added)
            {
            }
            else
            {
                // TODO message if error 
            }
        }

        private void UpdateBook()
        {
            bool updated = bookModel.Service.UpdateBook(newId, newName, newPages, newPrice);

            if (updated)
            {
                RefreshBooksCommand.Execute(this);
            }
            else
            {
                // TODO message if error 
            }
        }

        private void RefreshBooks()
        {
            bookData = bookModel.GetAllBooks();
        }

        private void CheckDetails()
        {
            List<IStateModelData> list = new List<IStateModelData>();
            IStateModelData v_stateData = stateModel.GetStateByBookId(detailId);

            if (v_stateData == null)
            {
                stateData = list;
                return;
            }

            list.Add(v_stateData);
            stateData = list;
        }

        private void PurchaseBook()
        {
            if (stateModel.Service.GetStateByBookId(purchaseBookId) == null)
            {
                return;
            }

            bool purchased = purchaseModel.Service.HandlePurchase(
                    purchaseCustomerId,
                    purchaseBookId,
                    stateModel.Service.GetStateByBookId(purchaseBookId).State_Id
                );

            stateModel.Service.UpdateStateAmount(purchaseBookId, stateModel.Service.GetStateByBookId(purchaseBookId).Amount - 1);


            if (purchased)
            {
            }
            else
            {
                // TODO message if error 
            }

            CheckDetails();

        }

        private void DeleteBook()
        {
            bool deleted = bookModel.Service.DeleteBook(detailId);
            if (deleted)
            {
                RefreshBooksCommand.Execute(this);
            }
            else
            {
                // TODO message if error 
            }
        }

        private void UpdateAmount()
        {
            bool updated = stateModel.Service.UpdateStateAmount(updateAmountId, updateAmount);
            if (updated)
            {

            }
            else
            {
                // TODO message if error 
            }
        }
    }
}