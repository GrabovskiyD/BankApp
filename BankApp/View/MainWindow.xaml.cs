using BankApp.ViewModel;
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
using System.Windows.Shapes;

namespace BankApp.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM MainWindowVM;
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (App.Employee is null)
            {
                Visibility = Visibility.Collapsed;
                MainWindowVM = Resources["vm"] as MainWindowVM;
                LoginWindow LoginWindow = new LoginWindow()
                {
                    MainWindow = this
                };
                LoginWindow.Owner = this;
                LoginWindow.ShowDialog();
                MainWindowVM.GetClients();
                Visibility = Visibility.Visible;
            }
        }
        //TODO: Добавить проверку того, кто сейчас работает в программе    
    }
}
