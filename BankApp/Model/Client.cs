using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SQLite;

namespace BankApp.Model
{
    /// <summary>
    /// Клиента банка /
    /// Bank client
    /// </summary>
    public class Client : INotifyPropertyChanged
    {
        /// <summary>
        /// Первичный ключ в БД /
        /// Primary key in DB
        /// </summary>
        public int id;
        [PrimaryKey, AutoIncrement]
        public int Id 
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        /// <summary>
        /// Фамилия клиента /
        /// Client lastname
        /// </summary>
        private string lastName;
        [MaxLength(30)]
        public string LastName 
        { 
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
            }
        }
        /// <summary>
        /// Имя клиента /
        /// Client firstname
        /// </summary>
        private string firstName;
        [MaxLength(30)]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");
            }
        }
        /// <summary>
        /// Отчество клиента /
        /// Client middlename
        /// </summary>
        private string middleName;
        [MaxLength(30)]
        public string MiddleName 
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
                OnPropertyChanged("FullName");
            }
        }
        [Ignore]
        public string FullName
        {
            get { return LastName + " " + FirstName + " " + MiddleName; }
        }
        /// <summary>
        /// Номер мобильного телефона клиента /
        /// Client mobile phone number
        /// </summary>
        private string phoneNumber;
        [MaxLength(11)]
        public string PhoneNumber 
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        /// <summary>
        /// Серия паспорта клиента /
        /// Client passport series
        /// </summary>
        private string passportSeries;
        public string PassportSeries 
        {
            get { return passportSeries; }
            set 
            { 
                passportSeries = value;
                OnPropertyChanged("PassportSeries");
            }
        }
        private string displayedPassportSeries;
        [Ignore]
        public string DisplayedPassportSeries 
        {
            get { return displayedPassportSeries; }
            set
            {
                displayedPassportSeries = value;
                if (displayedPassportSeries != null && !displayedPassportSeries.Contains("*"))
                {
                    PassportSeries = displayedPassportSeries;
                    OnPropertyChanged("PassportSeries");
                }
                OnPropertyChanged("DisplayedPassportSeries");
            } 
        }
        /// <summary>
        /// Номер паспорта клиента /
        /// Client passport number
        /// </summary>
        private string passportNumber;
        public string PassportNumber 
        {
            get { return passportNumber; }
            set
            {
                passportNumber = value;
                OnPropertyChanged("PassportNumber");
            }
        }
        private string displayedPassportNumber;
        [Ignore]
        public string DisplayedPassportNumber
        {
            get { return displayedPassportNumber; }
            set
            {
                displayedPassportNumber = value;
                if (displayedPassportNumber != null && !displayedPassportNumber.Contains("*"))
                {
                    PassportNumber = displayedPassportNumber;
                    OnPropertyChanged("PassportNumber");
                }
                OnPropertyChanged("DisplayedPassportNumebr");
            }
        }
        /// <summary>
        /// Тип изменения информации о клиенте /
        /// Type of customer information modification
        /// </summary>
        public string ModificationType { get; set; }
        /// <summary>
        /// Время внесения изменения информации о клиенте /
        /// Customer information modification time
        /// </summary>
        public string ModificationTime { get; set; }
        /// <summary>
        /// Какая информация изменена /
        /// What information has changed
        /// </summary>
        public string ChangedInfo { get; set; }
        /// <summary>
        /// Кто вносил изменения /
        /// Who made the changes
        /// </summary>
        public string ModificatedBy { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
