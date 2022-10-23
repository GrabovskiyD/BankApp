using BankApp.Model;
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
		private string hiddenPassword = "";

		public string HiddenPassword
		{
			get { return hiddenPassword; }
			set 
			{ 
				Password = value;
				OnPropertyChanged("Password");
				hiddenPassword += "*";
				OnPropertyChanged("HiddenPassword");
			}
		}

		public LoginCommand LoginCommand { get; set; }

		public event PropertyChangedEventHandler? PropertyChanged;
		public event EventHandler Authenticated;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public LoginWindowVM()
		{
			LoginCommand = new LoginCommand(this);
		}

		public void Login()
		{
			if(Username.ToLower().Equals("consultant") && Password.Equals("qwerty"))
			{
				App.Employee = new Consultant();
				Authenticated.Invoke(this, new EventArgs());
			}
			else if(Username.ToLower().Equals("manager") && Password.Equals("complex_password"))
			{
				App.Employee = new Manager();
                Authenticated.Invoke(this, new EventArgs());
			}
		}
    }
}
