using BankApp.Model;
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

namespace BankApp.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<Client> Clients { get; set; }
        
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

        //private int id;

        //public int Id
        //{
        //    get { return id; }
        //    set 
        //    {
        //        id = value;
        //        SelectedClient = new Client()
        //        {
        //            Id = this.Id,
        //            LastName = lastName,
        //            FirstName = this.LastName,
        //            MiddleName = this.MiddleName,
        //            PhoneNumber = this.PhoneNumber,
        //            PassportSeries = this.PassportSeries,
        //            PassportNumber = this.PassportNumber
        //        };
        //        OnPropertyChanged("Id");
        //    }
        //}


        private string lastName;
		public string LastName
		{
			get { return lastName; }
			set 
			{ 
				lastName = value;
                SelectedClient.LastName = lastName;
                SelectedClient.ModificationType = "Изменение данных";
                SelectedClient.ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                SelectedClient.ChangedInfo = "Изменена фамилия";
                SelectedClient.ModificatedBy = "";
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
                SelectedClient.ModificationType = "Изменение данных";
                SelectedClient.ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                SelectedClient.ChangedInfo = "Изменено имя";
                SelectedClient.ModificatedBy = "";
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
                SelectedClient.ModificationType = "Изменение данных";
                SelectedClient.ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                SelectedClient.ChangedInfo = "Изменено отчество";
                SelectedClient.ModificatedBy = "";
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
                SelectedClient.ModificationType = "Изменение данных";
                SelectedClient.ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                SelectedClient.ChangedInfo = "Изменён номер телефона";
                SelectedClient.ModificatedBy = "";
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
                SelectedClient.ModificationType = "Изменение данных";
                SelectedClient.ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                SelectedClient.ChangedInfo = "Изменена серия паспорта";
                SelectedClient.ModificatedBy = "";
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
                SelectedClient.ModificationType = "Изменение данных";
                SelectedClient.ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                SelectedClient.ChangedInfo = "Изменён номер паспорта";
                SelectedClient.ModificatedBy = "";
                OnPropertyChanged("PassportNumber");
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
			GetClients();
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
		public void OpenNewClientWindow()
		{
            NewClientWindow newClientWindow = new NewClientWindow();
            newClientWindow.ShowDialog();
			GetClients();
        }
		public void DeleteClient(Client selectedClient)
		{
			if (DatabaseHelper.Delete(selectedClient))
			{
				MessageBox.Show("Данные о клиенте удалены");
			}
			GetClients();
		}
		public void UpdateClientInformation(Client selectedClient)
		{
			if (DatabaseHelper.Update(selectedClient))
			{
				MessageBox.Show("Информация обновлена");
			}
			GetClients();
		}
    }
}
