using BankApp.Model;
using BankApp.Model.Interfaces;
using BankApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                if(App.Employee == null)
                {
                    Close();
                }
                else
                {
                    IsReadOnlySetter(App.Employee);
                    MainWindowVM.GetClients();
                }
            }
        }
        private void IsReadOnlySetter(object item)
        {
            if (item == null)
            {
                return;
            }
            IEmployee employee = item as IEmployee;

            if(employee is Manager)
            {
                lastNameTextBox.IsReadOnly = false;
                firstNameTextBox.IsReadOnly = false;
                middleNameTextBox.IsReadOnly = false;
                phoneNumberTextBox.IsReadOnly = false;
                passportSeriesTextBox.IsReadOnly = false;
                passportNumberTextBox.IsReadOnly = false;
            }
            else if(employee is Consultant)
            {
                lastNameTextBox.IsReadOnly = true;
                firstNameTextBox.IsReadOnly = true;
                middleNameTextBox.IsReadOnly = true;
                phoneNumberTextBox.IsReadOnly = false;
                passportSeriesTextBox.IsReadOnly = true;
                passportNumberTextBox.IsReadOnly = true;
            }
        }
        //TODO: Добавить проверку того, кто сейчас работает в программе    
    }
}
