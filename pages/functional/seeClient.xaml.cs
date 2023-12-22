using PP_PM02_Koshenskiy.classes;
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

namespace PP_PM02_Koshenskiy.pages.functional
{
    /// <summary>
    /// Логика взаимодействия для seeClient.xaml
    /// </summary>
    public partial class seeClient : Page
    {
        public seeClient()
        {
            InitializeComponent();

            bAddClient.Visibility = Visibility.Hidden;
            bDelete.Visibility = Visibility.Hidden;

            lvClient.ItemsSource = AppModel.dbModel.Client.ToList();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bAddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvClient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
