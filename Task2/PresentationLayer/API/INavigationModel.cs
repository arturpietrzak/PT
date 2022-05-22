using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.ViewModel;

namespace PresentationLayer.API
{
    public abstract class INavigationModel
    {
        public abstract ViewModelBase CurrentViewModel();
        public abstract void OnCurrentViewModelChanged();
        public static INavigationModel testModel()
        {
            return new TestNavigationModel();
        }

        private class TestNavigationModel : INavigationModel
        {
            public override ViewModelBase CurrentViewModel()
            {
                return null;
            }
            public override void OnCurrentViewModelChanged()
            {
            }
        }
    }
}
