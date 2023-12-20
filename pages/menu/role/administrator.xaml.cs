using PP_PM02_Koshenskiy.pages.functional;
using PP_PM02_Koshenskiy.pages.menu;
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

namespace PP_PM02_Koshenskiy.pages.role
{
    /// <summary>
    /// Логика взаимодействия для administrator.xaml
    /// </summary>
    public partial class administrator : Page
    {
        public administrator()
        {
            InitializeComponent();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bSeeAccounting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new seeAccounting());
        }

        private void bSeeRequest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new seeRequest(1));
        }

        private void bAddUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new addClient());
        }

        private void bSeeUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new seeClient());
        }
    }
}
