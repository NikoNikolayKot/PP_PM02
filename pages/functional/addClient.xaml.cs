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
    /// Логика взаимодействия для addClient.xaml
    /// </summary>
    public partial class addClient : Page
    {
        public addClient()
        {
            InitializeComponent();

            cbRole.SelectedIndex = 1;
            cbRole.DisplayMemberPath = "name";
            cbRole.SelectedValuePath = "role_id";
            cbRole.ItemsSource = AppModel.dbModel.Role.ToList();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client()
            {
                last_name = tbLastName.Text,
                phone = tbPhone.Text,
                login = tbLogin.Text,
                password = tbPassword.Text,
                Role = cbRole.SelectedItem as Role,
            };
            AppModel.dbModel.Client.Add(client);
            AppModel.dbModel.SaveChanges();

            MessageBox.Show("Пользователь был успешно добавлена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
