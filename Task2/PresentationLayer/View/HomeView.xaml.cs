using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.View
{
    /// <summary>
    /// Logika interakcji dla klasy HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            // move to main view
        }

        private void ButtonBooks_Click(object sender, RoutedEventArgs e)
        {
            // move to view with books + states
        }

        private void ButtonUsers_Click(object sender, RoutedEventArgs e)
        {
            // move to view with users
        }

        private void ButtonEvents_Click(object sender, RoutedEventArgs e)
        {
            // move to view with events
        }
    }
}
