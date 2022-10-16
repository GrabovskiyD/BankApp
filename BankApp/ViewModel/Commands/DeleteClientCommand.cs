using BankApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApp.ViewModel.Commands
{
    public class DeleteClientCommand : ICommand
    {
        public MainWindowVM MainWindowVM { get; set; }
        public DeleteClientCommand(MainWindowVM mainWindowVM)
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
            return true;
        }

        public void Execute(object? parameter)
        {
            MainWindowVM.DeleteClient(MainWindowVM.SelectedClient);
        }
    }
}
