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
        private IBookModelData _books { get; }
        private IStateModelData _states { get; }
        public ICommand NavigateHomeCommand { get; }

        public BookAndStateViewModel(NavigationModel navigationModel, IBookModelData bookModelData, IStateModelData stateModelData)
        {
            NavigateHomeCommand = new NavigateHome(navigationModel);
            _books = bookModelData;
            _states = stateModelData;
        }
    }
}