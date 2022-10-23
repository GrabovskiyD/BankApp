using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Model.Interfaces
{
    public interface IBank
    {
        public void GetClients(ObservableCollection<Client> clients);
        public bool AddClient<T>(T item);
        public bool RemoveClient<T>(T item);
        public bool UpdateClient<T>(T item);
    }
}
