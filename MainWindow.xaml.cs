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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PP_PM02_Koshenskiy.pages.functional;
using PP_PM02_Koshenskiy.pages.menu;
using PP_PM02_Koshenskiy.classes;

namespace PP_PM02_Koshenskiy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DoubleAnimation animationLeftMenu = new DoubleAnimation();
        bool LeftMenuIsWide = false;

        public MainWindow()
        {
            InitializeComponent();

            AppModel.dbModel = new database.dbName();

            fMain.NavigationService.Navigate(new mainDialog());

            bAddRequest.Visibility = Visibility.Hidden;
            bSeeRequest.Visibility = Visibility.Hidden;
            bLoginIn.Visibility = Visibility.Hidden;

            animationLeftMenu.Duration = TimeSpan.FromSeconds(0.3);
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void bMinimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void spLeftMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            if (LeftMenuIsWide == false)
            {
                if (this.spLeftMenu.IsMouseOver)
                {
                    animationLeftMenu.From = 50;
                    animationLeftMenu.To = 220;
                    spLeftMenu.BeginAnimation(StackPanel.WidthProperty, animationLeftMenu);
                }
                tbTitleLeftMenu.FontSize = 45;

                bAddRequest.Visibility = Visibility.Visible;
                bSeeRequest.Visibility = Visibility.Visible;
                bLoginIn.Visibility = Visibility.Visible;

                LeftMenuIsWide = true;
            }

        }

        private void fMain_MouseEnter(object sender, MouseEventArgs e)
        {
            if (LeftMenuIsWide == true)
            {
                if (this.fMain.IsMouseOver)
                {
                    animationLeftMenu.From = 220;
                    animationLeftMenu.To = 50;
                    spLeftMenu.BeginAnimation(StackPanel.WidthProperty, animationLeftMenu);
                }
                tbTitleLeftMenu.FontSize = 16;

                bAddRequest.Visibility = Visibility.Hidden;
                bSeeRequest.Visibility = Visibility.Hidden;
                bLoginIn.Visibility = Visibility.Hidden;

                LeftMenuIsWide = false;
            }
        }

        private void bAddRequest_Click(object sender, RoutedEventArgs e)
        {
            fMain.NavigationService.Navigate(new addRequest());
        }

        private void bSeeRequest_Click(object sender, RoutedEventArgs e)
        {
            fMain.NavigationService.Navigate(new seeRequest(0));
        }

        private void bLoginIn_Click(object sender, RoutedEventArgs e)
        {
            fMain.NavigationService.Navigate(new authorization());
        }
    }
}
