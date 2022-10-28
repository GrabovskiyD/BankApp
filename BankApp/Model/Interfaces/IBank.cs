using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Model.Interfaces
{
    /// <summary>
    /// Хранилище данные о клиенте банка / 
    /// Bank customer data storage
    /// </summary>
    public interface IBank
    {
        /// <summary>
        /// Получение данных о клиентах из хранилища и запись в коллекцию, указанную в параметре / 
        /// Getting data about customers from the storage and writing to the collection specified in the parameter
        /// </summary>
        /// <param name="clients"></param>
        public void GetClients(ObservableCollection<Client> clients);
        /// <summary>
        /// Добавление информации о новом клиенте в хранилище /
        /// Adding new customer information to the storage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddClient<T>(T item);
        /// <summary>
        /// Удаление информации о клиенте из хранилища /
        /// Removing customer information from the storage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool RemoveClient<T>(T item);
        /// <summary>
        /// Обновление информации о клиенте /
        /// Update customer information
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateClient<T>(T item);
    }
}
