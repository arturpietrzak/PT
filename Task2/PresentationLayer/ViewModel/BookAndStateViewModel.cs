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
    internal class BookAndStateViewModel : ViewModelBase
    {
        private IBookService bookService;
        private IStateService stateService;
        private IPurchaseService purchaseService;

        private ICollection<IBookData> _bookData;
        public ICollection<IBookData> bookData
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

        private IEnumerable<IStateData> _stateData;
        public IEnumerable<IStateData> stateData
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
        public BookAndStateViewModel(NavigationModel navigationModel)
        {
            bookService = IBookService.CreateAPI();
            purchaseService = IPurchaseService.CreateAPI();
            stateService = IStateService.CreateAPI();

            bookData = bookService.GetAllBooks();
            stateData = new List<IStateData>();

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
            bool added = bookService.AddBook(newId, newName, newPages, newPrice);

            if (added)
            {
                RefreshBooksCommand.Execute(this);
            }
            else
            {
                // TODO message if error 
            }
        }

        private void UpdateBook()
        {
            bool updated = bookService.UpdateBook(newId, newName, newPages, newPrice);

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
            bookData = bookService.GetAllBooks();
        }

        private void CheckDetails()
        {
            stateService = IStateService.CreateAPI();

            List<IStateData> list = new List<IStateData>();
            IStateData v_stateData = stateService.GetStateByBookId(detailId);

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
            bool purchased = purchaseService.HandlePurchase(
                    purchaseCustomerId,
                    purchaseBookId,
                    stateService.GetStateByBookId(purchaseBookId).State_Id
                );

            if (purchased)
            {
                CheckDetailsCommand.Execute(this);
                RefreshBooksCommand.Execute(this);
            }
            else
            {
                // TODO message if error 
            }
        }

        private void DeleteBook()
        {
            bool deleted = bookService.DeleteBook(detailId);
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
            bool updated = stateService.UpdateStateAmount(updateAmountId, updateAmount);
            if (updated)
            {
                RefreshBooksCommand.Execute(this);
            }
            else
            {
                // TODO message if error 
            }
        }
    }
}