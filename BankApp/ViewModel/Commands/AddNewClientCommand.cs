using BankApp.Model;
using BankApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApp.ViewModel.Commands
{
    public class AddNewClientCommand : ICommand
    {
        public NewClientWindowVM NewClientWindowVM { get; set; }
        public AddNewClientCommand(NewClientWindowVM newClientWindowVM)
        {
            NewClientWindowVM = newClientWindowVM;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }   

        public bool CanExecute(object? parameter)
        {
            Client client = parameter as Client;
            if(client == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(client.LastName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(client.FirstName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(client.PhoneNumber))
            {
                return false;
            }
            if (string.IsNullOrEmpty(client.PassportNumber))
            {
                return false;
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
