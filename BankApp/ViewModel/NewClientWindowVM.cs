﻿using BankApp.Model;
using BankApp.ViewModel.Commands;
using BankApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.ViewModel
{
    public class NewClientWindowVM : INotifyPropertyChanged
    {
		private Client client;

		public Client Client
		{
			get { return client; }
			set 
			{ 
				client = value;
				OnPropertyChanged("Client");
			}
		}
		private string lastName;

		public string LastName
		{
			get { return lastName; }
			set 
			{ 
				lastName = value;
				Client = new Client()
				{
					LastName = lastName,
					FirstName = this.FirstName,
					MiddleName = this.MiddleName,
					PhoneNumber = this.PhoneNumber,
					PassportSeries = this.PassportSeries,
					PassportNumber = this.PassportNumber,
					ModificationType = "Запись создана",
					ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}",
					ChangedInfo = "",
					ModificatedBy = ""
            };
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
                Client = new Client()
                {
                    LastName = this.LastName,
                    FirstName = firstName,
                    MiddleName = this.MiddleName,
                    PhoneNumber = this.PhoneNumber,
                    PassportSeries = this.PassportSeries,
                    PassportNumber = this.PassportNumber,
                    ModificationType = "Запись создана",
                    ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}",
                    ChangedInfo = "",
                    ModificatedBy = ""
                };
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
                Client = new Client()
                {
                    LastName = this.LastName,
                    FirstName = this.FirstName,
                    MiddleName = middleName,
                    PhoneNumber = this.PhoneNumber,
                    PassportSeries = this.PassportSeries,
                    PassportNumber = this.PassportNumber,
                    ModificationType = "Запись создана",
                    ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}",
                    ChangedInfo = "",
                    ModificatedBy = ""
                };
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
                Client = new Client()
                {
                    LastName = this.LastName,
                    FirstName = this.FirstName,
                    MiddleName = this.MiddleName,
                    PhoneNumber = phoneNumber,
                    PassportSeries = this.PassportSeries,
                    PassportNumber = this.PassportNumber,
                    ModificationType = "Запись создана",
                    ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}",
                    ChangedInfo = "",
                    ModificatedBy = ""
                };
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
                Client = new Client()
                {
                    LastName = this.LastName,
                    FirstName = this.FirstName,
                    MiddleName = this.MiddleName,
                    PhoneNumber = this.PhoneNumber,
                    PassportSeries = passportSeries,
                    PassportNumber = this.PassportNumber,
                    ModificationType = "Запись создана",
                    ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}",
                    ChangedInfo = "",
                    ModificatedBy = ""
                };
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
                Client = new Client()
                {
                    LastName = this.LastName,
                    FirstName = this.FirstName,
                    MiddleName = this.MiddleName,
                    PhoneNumber = this.PhoneNumber,
                    PassportSeries = this.PassportSeries,
                    PassportNumber = passportNumber,
                    ModificationType = "Запись создана",
                    ModificationTime = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}",
                    ChangedInfo = "",
                    ModificatedBy = ""
                };
                OnPropertyChanged("PassportNumber");
            }
		}

		public AddNewClientCommand AddNewClientCommand { get; set; }

		public NewClientWindowVM()
		{
			AddNewClientCommand = new AddNewClientCommand(this);
		}

		public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
		public void AddNewClient(Client client)
		{
			if (DatabaseHelper.Insert(client))
			{
				MessageBox.Show("Информация о клиенте добавлена");
			}
        }
    }
}
