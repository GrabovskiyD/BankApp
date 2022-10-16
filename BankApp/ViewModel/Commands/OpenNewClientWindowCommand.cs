using BankApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApp.ViewModel.Commands
{
    public class OpenNewClientWindowCommand : ICommand
    {
        public MainWindowVM MainWindowVM { get; set; }
        public OpenNewClientWindowCommand(MainWindowVM mainWindowVM)
        {
            MainWindowVM = mainWindowVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MainWindowVM.OpenNewClientWindow();
        }
    }
}
