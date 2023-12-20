using PP_PM02_Koshenskiy.pages.functional;
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
    /// Логика взаимодействия для manager.xaml
    /// </summary>
    public partial class manager : Page
    {
        public manager()
        {
            InitializeComponent();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bSeeClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new seeClient());
        }

        private void bSeeAccounting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new seeAccounting());
        }
    }
}
