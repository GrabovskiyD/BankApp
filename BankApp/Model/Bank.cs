using BankApp.Model.Interfaces;
using BankApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Model
{
    public class Bank : IBank
    { 
        public void GetClients(ObservableCollection<Client> clients)
        {
            clients.Clear();
            foreach(Client client in DatabaseHelper.Read<Client>())
            {
                clients.Add(client);
            }
        }
        public bool AddClient<T>(T item)
        {
            Client client = item as Client;
            return DatabaseHelper.Insert(client);
        }
        public bool RemoveClient<T>(T item)
        {
            Client client = item as Client;
            return DatabaseHelper.Delete(client);
        }

        public bool UpdateClient<T>(T item)
        {
            Client client = item as Client;
            return DatabaseHelper.Update(client);
        }
    }
}
