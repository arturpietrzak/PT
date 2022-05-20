using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PresentationLayer.ViewModel;

namespace PresentationLayer
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationModel navigationModel = new NavigationModel();
            navigationModel.CurrentViewModel = new HomeViewModel(navigationModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

/*    */