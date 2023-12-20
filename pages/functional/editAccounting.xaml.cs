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
    /// Логика взаимодействия для editAccounting.xaml
    /// </summary>
    public partial class editAccounting : Page
    {
        Accounting accountingLocal = null;
        public editAccounting(Accounting accounting)
        {
            InitializeComponent();

            accountingLocal = accounting;

            cbPriority.DisplayMemberPath = "name";
            cbPriority.SelectedValuePath = "priority_id";
            cbPriority.ItemsSource = AppModel.dbModel.Priority.ToList();

            cbWizard.DisplayMemberPath = "last_name";
            cbWizard.SelectedValuePath = "wizard_id";
            cbWizard.ItemsSource = AppModel.dbModel.Wizard.ToList();

            cbStatus.DisplayMemberPath = "name";
            cbStatus.SelectedValuePath = "status_id";
            cbStatus.ItemsSource = AppModel.dbModel.Status.ToList();

            tbCost.Text = 0 + "";

            AppModel.dbModel.Accounting.Remove(accounting);
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            Accounting accounting = new Accounting()
            {
                request_id = accountingLocal.request_id,
                date_reception = accountingLocal.date_reception,
                Priority = cbPriority.SelectedItem as Priority,
                Wizard = cbWizard.SelectedItem as Wizard,
                Status = cbStatus.SelectedItem as Status,
                repair_price = decimal.Parse(tbCost.Text),
            };
            AppModel.dbModel.Accounting.Add(accounting);
            AppModel.dbModel.SaveChanges();

            MessageBox.Show("Запись была успешно дополнена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            
            NavigationService.GoBack();
        }
    }
}
