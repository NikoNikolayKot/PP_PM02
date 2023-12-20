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
    /// Логика взаимодействия для seeRequest.xaml
    /// </summary>
    public partial class seeRequest : Page
    {
        public seeRequest(int logic)
        {
            InitializeComponent();

            switch (logic)
            {
                case 0:
                    lvRequest.ItemsSource = AppModel.dbModel.Request.Where(x => x.serial_number.Equals(tbSerialNumber.Text)).ToList();
                    break;
                case 1:
                    lvRequest.ItemsSource = AppModel.dbModel.Request.ToList();
                    break;
            }
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bAddClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new addRequest());
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvRequest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void tbSerialNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvRequest.ItemsSource = AppModel.dbModel.Request.Where(x => x.serial_number.Equals(tbSerialNumber.Text)).ToList();
        }
    }
}
