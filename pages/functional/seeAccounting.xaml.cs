using PP_PM02_Koshenskiy.classes;
using PP_PM02_Koshenskiy.database;
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
    /// Логика взаимодействия для seeAccounting.xaml
    /// </summary>
    public partial class seeAccounting : Page
    {
        public seeAccounting()
        {
            InitializeComponent();

            bAdd.Visibility = Visibility.Hidden;
            bDelete.Visibility = Visibility.Hidden;

            cbDateSorter.SelectedIndex = 0;
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvRequest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Accounting accounting = lvRequest.SelectedItem as Accounting;
            NavigationService.Navigate(new editAccounting(accounting));
        }

        private void cbDateSorter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = cbDateSorter.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    lvRequest.ItemsSource = AppModel.dbModel.Accounting.ToList();
                    break;
                case 1:
                    lvRequest.ItemsSource = AppModel.dbModel.Accounting.OrderBy(x => x.date_reception).ToList();
                    break;
                case 2:
                    lvRequest.ItemsSource = AppModel.dbModel.Accounting.OrderByDescending(x => x.date_reception).ToList();
                    break;
            }
        }
    }
}
