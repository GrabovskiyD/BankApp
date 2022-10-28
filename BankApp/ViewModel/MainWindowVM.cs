﻿using BankApp.Model;
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
        #region Поля и свойства клиента
        private Client selectedClient;
        /// <summary>
        /// Клиент, выбранный в главном окне приложения /
        /// Client selected in the main application window
        /// </summary>
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
        /// <summary>
        /// Фамилия клиента /
        /// Client lastname
        /// </summary>
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
        /// <summary>
        /// Имя клиента /
        /// Client firstname
        /// </summary>
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
        /// <summary>
        /// Отчество клиента /
        /// Client middlename
        /// </summary>
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
        /// <summary>
        /// Номер мобильного телефона клиента /
        /// Client mobile phone number
        /// </summary>
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
        /// <summary>
        /// Серия паспорта клиента /
        /// Client passport series
        /// </summary>
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
        /// <summary>
        /// Номер паспорта клиента /
        /// Client passport number
        /// </summary>
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
        /// <summary>
        /// Команда для открытия окна добавления нового клиента /
        /// Command to open the window for adding a new client
        /// </summary>
		#endregion
        public OpenNewClientWindowCommand OpenNewClientWindowCommand { get; set; }
        /// <summary>
        /// Команда для удаления информации о клиенте /
        /// Command for deleting client information
        /// </summary>
		public DeleteClientCommand DeleteClientCommand { get; set; }
        /// <summary>
        /// Команда для обновления информации о клиенте /
        /// Command for updating client information
        /// </summary>
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
        /// <summary>
        /// Открыть окно добавления нового клиента /
        /// Open the new client adding window
        /// </summary>
		public void OpenNewClientWindow()
		{
            NewClientWindow newClientWindow = new NewClientWindow();
            newClientWindow.ShowDialog();
			bank.GetClients(Clients);
        }
        /// <summary>
        /// Удалить информацию о клиенте /
        /// Delete the selected client information
        /// </summary>
        /// <param name="selectedClient"></param>
		public void DeleteClient(Client selectedClient)
		{
			if (bank.RemoveClient(selectedClient))
			{
				MessageBox.Show("Данные о клиенте удалены");
			}
			bank.GetClients(Clients);
		}
        /// <summary>
        /// Обновить информацию о клиенте /
        /// Update the selected client information
        /// </summary>
        /// <param name="selectedClient"></param>
		public void UpdateClientInformation(Client selectedClient)
		{
			if (bank.UpdateClient(selectedClient))
			{
				MessageBox.Show("Информация обновлена");
			}
			bank.GetClients(Clients);
		}
        /// <summary>
        /// Заполнить коллекцию клиентов банка /
        /// Fill the bank clients collection
        /// </summary>
		public void GetClients()
		{
			bank.GetClients(Clients);
		}
        //TODO: Добавлять информацию об изменения информации о клиенте
        //TODO: Добавить возможность смены роли в процессе рабты приложения
        //TODO: Добавить сортировку клиентов по алфавиту
        //TODO: Добавить возможность выбора варианто сортировки*
        //TODO: Добавить возможность создавать и удалять счета для выбранного клиента
        //TODO: Добавить отображения счетов клиента в отдельном ListView
        //TODO: Добавить кастомные исполения информационных окон вместо стандартных
        //TODO: Добавить собственные единообразный стиль

    }
}
