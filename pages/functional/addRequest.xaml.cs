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
    /// Логика взаимодействия для addRequest.xaml
    /// </summary>
    public partial class addRequest : Page
    {
        public addRequest()
        {
            InitializeComponent();

            cbTypeEquipment.DisplayMemberPath = "name";
            cbTypeEquipment.SelectedValuePath = "type_equipment_id";
            cbTypeEquipment.ItemsSource = AppModel.dbModel.Type_equipment.ToList();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            var clientObj = AppModel.dbModel.Client.FirstOrDefault(x => x.phone.Equals(tbPhone.Text) && x.last_name.Equals(tbLastName.Text));
            if (clientObj == null)
            {
                Client client = new Client()
                {
                    last_name = tbLastName.Text,
                    phone = tbPhone.Text,
                };
                AppModel.dbModel.Client.Add(client);
                AppModel.dbModel.SaveChanges();
                MessageBox.Show("Клиент не был обнаружен в нашей БД, \nОн был добавлен", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            clientObj = AppModel.dbModel.Client.FirstOrDefault(x => x.phone.Equals(tbPhone.Text) && x.last_name.Equals(tbLastName.Text));
            Request request = new Request() {
                client_id = clientObj.client_id,
                Type_equipment1 = cbTypeEquipment.SelectedItem as Type_equipment,
                serial_number = tbSerialNumber.Text,
                problem_description = tbDescription.Text,
                type_malfunction = tbTypeProblem.Text,
            };
            AppModel.dbModel.Request.Add(request);
            AppModel.dbModel.SaveChanges();
            MessageBox.Show("Заявка была успешно добавлена и\nнаходится в рассмотрении", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);

            Accounting accounting = new Accounting()
            {
                request_id = request.request_id,
                date_reception = DateTime.Now,
            };
            AppModel.dbModel.Accounting.Add(accounting);
            AppModel.dbModel.SaveChanges();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
