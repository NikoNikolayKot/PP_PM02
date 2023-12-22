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
    /// Логика взаимодействия для editRequest.xaml
    /// </summary>
    public partial class editRequest : Page
    {
        Request requestOld = null;
        public editRequest(Request request)
        {
            InitializeComponent();

            cbClient.SelectedValuePath = "client_id";
            cbClient.DisplayMemberPath = "last_name";
            cbClient.ItemsSource = AppModel.dbModel.Client.ToList();
            cbClient.SelectedIndex = request.client_id - 1;

            cbTypeEquipment.SelectedValuePath = "type_equipment_id";
            cbTypeEquipment.DisplayMemberPath = "name";
            cbTypeEquipment.ItemsSource = AppModel.dbModel.Type_equipment.ToList();
            cbTypeEquipment.SelectedIndex = request.type_equipment - 1;

            tbSerialNumber.Text = request.serial_number;
            tbProblemDescription.Text = request.problem_description;
            tbTypeMalfunction.Text = request.type_malfunction;

            requestOld = request;
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            AppModel.dbModel.Request.Remove(requestOld);
            Accounting accounting = AppModel.dbModel.Accounting.FirstOrDefault(x => x.request_id == requestOld.request_id);
            AppModel.dbModel.Accounting.Remove(accounting);

            Request request = new Request()
            {
                Client = cbClient.SelectedItem as Client,
                Type_equipment1 = cbTypeEquipment.SelectedItem as Type_equipment,
                serial_number = tbSerialNumber.Text,
                problem_description = tbProblemDescription.Text,
                type_malfunction = tbTypeMalfunction.Text,
            };

            Accounting accountingNew = new Accounting()
            {
                request_id = request.request_id,
                date_reception = accounting.date_reception,
                priority_id = accounting.priority_id,
                wizard_id = accounting.wizard_id,
                status_id = accounting.status_id,
                repair_price = accounting.repair_price,
            };

            AppModel.dbModel.Accounting.Add(accountingNew);
            AppModel.dbModel.Request.Add(request);

            AppModel.dbModel.SaveChanges();

            MessageBox.Show("Заявка была успешно изменена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.GoBack();
        }
    }
}
