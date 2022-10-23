﻿using BankApp.Model;
using BankApp.View;
using BankApp.ViewModel.Commands;
using BankApp.ViewModel.CustomDPObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.ViewModel
{
    public class LoginWindowVM : INotifyPropertyChanged
    {
		private string username;

		public string Username
		{
			get { return username; }
			set
			{ 
				username = value;
				OnPropertyChanged("Username");
			}
		}
		private string password;

		public string Password
		{
			get { return password; }
			set 
			{ 
				password = value;
				OnPropertyChanged("Password");
			}
		}
		public LoginCommand LoginCommand { get; set; }

		public event PropertyChangedEventHandler? PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public LoginWindowVM()
		{
			LoginCommand = new LoginCommand(this);
		}

		public bool Login()
		{
			if(Username.ToLower().Equals("consultant") && Password.Equals("simple_password"))
			{
				App.Employee = new Consultant();
				return true;
			}
			else if(Username.ToLower().Equals("manager") && Password.Equals("complex_password"))
			{
				App.Employee = new Manager();
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool? dialogResult;

		public bool? DialogResult
		{
			get { return dialogResult; }
			set 
			{ 
				dialogResult = value;
				OnPropertyChanged("DialogResult");
			}
		}
        public static readonly DependencyProperty DialogResultProperty =
    DependencyProperty.RegisterAttached(
        "DialogResult",
        typeof(bool?),
        typeof(LoginWindowVM),
        new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
                window.DialogResult = e.NewValue as bool?;
        }
        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
