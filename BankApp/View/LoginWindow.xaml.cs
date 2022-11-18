﻿using BankApp.ViewModel;
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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public MainWindow MainWindow { get; set; }
        public LoginWindowVM loginWindowVM { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            loginWindowVM = Resources["vm"] as LoginWindowVM;
            loginWindowVM.Authenticated += Authenticated;
            loginWindowVM.CloseWindow += CloseWindow;
        }
        private void Authenticated(object? sender, EventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }

        private void СloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CloseWindow(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
