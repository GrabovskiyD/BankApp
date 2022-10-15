using BankApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ViewModel
{
    public class MainWindowVM
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
			}
		}

	}
}
