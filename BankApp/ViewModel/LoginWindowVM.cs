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
        /// <summary>
        /// Роль сотрудника банка /
        /// Bank employee role
        /// </summary>
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
        /// <summary>
        /// Пароль, соответствующий роли сотрудника банка /
        /// Password corresponding to the role of the bank employee
        /// </summary>
        public string Password
		{
			get { return password; }
			set 
			{ 
				password = value;
				OnPropertyChanged("Password");
			}
		}
        /// <summary>
        /// Команда, осуществляющая авторизацию пользователя приложения /
        /// The command that authorizes the application user
        /// </summary>
        public LoginCommand LoginCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
		
		public event EventHandler Authenticated;
        public event EventHandler CloseWindow;
        private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public LoginWindowVM()
		{
			LoginCommand = new LoginCommand(this);
		}
        /// <summary>
        /// Авторизация пользовтеля приложения /
        /// Application user authorization
        /// </summary>
        public void Login()
		{
            if(Username is not null && Password is not null)
            {
                if (App.Employee is null)
                {
                    if (Username.ToLower().Equals("consultant") && Password.Equals("qwerty"))
                    {
                        App.Employee = new Consultant();
                        Authenticated.Invoke(this, new EventArgs());
                    }
                    else if (Username.ToLower().Equals("manager") && Password.Equals("complex_password"))
                    {
                        App.Employee = new Manager();
                        Authenticated.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        InformationWindow informationWindow = new InformationWindow();
                        informationWindow.Text = "Неправильный логин или пароль";
                        informationWindow.Show();
                    }
                }
                else
                {
                    if (Username.ToLower().Equals("consultant") && Password.Equals("qwerty"))
                    {
                        App.Employee = new Consultant();
                        CloseWindow.Invoke(this, new EventArgs());
                    }
                    else if (Username.ToLower().Equals("manager") && Password.Equals("complex_password"))
                    {
                        App.Employee = new Manager();
                        CloseWindow.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        InformationWindow informationWindow = new InformationWindow();
                        informationWindow.Text = "Неправильный логин или пароль";
                        informationWindow.Show();
                    }
                }
            }
            else
            {
                InformationWindow informationWindow = new InformationWindow();
                informationWindow.Text = "Имя пользователя и пароль\nне могут быть пустыми";
                informationWindow.Show();
            }
		}
		//TODO: Хранить пароли не в коде
    }
}
