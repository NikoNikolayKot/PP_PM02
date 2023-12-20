using PP_PM02_Koshenskiy.classes;
using PP_PM02_Koshenskiy.pages.role;
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

namespace PP_PM02_Koshenskiy.pages.menu
{
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Page
    {
        public authorization()
        {
            InitializeComponent();
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Length > 0 && tbPassword.Text.Length > 0)
            {
                var client = AppModel.dbModel.Client.FirstOrDefault(x => x.password.Equals(tbPassword.Text) && x.login.Equals(tbLogin.Text));
                if (client != null)
                {
                    switch (client.role_id)
                    {
                        case 1:
                            MessageBox.Show("Выполняется вход, подождите...\nЗдравствуйте Администратор: " + client.last_name, "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new administrator());
                            break;
                        case 2:
                            MessageBox.Show("Выполняется вход, подождите...\nЗдравствуйте Менеджер: " + client.last_name, "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new manager());
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Не все данные введены корректно,\nпроверьте введенные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new mainDialog());
        }
    }
}
