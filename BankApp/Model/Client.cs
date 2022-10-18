using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BankApp.Model
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string MiddleName { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string ModificationType { get; init; } = "Запись создана";
        public string ModificationTime { get; init; } = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";
        public string ChangedInfo { get; init; } = "";
        public string ModificatedBy { get; init; } = "";
    }
}
