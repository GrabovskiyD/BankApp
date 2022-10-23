using BankApp.Model;
using BankApp.Model.Interfaces;
using BankApp.View;
using BankApp.ViewModel.Commands;
using BankApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BankApp.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
		private IBank bank;

		public ObservableCollection<Client> Clients { get; set; }
        public LoginWindowVM LoginWindowVM { get; set; }
        private Client selectedClient;
		public Client SelectedClient
		{
			get { return selectedClient; }
			set 
			{ 
				selectedClient = value;
				OnPropertyChanged("SelectedClient");
			}
		}

        private string lastName;
		public string LastName
		{
			get { return lastName; }
			set 
			{ 
				lastName = value;
                SelectedClient.LastName = lastName;
				OnPropertyChanged("LastName");
			}
		}

		private string firstName;
		public string FirstName
		{
			get { return firstName; }
			set 
			{ 
				firstName = value;
                SelectedClient.FirstName = firstName;
                OnPropertyChanged("FirstName");
            }
		}

		private string middleName;
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                SelectedClient.MiddleName = middleName;
                OnPropertyChanged("MiddleName");
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                SelectedClient.PhoneNumber = phoneNumber;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string passportSeries;
        public string PassportSeries
        {
            get { return passportSeries; }
            set
            {
                passportSeries = value;
                SelectedClient.PassportSeries = passportSeries;
                OnPropertyChanged("PassportSeries");
            }
        }

        private string passportNumber;
        public string PassportNumber
        {
            get { return passportNumber; }
            set
            {
                passportNumber = value;
                SelectedClient.PassportNumber = passportNumber;
                OnPropertyChanged("PassportNumber");
            }
        }

		private string modificationType;

		public string ModificationType
		{
			get { return modificationType; }
			set 
			{ 
				modificationType = value;
				OnPropertyChanged("ModificationType");
			}
		}
		public OpenNewClientWindowCommand OpenNewClientWindowCommand { get; set; }
		public DeleteClientCommand DeleteClientCommand { get; set; }
		public UpdateClientInformationCommand UpdateClientInformationCommand { get; set; }
		public MainWindowVM()
		{
            OpenNewClientWindowCommand = new OpenNewClientWindowCommand(this);
			DeleteClientCommand = new DeleteClientCommand(this);
			UpdateClientInformationCommand = new UpdateClientInformationCommand(this);
			Clients = new ObservableCollection<Client>();
			bank = new BankProxy(this, new Bank());
			bank.GetClients(Clients);
		}

        public event PropertyChangedEventHandler? PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public void OpenNewClientWindow()
		{
            NewClientWindow newClientWindow = new NewClientWindow();
            newClientWindow.ShowDialog();
			bank.GetClients(Clients);
        }
		public void DeleteClient(Client selectedClient)
		{
			if (bank.RemoveClient(selectedClient))
			{
				MessageBox.Show("Данные о клиенте удалены");
			}
			bank.GetClients(Clients);
		}
		public void UpdateClientInformation(Client selectedClient)
		{
			if (bank.UpdateClient(selectedClient))
			{
				MessageBox.Show("Информация обновлена");
			}
			bank.GetClients(Clients);
		}

		public void GetClients()
		{
			bank.GetClients(Clients);
		}
    }
}
