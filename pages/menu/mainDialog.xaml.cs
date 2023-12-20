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

using PP_PM02_Koshenskiy.pages.role;

namespace PP_PM02_Koshenskiy.pages.menu
{
    /// <summary>
    /// Логика взаимодействия для mainDialog.xaml
    /// </summary>
    public partial class mainDialog : Page
    {
        public mainDialog()
        {
            InitializeComponent();
        }

        private void bAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new authorization());
        }

        private void bGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new guest());
        }
    }
}
