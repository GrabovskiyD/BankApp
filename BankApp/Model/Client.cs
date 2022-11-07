using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BankApp.Model
{
    /// <summary>
    /// Клиента банка /
    /// Bank client
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Первичный ключ в БД /
        /// Primary key in DB
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// Фамилия клиента /
        /// Client lastname
        /// </summary>
        [MaxLength(30)]
        public string LastName { get; set; }
        /// <summary>
        /// Имя клиента /
        /// Client firstname
        /// </summary>
        [MaxLength(30)]
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество клиента /
        /// Client middlename
        /// </summary>
        [MaxLength(30)]
        public string MiddleName { get; set; }
        /// <summary>
        /// Номер мобильного телефона клиента /
        /// Client mobile phone number
        /// </summary>
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Серия паспорта клиента /
        /// Client passport series
        /// </summary>
        public string PassportSeries { get; set; }
        [Ignore]
        public string DisplayedPassportSeries { get; set; }
        [Ignore]
        public string DisplayedPassportNumber { get; set; }
        /// <summary>
        /// Номер паспорта клиента /
        /// Client passport number
        /// </summary>
        public string PassportNumber { get; set; }
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
    }
}
