using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApp.ViewModel.Commands
{
    public class UpdateClientInformationCommand : ICommand
    {
        public MainWindowVM MainWindowVM { get; set; }
        public UpdateClientInformationCommand(MainWindowVM mainWindowVM)
        {
            MainWindowVM = mainWindowVM;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if(MainWindowVM.SelectedClient == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(MainWindowVM.SelectedClient.LastName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(MainWindowVM.SelectedClient.FirstName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(MainWindowVM.SelectedClient.PhoneNumber))
            {
                return false;
            }
            if (string.IsNullOrEmpty(MainWindowVM.SelectedClient.PassportNumber))
            {
                return false;
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            MainWindowVM.UpdateClientInformation(MainWindowVM.SelectedClient);
        }
    }
}
