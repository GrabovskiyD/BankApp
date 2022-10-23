using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginWindowVM LoginWindowVM { get; set; }
        public LoginCommand(LoginWindowVM loginWindowVM)
        {
            LoginWindowVM = loginWindowVM;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (LoginWindowVM.Login())
            {
                MessageBox.Show("Авторизация успешна");
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
        }
    }
}
