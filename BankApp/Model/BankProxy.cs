using BankApp.Model.Interfaces;
using BankApp.ViewModel;
using BankApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Model
{
    public class BankProxy : IBank
    {
        private readonly IBank bank;
        public MainWindowVM MainWindowVM { get; set; }
        public BankProxy(MainWindowVM mainWindowVM, IBank bank)
        {
            MainWindowVM = mainWindowVM;
            this.bank = bank;
        }
        public void GetClients(ObservableCollection<Client> clients)
        {
            clients.Clear();
            foreach(Client client in DatabaseHelper.Read<Client>())
            {
                if(App.Employee != null)
                {
                    if(App.Employee is Consultant)
                    {
                        clients.Add(new Client()
                        {
                            LastName = client.LastName,
                            FirstName = client.FirstName,
                            MiddleName = client.MiddleName,
                            PhoneNumber = client.PhoneNumber,
                            PassportSeries = String.IsNullOrEmpty(client.PassportSeries) ? "" : "********",
                            PassportNumber = String.IsNullOrEmpty(client.PassportNumber) ? "" : "********",
                            ModificationType = client.ModificationType,
                            ModificationTime = client.ModificationTime,
                            ChangedInfo = client.ChangedInfo,
                            ModificatedBy = client.ModificatedBy
                        });
                    }
                    else if(App.Employee is Manager)
                    {
                        bank.GetClients(clients);
                    }
                }
            }
        }
        public bool AddClient<T>(T item)
        {
            return bank.AddClient(item);
        }
        public bool RemoveClient<T>(T item)
        {
            return bank.RemoveClient(item);
        }

        public bool UpdateClient<T>(T item)
        {
            return bank.UpdateClient(item);
        }
    }
}
