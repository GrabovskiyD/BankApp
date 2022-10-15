using BankApp.Model;
using BankApp.ViewModel.Commands;
using BankApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<Client> Clients { get; set; }
        
		private Client client;

		public Client Client
		{
			get { return client; }
			set { client = value; }
		}

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


		public AddNewClientCommand AddNewClientCommand { get; set; }
		public MainWindowVM()
		{
			AddNewClientCommand = new AddNewClientCommand(this);
			Clients = new ObservableCollection<Client>();
		}

		private void GetClients()
		{
			Clients.Clear();
			foreach(Client client in DatabaseHelper.Read<Client>())
			{
				Clients.Add(client);
			}
		}

        public event PropertyChangedEventHandler? PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
